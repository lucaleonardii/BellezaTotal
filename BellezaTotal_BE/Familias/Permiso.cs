
using System.Collections.Generic;


namespace BellezaTotal_BE.Familias
{
    public abstract class Permiso
    {
        private int _permisoId;
        public int PermisoId
        {//
            get => _permisoId;
            set => _permisoId = value;
        }

        private string _nombre;
        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        private string _descripcion;
        public string Descripcion
        {
            get => _descripcion;
            set => _descripcion = value;
        }
        public abstract IEnumerable<Patente> ObtenerPatentes();


    }
}
