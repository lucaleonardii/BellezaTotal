using BellezaTotal_BE.Agenda;
using BellezaTotal_BE.Personas;
using BellezaTotal_BE.Servicios;
using System;
using System.Collections.Generic;
using System.Data;

namespace BellezaTotal_MAPPER.Clases
{
    public class TurnoMPP
    {
        // Orden: 0 TurnoId, 1 ClienteId, 2 ProfesionalId, 3 CabinaId, 4 ServicioId,
        //        5 FechaSesion, 6 DuracionMinutos, 7 Estado, 8 MotivoModificacion
        public object[] ObtenerValores(Turno turno)
        {
            return new object[]
            {
                turno.TurnoId,
                turno.Cliente.ClienteId,
                turno.Profesional.ProfesionalId,
                turno.Cabina.CabinaId,
                turno.Servicio.IdServicio,
                turno.FechaSesion,
                turno.DuracionMinutos,
                turno.Estado.ToString(),
                turno.MotivoModificacion
            };
        }

        public Turno Mapear(DataRow fila, Dictionary<int, Servicio> catalogo)
        {
            Turno turno = new Turno();

            turno.TurnoId = Convert.ToInt32(fila["TurnoId"]);
            turno.FechaSesion = Convert.ToDateTime(fila["FechaHoraInicio"]);
            turno.DuracionMinutos = Convert.ToInt32(fila["DuracionMinutos"]);
            turno.Estado = (EstadoTurno)Enum.Parse(typeof(EstadoTurno), fila["Estado"].ToString());
            turno.MotivoModificacion = fila["MotivoModificacion"] == DBNull.Value
                ? null
                : fila["MotivoModificacion"].ToString();

            Cliente cliente = new Cliente();
            cliente.ClienteId = Convert.ToInt32(fila["ClienteId"]);
            cliente.Nombre = fila["ClienteNombre"].ToString();
            cliente.Apellido = fila["ClienteApellido"].ToString();
            cliente.DNI = Convert.ToInt32(fila["ClienteDNI"]);
            turno.Cliente = cliente;

            Profesional profesional = new Profesional();
            profesional.ProfesionalId = Convert.ToInt32(fila["ProfesionalId"]);
            profesional.UsuarioId = fila["ProfesionalUsuarioId"] == DBNull.Value
                ? 0
                : Convert.ToInt32(fila["ProfesionalUsuarioId"]);
            profesional.Nombre = fila["ProfesionalNombre"].ToString();
            profesional.Apellido = fila["ProfesionalApellido"].ToString();
            profesional.EspecialidadId = fila["ProfesionalEspecialidadId"] == DBNull.Value
                ? (int?)null
                : Convert.ToInt32(fila["ProfesionalEspecialidadId"]);
            profesional.Especialidad = fila["EspecialidadNombre"] == DBNull.Value
                ? null
                : fila["EspecialidadNombre"].ToString();
            turno.Profesional = profesional;

            Cabina cabina = new Cabina();
            cabina.CabinaId = Convert.ToInt32(fila["CabinaId"]);
            cabina.NumeroCabina = Convert.ToInt32(fila["NumeroCabina"]);
            cabina.Estado = fila["CabinaEstado"].ToString();
            turno.Cabina = cabina;

            Servicio servicio;
            catalogo.TryGetValue(Convert.ToInt32(fila["ServicioId"]), out servicio);
            turno.Servicio = servicio;

            return turno;
        }

        public List<Turno> MapearLista(DataTable tabla, Dictionary<int, Servicio> catalogo)
        {
            List<Turno> lista = new List<Turno>();

            foreach (DataRow fila in tabla.Rows)
                lista.Add(Mapear(fila, catalogo));

            return lista;
        }
    }
}
