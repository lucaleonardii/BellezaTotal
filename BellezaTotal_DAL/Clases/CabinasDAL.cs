using BellezaTotal_BE.Agenda;
using BellezaTotal_MAPPER.Clases;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BellezaTotal_DAL.Clases
{
    // Por ahora solo lectura. El ABM de cabinas y de bloqueos queda para el desarrollo posterior.
    public class CabinasDAL
    {
        private string cadenaDeConexion = Conexion.CadenaDeConexion;

        public List<Cabina> Listar()
        {
            string consulta =
                "SELECT CabinaId, NumeroCabina, Estado " +
                "FROM Negocio.Cabinas " +
                "ORDER BY NumeroCabina";

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                return new CabinaMPP().MapearLista(tabla);
            }
        }

        public List<BloqueoCabina> ListarBloqueos()
        {
            string consulta =
                "SELECT BloqueoId, CabinaId, Motivo, FechaDesde, FechaHasta " +
                "FROM Negocio.BloqueosCabina";

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                return new CabinaMPP().MapearBloqueos(tabla);
            }
        }
    }
}
