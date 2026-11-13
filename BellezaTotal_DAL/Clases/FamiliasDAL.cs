using BellezaTotal_BE.Familias;
using BellezaTotal_MPP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BellezaTotal_DAL.Clases
{
    public class FamiliasDAL
    {
        private string cadenaDeConexion = Conexion.CadenaDeConexion;

        // ---------- Lecturas ----------

        public CatalogoPermisos ObtenerCatalogo()
        {
            DataTable tablaPatentes = Consultar("SELECT PatenteId, Nombre FROM Seguridad.Patente");
            DataTable tablaFamilias = Consultar("SELECT FamiliaId, Nombre FROM Seguridad.Familia");
            DataTable tablaFamiliaPatente = Consultar("SELECT FamiliaId, PatenteId FROM Seguridad.Familia_Patente");
            DataTable tablaFamiliaFamilia = Consultar("SELECT FamiliaPadreId, FamiliaHijaId FROM Seguridad.Familia_Familia");

            return new FamiliasMPP().ArmarCatalogo(
                tablaPatentes, tablaFamilias, tablaFamiliaPatente, tablaFamiliaFamilia);
        }

        public int ContarUsuariosConFamilia(int familiaId)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(
                "SELECT COUNT(*) FROM Seguridad.Usuario_Familia WHERE FamiliaId = @familiaId", conexion))
            {
                comando.Parameters.Add("@familiaId", SqlDbType.Int).Value = familiaId;

                conexion.Open();
                return (int)comando.ExecuteScalar();
            }
        }

        // Nombres de las familias que contienen a esta como hija
        public List<string> ObtenerNombresFamiliasPadre(int familiaId)
        {
            DataTable tablaNombres = Consultar(
                "SELECT padre.Nombre FROM Seguridad.Familia_Familia AS relacion " +
                "JOIN Seguridad.Familia AS padre ON padre.FamiliaId = relacion.FamiliaPadreId " +
                "WHERE relacion.FamiliaHijaId = @familiaId", familiaId);

            return new FamiliasMPP().ArmarNombres(tablaNombres);
        }

        // ---------- Escrituras (cada una es una sola transacción) ----------

        public int Insertar(string nombre, List<int> idsPatentes, List<int> idsFamiliasHijas)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            {
                conexion.Open();

                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        int familiaId;

                        using (SqlCommand comando = new SqlCommand(
                            "INSERT INTO Seguridad.Familia (Nombre) VALUES (@nombre); " +
                            "SELECT CAST(SCOPE_IDENTITY() AS INT);", conexion, transaccion))
                        {
                            comando.Parameters.Add("@nombre", SqlDbType.NVarChar, 50).Value = nombre;
                            familiaId = (int)comando.ExecuteScalar();
                        }

                        InsertarComposicion(conexion, transaccion, familiaId, idsPatentes, idsFamiliasHijas);

                        transaccion.Commit();
                        return familiaId;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Modificar(int familiaId, string nombre, List<int> idsPatentes, List<int> idsFamiliasHijas)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            {
                conexion.Open();

                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand comando = new SqlCommand(
                            "UPDATE Seguridad.Familia SET Nombre = @nombre WHERE FamiliaId = @familiaId",
                            conexion, transaccion))
                        {
                            comando.Parameters.Add("@nombre", SqlDbType.NVarChar, 50).Value = nombre;
                            comando.Parameters.Add("@familiaId", SqlDbType.Int).Value = familiaId;

                            int filasAfectadas = comando.ExecuteNonQuery();
                            if (filasAfectadas == 0)
                                throw new InvalidOperationException("La familia no existe");
                        }

                        // Se reemplaza la composición anterior por la nueva
                        EjecutarConFamilia(conexion, transaccion,
                            "DELETE FROM Seguridad.Familia_Patente WHERE FamiliaId = @familiaId", familiaId);
                        EjecutarConFamilia(conexion, transaccion,
                            "DELETE FROM Seguridad.Familia_Familia WHERE FamiliaPadreId = @familiaId", familiaId);

                        InsertarComposicion(conexion, transaccion, familiaId, idsPatentes, idsFamiliasHijas);

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

        public void Eliminar(int familiaId)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            {
                conexion.Open();

                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        EjecutarConFamilia(conexion, transaccion,
                            "DELETE FROM Seguridad.Familia_Patente WHERE FamiliaId = @familiaId", familiaId);
                        EjecutarConFamilia(conexion, transaccion,
                            "DELETE FROM Seguridad.Familia_Familia WHERE FamiliaPadreId = @familiaId", familiaId);

                        // Si alguien la usa (usuario o familia padre), la clave foránea hace fallar este
                        // DELETE y la transacción se deshace: es la red de seguridad de la validación de la BLL
                        EjecutarConFamilia(conexion, transaccion,
                            "DELETE FROM Seguridad.Familia WHERE FamiliaId = @familiaId", familiaId);

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

        private void InsertarComposicion(SqlConnection conexion, SqlTransaction transaccion,
                                         int familiaId, List<int> idsPatentes, List<int> idsFamiliasHijas)
        {
            foreach (int patenteId in idsPatentes)
            {
                EjecutarConFamilia(conexion, transaccion,
                    "INSERT INTO Seguridad.Familia_Patente (FamiliaId, PatenteId) VALUES (@familiaId, @otroId)",
                    familiaId, patenteId);
            }

            foreach (int familiaHijaId in idsFamiliasHijas)
            {
                EjecutarConFamilia(conexion, transaccion,
                    "INSERT INTO Seguridad.Familia_Familia (FamiliaPadreId, FamiliaHijaId) VALUES (@familiaId, @otroId)",
                    familiaId, familiaHijaId);
            }
        }

        private void EjecutarConFamilia(SqlConnection conexion, SqlTransaction transaccion,
                                        string consulta, int familiaId, int? otroId = null)
        {
            using (SqlCommand comando = new SqlCommand(consulta, conexion, transaccion))
            {
                comando.Parameters.Add("@familiaId", SqlDbType.Int).Value = familiaId;

                if (otroId.HasValue)
                    comando.Parameters.Add("@otroId", SqlDbType.Int).Value = otroId.Value;

                comando.ExecuteNonQuery();
            }
        }

        private DataTable Consultar(string consulta, int? familiaId = null)
        {
            DataTable resultado = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                if (familiaId.HasValue)
                    comando.Parameters.Add("@familiaId", SqlDbType.Int).Value = familiaId.Value;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    adaptador.Fill(resultado);
                }
            }

            return resultado;
        }
    }
}