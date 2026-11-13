using BellezaTotal_BE.Personas;
using BellezaTotal_MAPPER.Clases;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BellezaTotal_DAL.Clases
{
    // Por ahora solo lectura. Cuando se agregue el ABM de profesionales se puede
    // implementar IABMC<Profesional> sobre esta misma clase.
    public class ProfesionalesDAL
    {
        private string cadenaDeConexion = Conexion.CadenaDeConexion;

        public List<Profesional> Listar()
        {
            string consulta =
                "SELECT p.ProfesionalId, p.UsuarioId, p.Nombre, p.Apellido, " +
                "p.EspecialidadId, e.Nombre AS Especialidad " +
                "FROM Negocio.Profesionales p " +
                "LEFT JOIN Negocio.Especialidad e ON e.EspecialidadId = p.EspecialidadId " +
                "WHERE p.Activo = 1 " +
                "ORDER BY p.Apellido, p.Nombre";

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
            {
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                return new ProfesionalMPP().MapearLista(tabla);
            }
        }
    }
}
