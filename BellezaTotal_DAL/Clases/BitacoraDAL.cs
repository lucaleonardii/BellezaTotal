using BellezaTotal_BE.Auditoria;
using BellezaTotal_MPP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BellezaTotal_DAL.Clases
{
    public class BitacoraDAL
    {
        private string cadenaDeConexion = Conexion.CadenaDeConexion;

        public List<string> ObtenerNombresDeUsuarios()
        {
            DataTable tablaNombres = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(
                "SELECT NombreUsuario FROM Seguridad.Usuarios ORDER BY NombreUsuario", conexion))
            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
            {
                adaptador.Fill(tablaNombres);
            }

            List<string> nombres = new List<string>();

            foreach (DataRow filaUsuario in tablaNombres.Rows)
            {
                nombres.Add((string)filaUsuario["NombreUsuario"]);
            }

            return nombres;
        }

        public void Insertar(Bitacora registro)
        {
            string consulta =
                "INSERT INTO Seguridad.Bitacora (UsuarioId, NombreUsuario, Severidad, Accion, Descripcion) " +
                "VALUES (@usuarioId, @nombreUsuario, @severidad, @accion, @descripcion)";

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@usuarioId", SqlDbType.Int).Value =
                    ValorONulo(registro.UsuarioId);
                comando.Parameters.Add("@nombreUsuario", SqlDbType.NVarChar, 50).Value =
                    ValorONulo(registro.NombreUsuario);
                comando.Parameters.Add("@severidad", SqlDbType.NVarChar, 10).Value =
                    registro.Severidad.ToString().ToUpperInvariant();
                comando.Parameters.Add("@accion", SqlDbType.NVarChar, 100).Value = registro.Accion;
                comando.Parameters.Add("@descripcion", SqlDbType.NVarChar, 500).Value =
                    ValorONulo(registro.Descripcion);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        

        public List<Bitacora> ListarConFiltros(FiltroBitacora filtro)
        {
            string consulta =
                "SELECT BitacoraId, FechaHora, UsuarioId, NombreUsuario, Severidad, Accion, Descripcion " +
                "FROM Seguridad.Bitacora " +
                "WHERE (@fechaDesde IS NULL OR FechaHora >= @fechaDesde) " +
                "AND (@fechaHastaExclusiva IS NULL OR FechaHora < @fechaHastaExclusiva) " +
                "AND (@nombreUsuario IS NULL OR NombreUsuario = @nombreUsuario) " +
                "AND (@severidad IS NULL OR Severidad = @severidad) " +
                "ORDER BY FechaHora DESC, BitacoraId DESC";

            DateTime? fechaDesde = filtro.FechaDesde?.Date;
            DateTime? fechaHastaExclusiva = filtro.FechaHasta?.Date.AddDays(1);

            string nombreUsuario = string.IsNullOrWhiteSpace(filtro.NombreUsuario)
                ? null
                : filtro.NombreUsuario.Trim();

            string severidad = filtro.Severidad?.ToString().ToUpperInvariant();

            DataTable tablaBitacora = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@fechaDesde", SqlDbType.DateTime2).Value = ValorONulo(fechaDesde);
                comando.Parameters.Add("@fechaHastaExclusiva", SqlDbType.DateTime2).Value = ValorONulo(fechaHastaExclusiva);
                comando.Parameters.Add("@nombreUsuario", SqlDbType.NVarChar, 50).Value = ValorONulo(nombreUsuario);
                comando.Parameters.Add("@severidad", SqlDbType.NVarChar, 10).Value = ValorONulo(severidad);

                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    adaptador.Fill(tablaBitacora);
                }
            }

            return new BitacoraMPP().ArmarBitacoras(tablaBitacora);
        }

        private object ValorONulo(object valor)
        {
            return valor ?? DBNull.Value;
        }

        public List<Bitacora> ObtenerTodas()
        {
            string consulta =
                "SELECT BitacoraId, FechaHora, UsuarioId, NombreUsuario, Severidad, Accion, Descripcion " +
                "FROM Seguridad.Bitacora " +
                "ORDER BY FechaHora DESC, BitacoraId DESC";

            DataTable tablaBitacora = new DataTable();

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
            {
                adaptador.Fill(tablaBitacora);   // abre y cierra la conexión solo
            }

            return new BitacoraMPP().ArmarBitacoras(tablaBitacora);
        }
    }
}