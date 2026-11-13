using BellezaTotal_BE;
using BellezaTotal_BE.Auditoria;
using BellezaTotal_DAL.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace BellezaTotal_SEC.Clases
{
    public class BitacoraBLL
    {


        private const string PatenteConsulta = "pat_VerBitacora";


        public void Registrar(string accion, SeveridadBitacora severidad, string descripcion = null)
        {
            UsuarioSesion usuarioActual = AdministradorDeSesion.Instancia.UsuarioActual;

            int? usuarioId = usuarioActual?.UsuarioId;
            string nombreUsuario = usuarioActual?.NombreUsuario;

            Registrar(accion, severidad, descripcion, usuarioId, nombreUsuario);
        }

        public void Registrar(string accion, SeveridadBitacora severidad, string descripcion,
                              int? usuarioId, string nombreUsuario)
        {
            Bitacora registro = new Bitacora
            {
                UsuarioId = usuarioId,
                NombreUsuario = Recortar(nombreUsuario, 50),
                Severidad = severidad,
                Accion = Recortar(accion, 100),
                Descripcion = Recortar(descripcion, 500)
            };

            try
            {
                new BitacoraDAL().Insertar(registro);
            }
            catch (Exception excepcion)
            {
                System.Diagnostics.Debug.WriteLine(excepcion.Message);
            }
        }

        public List<Bitacora> Consultar(FiltroBitacora filtro)
        {
            VerificarPermisoConsulta();

            if (filtro.FechaDesde.HasValue && filtro.FechaHasta.HasValue &&
                filtro.FechaDesde.Value.Date > filtro.FechaHasta.Value.Date)
                throw new ArgumentException("La fecha desde no puede ser posterior a la fecha hasta");

            return new BitacoraDAL().ListarConFiltros(filtro);
        }

        public List<Bitacora> ObtenerTodas()
        {
            VerificarPermisoConsulta();
            return new BitacoraDAL().ObtenerTodas();
        }

        public List<string> ObtenerNombresUsuarios()
        {
            VerificarPermisoConsulta();
            return new BitacoraDAL().ObtenerNombresDeUsuarios();
        }

        private void VerificarPermisoConsulta()
        {
            AdministradorDeSesion administradorDeSesion = AdministradorDeSesion.Instancia;

            if (!administradorDeSesion.HaySesionActiva ||
                !administradorDeSesion.UsuarioActual.TienePermiso(PatenteConsulta))
                throw new UnauthorizedAccessException("No tiene permiso para consultar la bitácora");
        }

        private string Recortar(string texto, int largoMaximo)
        {
            if (texto == null) return null;
            return texto.Length <= largoMaximo ? texto : texto.Substring(0, largoMaximo);
        }
    }
}