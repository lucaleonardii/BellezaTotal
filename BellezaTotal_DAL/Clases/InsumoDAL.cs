using BellezaTotal_BE.Insumos;
using BellezaTotal_BE.Excepciones;
using BellezaTotal_DAL.Interfaces;
using BellezaTotal_MAPPER.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_DAL.Clases
{
    public class InsumoDAL : IABMC<Insumo>
    {
        private string CadenaDeConexion = Conexion.CadenaDeConexion;
        private InsumoMPP mpp = new InsumoMPP();

        public void Alta(Insumo insumo)
        {
            using (SqlConnection conexion = new SqlConnection(CadenaDeConexion))
            {
                string query = @"INSERT INTO Negocio.Insumo
                                (Nombre, StockActual)
                                VALUES (@nombre, @stockActual);
                                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@nombre", SqlDbType.NVarChar, 50).Value = insumo.Nombre;
                    comando.Parameters.Add("@stockActual", SqlDbType.Int).Value = insumo.StockActual;

                    conexion.Open();

                    insumo.IdInsumo = (int)comando.ExecuteScalar();
                }
            }
        }

        public void Baja(Insumo insumo)
        {
            using (SqlConnection conexion = new SqlConnection(CadenaDeConexion))
            {
                string query = @"DELETE FROM Negocio.Insumo
                                 WHERE InsumoId = @idInsumo";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@idInsumo", SqlDbType.Int).Value = insumo.IdInsumo;

                    conexion.Open();

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                        throw new ExcepcionNegocio("EXP_InsumonoEncontrado");
                }
            }
        }

        public void Modificacion(Insumo insumo, int id)
        {
            using (SqlConnection conexion = new SqlConnection(CadenaDeConexion))
            {
                string query = @"UPDATE Negocio.Insumo
                                 SET Nombre = @nombre,
                                     StockActual = @stockActual
                                 WHERE InsumoId = @idInsumo";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@nombre", SqlDbType.NVarChar, 50).Value = insumo.Nombre;
                    comando.Parameters.Add("@stockActual", SqlDbType.Int).Value = insumo.StockActual;
                    comando.Parameters.Add("@idInsumo", SqlDbType.Int).Value = id;

                    conexion.Open();

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas == 0)
                        throw new ExcepcionNegocio("EXP_InsumonoEncontrado");
                }
            }
        }

        public List<Insumo> Listar()
        {
            List<Insumo> insumos = new List<Insumo>();

            using (SqlConnection conexion = new SqlConnection(CadenaDeConexion))
            {
                string query = @"SELECT InsumoId, Nombre, StockActual
                                 FROM Negocio.Insumo";

                using (SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        insumos.Add(mpp.Mapear(fila));
                    }
                }
            }

            return insumos;
        }
    }
}
