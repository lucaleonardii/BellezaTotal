using System;

namespace BellezaTotal_BE.Agenda
{
    public class NotificacionRecepcion
    {
        private string _nombreCliente;
        public string NombreCliente
        {
            get => _nombreCliente;
            set => _nombreCliente = value;
        }

        private string _estado;
        public string Estado
        {
            get => _estado;
            set => _estado = value;
        }

        private int _turnoId;
        public int TurnoId
        {
            get => _turnoId;
            set => _turnoId = value;
        }

        private int _notificacionId;
        public int NotificacionId
        {
            get => _notificacionId;
            set => _notificacionId = value;
        }

        private DateTime _fechaActualizacion; 
        public DateTime FechaActualizar
        {
            get => _fechaActualizacion;
            set => _fechaActualizacion = value;
        }
    }
}
