using BellezaTotal_BE.Personas;
using BellezaTotal_BE.Servicios;
using System;

namespace BellezaTotal_BE.Agenda
{
    public class Turno
    {
        public int TurnoId { get; set; }

        public DateTime FechaSesion { get; set; }

        public int DuracionMinutos { get; set; }

        public EstadoTurno Estado { get; set; }

        public string MotivoModificacion { get; set; }

        public Cliente Cliente { get; set; }

        public Profesional Profesional { get; set; }

        public Cabina Cabina { get; set; }

        public Servicio Servicio { get; set; }

        public DateTime FechaFin
        {
            get { return FechaSesion.AddMinutes(DuracionMinutos); }
        }

        public Turno()
        {
            Estado = EstadoTurno.Programado;
        }

        public bool SeSolapaCon(Turno otro)
        {
            return otro != null
                && FechaSesion < otro.FechaFin
                && otro.FechaSesion < FechaFin;
        }
    }
}
