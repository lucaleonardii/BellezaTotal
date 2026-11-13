using BellezaTotal_BE.Familias;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BellezaTotal_BE
{
    public sealed class UsuarioSesion
    {
        private readonly List<Permiso> _listaPermisos;
        public IReadOnlyList<Permiso> ListaPermisos => _listaPermisos;

        private int _usuarioId;
		public int UsuarioId => _usuarioId; 

		private string _nombreUsuario;
		public string NombreUsuario => _nombreUsuario;

		private string _email;
		public string Email => _email;

		private string _idiomaPreferido;
		public string IdiomaPreferido => _idiomaPreferido;

        public UsuarioSesion(int usuarioId, string nombreUsuario, string email, string idiomaPreferido, IEnumerable<Permiso> permisos)
        {
            _usuarioId = usuarioId;
            _nombreUsuario = nombreUsuario;
            _email = email;
           _idiomaPreferido = idiomaPreferido;
            _listaPermisos = permisos?.ToList() ?? new List<Permiso>();
        }//

        public bool TienePermiso(string nombrePatente)
        {
            foreach(Permiso permiso in _listaPermisos)
            {
                if (string.Equals(permiso.Nombre, nombrePatente, StringComparison.OrdinalIgnoreCase)) return true;
            }
            return false;
        }
    }
}
