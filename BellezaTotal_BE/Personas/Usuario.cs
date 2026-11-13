using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_BE.Personas
{
    public class Usuario
    {
        private string _nombreUsuario;
        private string _email;
        private string _contraseñaHash;
        private int _intentosFallidos;
        private int _usuarioId;
        private bool _estado;
        private string _idiomaPreferido;

        public int UsuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }
        public string NombreUsuario 
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        public string ContraseñaHash
        {
            get { return _contraseñaHash; }
            set { _contraseñaHash = value; }
        }
        public string Email 
        { 
            get { return _email; }
            set { _email = value; }
        }
        public string IdiomaPreferido
        {
            get { return _idiomaPreferido; }
            set { _idiomaPreferido = value; }
        }
        
        public int IntentosFallidos 
        {
            get { return _intentosFallidos; }
            set { _intentosFallidos = value; }
        }
        

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public Usuario(int usuarioId, string nombreUsuario, string contraseñaHash, string email, string idiomaPreferido, int intentosFallidos, bool estado) 
        { 
            _usuarioId = usuarioId;
            _nombreUsuario = nombreUsuario;
            _contraseñaHash = contraseñaHash;
            _email = email;
            _idiomaPreferido = idiomaPreferido;
            _intentosFallidos = intentosFallidos;
            _estado = estado;
        }

        public Usuario() { }
    }
}
