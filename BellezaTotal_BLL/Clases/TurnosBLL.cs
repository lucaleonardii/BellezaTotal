using BellezaTotal_BE.Agenda;
using BellezaTotal_BE.Auditoria;
using BellezaTotal_BE.Excepciones;
using BellezaTotal_DAL.Clases;
using BellezaTotal_SEC.Clases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BellezaTotal_BLL.Clases
{
    public class TurnosBLL
    {
        private TurnosDAL dal = new TurnosDAL();
        private CabinasDAL cabinasDal = new CabinasDAL();
        private BitacoraBLL bitacora = new BitacoraBLL();

        public void Alta(Turno turno)
        {
            ValidarDatos(turno);
            ValidarDisponibilidad(turno, 0);

            turno.Estado = EstadoTurno.Programado;
            dal.Alta(turno);

            bitacora.Registrar(
                AccionesBitacora.AltaTurno,
                SeveridadBitacora.Info,
                Describir(turno));
        }


        public void Modificacion(Turno turno, int id)
        {
            if (id <= 0) throw new ExcepcionNegocio("EXP_IdTurnoInvalido");

            ValidarDatos(turno);

            if (string.IsNullOrWhiteSpace(turno.MotivoModificacion))
                throw new ExcepcionNegocio("EXP_FaltaMotivoTurno");

            ValidarDisponibilidad(turno, id);

            turno.TurnoId = id;
            dal.Modificacion(turno, id);

            bitacora.Registrar(
                AccionesBitacora.ModificacionTurno,
                SeveridadBitacora.Info,
                Describir(turno) + " | Motivo: " + turno.MotivoModificacion);
        }

        
        public void Baja(Turno turno)
        {
            if (turno == null) throw new ArgumentNullException(nameof(turno));
            if (turno.TurnoId <= 0) throw new ExcepcionNegocio("EXP_IdTurnoInvalido");

            if (string.IsNullOrWhiteSpace(turno.MotivoModificacion))
                throw new ExcepcionNegocio("EXP_FaltaMotivoTurno");

            if (turno.Estado != EstadoTurno.Programado && turno.Estado != EstadoTurno.EnSala)
                throw new ExcepcionNegocio("EXP_TurnoEstadoInvalido");

            dal.Baja(turno);
            turno.Estado = EstadoTurno.Cancelado;

            bitacora.Registrar(
                AccionesBitacora.CancelacionTurno,
                SeveridadBitacora.Info,
                "Turno " + turno.TurnoId + " | Motivo: " + turno.MotivoModificacion);
        }

        public List<Turno> Listar()
        {
            return dal.Listar();
        }

        // Turnos de un día ordenados por horario
        public List<Turno> ListarPorFecha(DateTime fecha)
        {
            return dal.Listar()
                .Where(t => t.FechaSesion.Date == fecha.Date)
                .OrderBy(t => t.FechaSesion)
                .ToList();
        }

        public void MarcarLlegada(Turno turno)
        {
            CambiarEstado(turno, EstadoTurno.EnSala, AccionesBitacora.LlegadaTurno, EstadoTurno.Programado);
        }

        public void Atender(Turno turno)
        {
            CambiarEstado(turno, EstadoTurno.Atendido, AccionesBitacora.AtencionTurno,
                EstadoTurno.Programado, EstadoTurno.EnSala);
        }

        private void CambiarEstado(Turno turno, EstadoTurno nuevoEstado, string accion,
                                   params EstadoTurno[] estadosPermitidos)
        {
            if (turno == null) throw new ArgumentNullException(nameof(turno));
            if (turno.TurnoId <= 0) throw new ExcepcionNegocio("EXP_IdTurnoInvalido");

            if (!estadosPermitidos.Contains(turno.Estado))
                throw new ExcepcionNegocio("EXP_TurnoEstadoInvalido");

            dal.CambiarEstado(turno.TurnoId, nuevoEstado);
            turno.Estado = nuevoEstado;

            bitacora.Registrar(accion, SeveridadBitacora.Info, "Turno " + turno.TurnoId);
        }

        private void ValidarDatos(Turno turno)
        {
            if (turno == null) throw new ArgumentNullException(nameof(turno));

            if (turno.Cliente == null || turno.Cliente.ClienteId <= 0)
                throw new ExcepcionNegocio("EXP_FaltaClienteTurno");

            if (turno.Profesional == null || turno.Profesional.ProfesionalId <= 0)
                throw new ExcepcionNegocio("EXP_FaltaProfesionalTurno");

            if (turno.Cabina == null || turno.Cabina.CabinaId <= 0)
                throw new ExcepcionNegocio("EXP_FaltaCabinaTurno");

            if (turno.Servicio == null || turno.Servicio.IdServicio <= 0)
                throw new ExcepcionNegocio("EXP_FaltaServicioTurno");

            if (!turno.Servicio.Activo)
                throw new ExcepcionNegocio("EXP_ServicioInactivo");

            // Si el servicio exige una especialidad, el profesional debe tenerla
            if (turno.Servicio.EspecialidadId.HasValue &&
                turno.Profesional.EspecialidadId != turno.Servicio.EspecialidadId)
                throw new ExcepcionNegocio("EXP_ProfesionalNoCapacitado");

            if (turno.Cabina.Estado != Cabina.EstadoDisponible)
                throw new ExcepcionNegocio("EXP_CabinaNoDisponible");

            if (turno.FechaSesion < DateTime.Now)
                throw new ExcepcionNegocio("EXP_FechaTurnoPasada");

            // La duración se toma del servicio; en un plan se calcula recursivamente
            turno.DuracionMinutos = turno.Servicio.ObtenerDuracion();

            if (turno.DuracionMinutos <= 0)
                throw new ExcepcionNegocio("EXP_DuracionServicioInvalida");
        }

        // Evita el solapamiento de la cabina y del profesional (RF 08 / RF 23) y respeta los bloqueos (RF 25)
        private void ValidarDisponibilidad(Turno turno, int turnoIdAExcluir)
        {
            List<Turno> vigentes = dal.Listar()
                .Where(t => t.Estado != EstadoTurno.Cancelado && t.TurnoId != turnoIdAExcluir)
                .ToList();

            if (vigentes.Any(t => t.Cabina.CabinaId == turno.Cabina.CabinaId && turno.SeSolapaCon(t)))
                throw new ExcepcionNegocio("EXP_TurnoSolapadoCabina");

            if (vigentes.Any(t => t.Profesional.ProfesionalId == turno.Profesional.ProfesionalId && turno.SeSolapaCon(t)))
                throw new ExcepcionNegocio("EXP_TurnoSolapadoProfesional");

            string cabinaId = turno.Cabina.CabinaId.ToString();
            DateTime inicio = turno.FechaSesion;
            DateTime fin = turno.FechaFin;

            if (cabinasDal.ListarBloqueos().Any(b =>
                    b.CabinaBloqueadaID == cabinaId && b.FechaDesde < fin && inicio < b.FechaHasta))
                throw new ExcepcionNegocio("EXP_CabinaBloqueada");
        }

        private string Describir(Turno turno)
        {
            return string.Format(
                "Turno {0} | {1:dd/MM/yyyy HH:mm} | Cliente {2} | Profesional {3} | Cabina {4} | Servicio {5}",
                turno.TurnoId,
                turno.FechaSesion,
                turno.Cliente.ClienteId,
                turno.Profesional.ProfesionalId,
                turno.Cabina.NumeroCabina,
                turno.Servicio.Nombre);
        }
    }
}
