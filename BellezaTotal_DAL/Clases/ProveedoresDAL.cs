using BellezaTotal_BE.Excepciones;
using BellezaTotal_BE.Personas;
using BellezaTotal_DAL.Interfaces;
using BellezaTotal_MAPPER.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BellezaTotal_DAL.Clases
{
    public class ProveedoresDAL : IABMC<Proveedor>
    {
        private string cadenaDeConexion = Conexion.CadenaDeConexion;

        public void Alta(Proveedor proveedor)
        {
            string consulta =
                "INSERT INTO Negocio.Proveedores (Nombre, CUIT, Email, Telefono) " +
                "OUTPUT INSERTED.ProveedorId " +
                "VALUES (@nombre, @cuit, @email, @telefono)";

            EjecutarEnTransaccion((conexion, transaccion) =>
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion, transaccion))
                {
                    AgregarParametros(comando, proveedor);
                    proveedor.ProveedorId = Convert.ToInt32(comando.ExecuteScalar());
                }
            });
        }

        public void Modificacion(Proveedor proveedor, int id)
        {
            string consulta =
                "UPDATE Negocio.Proveedores " +
                "SET Nombre = @nombre, CUIT = @cuit, Email = @email, Telefono = @telefono " +
                "WHERE ProveedorId = @id AND Activo = 1";

            EjecutarEnTransaccion((conexion, transaccion) =>
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion, transaccion))
                {
                    AgregarParametros(comando, proveedor);
                    comando.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    if (comando.ExecuteNonQuery() == 0) throw new ExcepcionNegocio("EXP_ProveedorInexistente");
                }
            });
        }

        public void Baja(Proveedor proveedor)
        {
            string consulta =
                "DELETE FROM Negocio.Proveedores WHERE ProveedorId = @id";

            EjecutarEnTransaccion((conexion, transaccion) =>
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion, transaccion))
                {
                    comando.Parameters.Add("@id", SqlDbType.Int).Value = proveedor.ProveedorId;

                    if (comando.ExecuteNonQuery() == 0) throw new ExcepcionNegocio("EXP_ProveedorInexistente");
                }
            });
        }

        public void Deshabilitar(Proveedor proveedor)
        {
            string consulta =
                "UPDATE Negocio.Proveedores SET Activo = 0 " +
                "WHERE ProveedorId = @id AND Activo = 1";

            EjecutarEnTransaccion((conexion, transaccion) =>
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion, transaccion))
                {
                    comando.Parameters.Add("@id", SqlDbType.Int).Value = proveedor.ProveedorId;

                    if (comando.ExecuteNonQuery() == 0) throw new ExcepcionNegocio("EXP_ProveedorInexistente");
                }
            });
        }

        public List<Proveedor> Listar()
        {
            string consulta =
                "SELECT ProveedorId, Nombre, CUIT, Email, Telefono, Activo " +
                "FROM Negocio.Proveedores " +
                "WHERE Activo = 1 " +
                "ORDER BY Nombre";

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                return new ProveedorMPP().MapearLista(tabla);
            }
        }

     
        public bool ExisteCuit(string cuit, int idAExcluir)
        {
            string consulta =
                "SELECT COUNT(1) FROM Negocio.Proveedores " +
                "WHERE CUIT = @cuit AND ProveedorId <> @id";

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@cuit", SqlDbType.NVarChar, 13).Value = cuit;
                comando.Parameters.Add("@id", SqlDbType.Int).Value = idAExcluir;

                conexion.Open();
                return Convert.ToInt32(comando.ExecuteScalar()) > 0;
            }
        }

        private void AgregarParametros(SqlCommand comando, Proveedor proveedor)
        {
            comando.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = proveedor.Nombre;
            comando.Parameters.Add("@cuit", SqlDbType.NVarChar, 13).Value = proveedor.CUIT;
            comando.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = proveedor.Email;
            comando.Parameters.Add("@telefono", SqlDbType.NVarChar, 20).Value =
                string.IsNullOrEmpty(proveedor.Telefono) ? (object)DBNull.Value : proveedor.Telefono;
        }


        private void EjecutarEnTransaccion(Action<SqlConnection, SqlTransaction> accion)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            {
                conexion.Open();

                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        accion(conexion, transaccion);
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
    }
}