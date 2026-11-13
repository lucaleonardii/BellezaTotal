using BellezaTotal_BE.Familias;
using BellezaTotal_MPP;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;   

namespace BellezaTotal_DAL.Clases
{
    public class PermisosDAL
    {
       
        private string cadenaDeConexion = Conexion.CadenaDeConexion;

        public List<Permiso> ObtenerPermisosAsignados(int usuarioId)
        {
            PermisosMPP mapeador = new PermisosMPP();

            DataTable tablaPatentes = Consultar("SELECT PatenteId, Nombre FROM seguridad.Patente");
            DataTable tablaFamilias = Consultar("SELECT FamiliaId, Nombre FROM seguridad.Familia");
            DataTable tablaFamiliaPatente = Consultar("SELECT FamiliaId, PatenteId FROM seguridad.Familia_Patente");
            DataTable tablaFamiliaFamilia = Consultar("SELECT FamiliaPadreId, FamiliaHijaId FROM seguridad.Familia_Familia");
            DataTable tablaFamiliasDelUsuario = Consultar(
                "SELECT FamiliaId FROM seguridad.Usuario_Familia WHERE UsuarioId = @usuarioId", usuarioId);
            DataTable tablaPatentesDelUsuario = Consultar(
                "SELECT PatenteId FROM seguridad.Usuario_Patente WHERE UsuarioId = @usuarioId", usuarioId);

            return mapeador.ArmarPermisosAsignados(
                tablaPatentes, tablaFamilias, tablaFamiliaPatente, tablaFamiliaFamilia,
                tablaFamiliasDelUsuario, tablaPatentesDelUsuario);
        }

        private DataTable Consultar(string consulta, int? usuarioId = null)
        {
            DataTable resultado = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                if (usuarioId.HasValue)
                    comando.Parameters.Add("@usuarioId", SqlDbType.Int).Value = usuarioId.Value;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    adaptador.Fill(resultado);  
                }
            }

            return resultado;
        }

        public void GuardarAsignacion(int usuarioId, List<int> idsFamilias, List<int> idsPatentes)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            {
                conexion.Open();

                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        
                        EjecutarConUsuario(conexion, transaccion,
                            "DELETE FROM Seguridad.Usuario_Familia WHERE UsuarioId = @usuarioId", usuarioId);
                        EjecutarConUsuario(conexion, transaccion,
                            "DELETE FROM Seguridad.Usuario_Patente WHERE UsuarioId = @usuarioId", usuarioId);

                        
                        foreach (int familiaId in idsFamilias)
                        {
                            EjecutarConUsuario(conexion, transaccion,
                                "INSERT INTO Seguridad.Usuario_Familia (UsuarioId, FamiliaId) VALUES (@usuarioId, @permisoId)",
                                usuarioId, familiaId);
                        }

                        foreach (int patenteId in idsPatentes)
                        {
                            EjecutarConUsuario(conexion, transaccion,
                                "INSERT INTO Seguridad.Usuario_Patente (UsuarioId, PatenteId) VALUES (@usuarioId, @permisoId)",
                                usuarioId, patenteId);
                        }

                        transaccion.Commit();    
                    }
                    catch
                    {
                        transaccion.Rollback();  
                        throw;
                    }
                }
            }
        }

        private void EjecutarConUsuario(SqlConnection conexion, SqlTransaction transaccion,
                                        string consulta, int usuarioId, int? permisoId = null)
        {
            using (SqlCommand comando = new SqlCommand(consulta, conexion, transaccion))
            {
                comando.Parameters.Add("@usuarioId", SqlDbType.Int).Value = usuarioId;

                if (permisoId.HasValue)
                    comando.Parameters.Add("@permisoId", SqlDbType.Int).Value = permisoId.Value;

                comando.ExecuteNonQuery();
            }
        }


    }
}