using BellezaTotal_BE.Servicios;
using BellezaTotal_MAPPER.Clases;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System;


namespace BellezaTotal_DAL.Clases
{
    public class ServiciosDAL
    {
        private string cadenaDeConexion = Conexion.CadenaDeConexion;

        
        public List<Servicio> Listar()
        {
            return ListarTodos().Where(s => s.Activo).ToList();
        }

        
        public List<Servicio> ListarTodos()
        {
            string consulta =
                "SELECT ServicioId, Tipo, Nombre, Descripcion, EspecialidadId, " +
                "Precio, Duracion, Descuento, Activo " +
                "FROM Negocio.Servicios; " +

                "SELECT PlanId, ServicioId " +
                "FROM Negocio.Plan_Servicio;";

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
            {
                DataSet datos = new DataSet();
                adaptador.Fill(datos);

                if (datos.Tables.Count < 2)
                    return new List<Servicio>();

                return new ServicioMPP().MapearCatalogo(datos.Tables[0], datos.Tables[1]);
            }
        }

        public void Alta(string tipo, string nombre, string descripcion, string especialidadId, decimal precio, int duracion)
        {
            string consulta = "INSERT INTO Negocio.Servicios (Tipo, Nombre, Descripcion, EspecialidadId, Precio, Duracion) " +
                                "SELECT v.Tipo, v.Nombre, v.Descripcion, e.EspecialidadId, v.Precio, v.Duracion " +
                                "FROM (VALUES " +
                                "(@tipo, @nombre, @descripcion, @especialidadId, @precio, @duracion)) " +
                                "AS v(Tipo, Nombre, Descripcion, Especialidad, Precio, Duracion) " +
                                "INNER JOIN Negocio.Especialidad e ON e.Nombre = v.Especialidad " +
                                "WHERE NOT EXISTS (SELECT 1 FROM Negocio.Servicios s WHERE s.Nombre = v.Nombre);";

            using (SqlConnection cnx = new SqlConnection(cadenaDeConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, cnx))
            {
                cmd.Parameters.Add("@tipo", SqlDbType.NVarChar, 10).Value = tipo;
                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = nombre;
                cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar, 300).Value = descripcion;

                
                cmd.Parameters.Add("@especialidadId", SqlDbType.NVarChar, 50).Value = especialidadId;

                cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;
                cmd.Parameters.Add("@duracion", SqlDbType.Int).Value = duracion;

                cnx.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<string> ObtenerEspecialidades()
        {
            List<string> especialidades = new List<string>();
            string consulta = "SELECT Nombre FROM Negocio.Especialidad;";

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        especialidades.Add(lector["Nombre"].ToString());
                    }
                }
            }

            return especialidades;
        }

        public void Modificacion(int servicioId, string tipo, string nombre, string descripcion, string especialidadNombre, decimal precio, int duracion)
        {
            string consulta = "UPDATE Negocio.Servicios " +
                              "SET Tipo = @tipo, " +
                              "Nombre = @nombre, " +
                              "Descripcion = @descripcion, " +
                              "EspecialidadId = (SELECT EspecialidadId FROM Negocio.Especialidad WHERE Nombre = @especialidadNombre), " +
                              "Precio = @precio, " +
                              "Duracion = @duracion " +
                              "WHERE ServicioId = @servicioId;";

            using (SqlConnection cnx = new SqlConnection(cadenaDeConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, cnx))
            {
                cmd.Parameters.Add("@servicioId", SqlDbType.Int).Value = servicioId;
                cmd.Parameters.Add("@tipo", SqlDbType.NVarChar, 10).Value = tipo;
                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = nombre;
                cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar, 300).Value = descripcion;
                cmd.Parameters.Add("@especialidadNombre", SqlDbType.NVarChar, 100).Value = especialidadNombre;
                cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;
                cmd.Parameters.Add("@duracion", SqlDbType.Int).Value = duracion;

                cnx.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public string ObtenerNombreEspecialidadPorId(int? id)
        {
            string consulta = "SELECT Nombre FROM Negocio.Especialidad WHERE EspecialidadId = @id;";

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@id", SqlDbType.Int).Value = id;

                conexion.Open();

                
                object resultado = comando.ExecuteScalar();

                if (resultado != null && resultado != DBNull.Value)
                {
                    return resultado.ToString();
                }

                
                return null;
            }
        }

    }
}
