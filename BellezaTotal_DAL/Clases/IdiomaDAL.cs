using BellezaTotal_BE.Idiomas;
using BellezaTotal_MAPPER.Clases;
using BellezaTotal_MPP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BellezaTotal_DAL.Clases
{
    public class IdiomaDAL
    {
        private string cadenaDeConexion = Conexion.CadenaDeConexion;

        public List<IdiomaSistema> ObtenerIdiomas()
        {
            DataTable tablaIdiomas = Consultar("SELECT Codigo, Nombre FROM Seguridad.Idioma ORDER BY Nombre");
            return new IdiomaMPP().ArmarIdiomas(tablaIdiomas);
        }

        public List<Leyenda> ObtenerLeyendas(string codigoIdioma)
        {
            DataTable tablaLeyendas = Consultar("SELECT Clave, Texto FROM Seguridad.Leyenda WHERE IdiomaCodigo = @codigoIdioma", codigoIdioma);

            return new IdiomaMPP().ArmarLeyendas(tablaLeyendas);
        }

        public void ActualizarIdiomaPreferido(int usuarioId, string codigoIdioma)
        {
            string consulta = "UPDATE Seguridad.Usuarios SET IdiomaPreferido = @codigoIdioma WHERE UsuarioId = @usuarioId";

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@codigoIdioma", SqlDbType.NVarChar, 20).Value = codigoIdioma;
                comando.Parameters.Add("@usuarioId", SqlDbType.Int).Value = usuarioId;

                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0) throw new InvalidOperationException("El usuario no existe");
            }
        }

        private DataTable Consultar(string consulta, string codigoIdioma = null)
        {
            DataTable resultado = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                if (codigoIdioma != null) comando.Parameters.Add("@codigoIdioma", SqlDbType.NVarChar, 10).Value = codigoIdioma;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    adaptador.Fill(resultado);
                }
            }

            return resultado;
        }
    }
}