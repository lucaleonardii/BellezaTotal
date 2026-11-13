using BellezaTotal_BE;
using BellezaTotal_BE.Auditoria;
using BellezaTotal_BE.Familias;
using BellezaTotal_BE.Personas;
using BellezaTotal_DAL.Clases;
using BellezaTotal_BE.Excepciones;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;


using BellezaTotal_BE.Idiomas;
namespace BellezaTotal_SEC.Clases
{
    public sealed class AdministradorDeSesion
    {
        private const int IntentosFallidosMaximos = 3;

        private readonly string regexEmail = "^(?=.{1,50}$)[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";

        private static readonly Lazy<AdministradorDeSesion> _instancia =
            new Lazy<AdministradorDeSesion>(() => new AdministradorDeSesion());

        // Evita que dos hilos ejecuten a la vez el inicio o cierre de sesión
        private readonly object _lock = new object();
        private UsuarioSesion _usuarioActual;
        private DateTime? _inicioSesion;

        private UsuariosDAL dal = new UsuariosDAL();


        public static AdministradorDeSesion Instancia => _instancia.Value;

        private AdministradorDeSesion() { }

        public UsuarioSesion UsuarioActual
        {
            get { lock (_lock) { return _usuarioActual; } }
        }

        public bool HaySesionActiva
        {
            get { lock (_lock) { return _usuarioActual != null; } }
        }

        public DateTime? InicioSesion
        {
            get { lock (_lock) { return _inicioSesion; } }
        }
        public void Registrase(string nombre, string contrasena, string email)
        {
            if (string.IsNullOrEmpty(nombre)) throw new ExcepcionNegocio("EXP_FaltaNombre");
            if (string.IsNullOrEmpty(contrasena)) throw new ExcepcionNegocio("EXP_FaltaContrasena");
            if (string.IsNullOrEmpty(email)) throw new ExcepcionNegocio("EXP_FaltaEmail");

            if (!Regex.IsMatch(email, regexEmail)) throw new ExcepcionNegocio("EXP_EmailInvalido");

            UsuariosDAL accesoUsuarios = new UsuariosDAL();
            Encriptador encriptador = new Encriptador();

            Usuario usuarioBuscado = accesoUsuarios.ObtenerPorNombre(nombre);

            if (usuarioBuscado != null) throw new ExcepcionNegocio("EXP_UsuarioDuplicado");

            Usuario usuario = new Usuario(0, nombre, encriptador.Encriptar(contrasena), email,"",0,true);

            dal.Alta(usuario);
            dal.EstablecerFamiliaInvitado(usuario.NombreUsuario);


        }
        public bool IniciarSesion(string nombreUsuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario)) throw new ExcepcionNegocio("EXP_UsuarioSinValor");
            if (string.IsNullOrWhiteSpace(clave)) throw new ExcepcionNegocio("EXP_ContrasenaSinValor");

            lock (_lock)
            {
                if (_usuarioActual != null) throw new ExcepcionNegocio("EXP_SesionYaIniciada"); 

                UsuariosDAL accesoUsuarios = new UsuariosDAL();
                Encriptador encriptador = new Encriptador();


                Usuario usuarioBuscado = accesoUsuarios.ObtenerPorNombre(nombreUsuario);
                if (usuarioBuscado == null) throw new ExcepcionNegocio("EXP_ClavesIncorrectas");

                if (!usuarioBuscado.Estado) throw new ExcepcionNegocio("EXP_UsuarioInactivo");

                if (usuarioBuscado.IntentosFallidos >= IntentosFallidosMaximos) throw new ExcepcionNegocio("EXP_AvisoCuentaBloqueada");

                string claveHash = encriptador.Encriptar(clave);
                if (usuarioBuscado.ContraseñaHash != claveHash)
                {
                    new BitacoraBLL().Registrar(AccionesBitacora.InicioSesionFallido, SeveridadBitacora.Warning, $"Se ha intentado iniciar sesión en la cuenta {usuarioBuscado.NombreUsuario}. Intentos restantes: {3 - usuarioBuscado.IntentosFallidos}");
                    int nuevosIntentos = usuarioBuscado.IntentosFallidos + 1;
                    ActualizarIntentosFallidos(accesoUsuarios, usuarioBuscado, nuevosIntentos);

                    if (nuevosIntentos >= IntentosFallidosMaximos)
                    {
                        new BitacoraBLL().Registrar(AccionesBitacora.CuentaBloqueada, SeveridadBitacora.Warning, $"La cuenta {usuarioBuscado.NombreUsuario} ha sido bloqueada");
                        throw new ExcepcionNegocio("EXP_CuentaBloqueada");
                    }

                    throw new ExcepcionNegocio("EXP_ClavesIncorrectas");
                }

                if (usuarioBuscado.IntentosFallidos > 0)
                    ActualizarIntentosFallidos(accesoUsuarios, usuarioBuscado, 0);

                List<Permiso> permisosEfectivos = new PermisosBLL().ObtenerPermisosEfectivos(usuarioBuscado.UsuarioId);

                _usuarioActual = new UsuarioSesion(
                    usuarioBuscado.UsuarioId,
                    usuarioBuscado.NombreUsuario,
                    usuarioBuscado.Email,
                    usuarioBuscado.IdiomaPreferido,
                    permisosEfectivos);
                _inicioSesion = DateTime.Now;


                new BitacoraBLL().Registrar(AccionesBitacora.InicioSesion, SeveridadBitacora.Info,$"El usuario {_usuarioActual.NombreUsuario} ha iniciado sesión");
                return true;
            }
        }

        public void CerrarSesion()
        {
            lock (_lock)
            {
                new BitacoraBLL().Registrar(AccionesBitacora.CierreSesion, SeveridadBitacora.Info, $"El usuario {_usuarioActual.NombreUsuario} ha cerrado sesión");
                _usuarioActual = null;
                _inicioSesion = null;
            }
        }

        private void ActualizarIntentosFallidos(UsuariosDAL accesoUsuarios, Usuario usuario, int intentos)
        {
            Usuario usuarioModificado = new Usuario(
                usuario.UsuarioId,
                usuario.NombreUsuario,
                usuario.ContraseñaHash,
                usuario.Email,
                usuario.IdiomaPreferido,
                intentos,
                usuario.Estado);

            accesoUsuarios.Modificacion(usuarioModificado, usuario.UsuarioId);
        }
    }
}