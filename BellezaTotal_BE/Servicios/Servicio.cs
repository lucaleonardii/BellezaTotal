using System;

namespace BellezaTotal_BE.Servicios
{
    public abstract class Servicio : IComparable<Servicio>, ITratamiento
    {
        public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? EspecialidadId { get; set; }
        public decimal Precio { get; set; }
        public int Duracion { get; set; }
        public bool Activo { get; set; }

        // Implementación de ITratamiento: el identificador del tratamiento es el del servicio
        public int IdTratamiento
        {
            get { return IdServicio; }
            set { IdServicio = value; }
        }

        public abstract string Tipo { get; }

        protected Servicio()
        {
            Activo = true;
        }

        protected Servicio(int idServicio, string nombre, string descripcion, int? especialidadId, decimal precio, int duracion) : this()
        {
            IdServicio = idServicio;
            Nombre = nombre;
            Descripcion = descripcion;
            EspecialidadId = especialidadId;
            Precio = precio;
            Duracion = duracion;
        }

        public virtual decimal ObtenerPrecio()
        {
            return Precio;
        }

        public virtual int ObtenerDuracion()
        {
            return Duracion;
        }

        public int CompareTo(Servicio otro)
        {
            if (otro == null) return 1;
            return string.Compare(Nombre, otro.Nombre, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}