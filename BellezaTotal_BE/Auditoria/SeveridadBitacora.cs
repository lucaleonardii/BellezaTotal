using System;

namespace BellezaTotal_BE.Auditoria
{
    public enum SeveridadBitacora { Info, Warning, Error }

    public class Bitacora
    {
        public int BitacoraId { get; set; }
        public DateTime FechaHora { get; set; }
        public int? UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public SeveridadBitacora Severidad { get; set; }
        public string Accion { get; set; }
        public string Descripcion { get; set; }
    }

   
    public class FiltroBitacora
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public string NombreUsuario { get; set; }
        public SeveridadBitacora? Severidad { get; set; }
    }
}