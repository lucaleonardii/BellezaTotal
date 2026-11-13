using BellezaTotal_DAL.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_DAL
{
    public class BDDAL
    {
        private readonly string CadenaDeConexion = Conexion.CadenaDeConexion;

        public void CrearBackup(string nombreArchivo, string rutaDestino)
        {
            string carpetaTemporal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "BellezaTotal");

            Directory.CreateDirectory(carpetaTemporal);

            string archivoTemporal = Path.Combine(carpetaTemporal, nombreArchivo + ".bak");

            using (SqlConnection cnx = new SqlConnection(CadenaDeConexion))
            {
                cnx.Open();

                string consulta = $@"BACKUP DATABASE [{cnx.Database}] TO DISK = @ruta WITH FORMAT, INIT, NAME = @nombreArchivo";

                using (SqlCommand cmd = new SqlCommand(consulta, cnx))
                {
                    cmd.Parameters.Add("@ruta", SqlDbType.NVarChar, 256).Value = archivoTemporal;
                    cmd.Parameters.Add("@nombreArchivo", SqlDbType.NVarChar, 50).Value = nombreArchivo;

                    cmd.CommandTimeout = 300;
                    cmd.ExecuteNonQuery();
                }
            }

            File.Copy(archivoTemporal, rutaDestino, true);
            File.Delete(archivoTemporal);
        }
        public void RestaurarBackup(string ruta)
        {
            // Se conecta directamente a master: no se puede restaurar una base estando conectado a ella.
            // El nombre de la base sale de la cadena de conexión (no queda escrito a mano).
            SqlConnectionStringBuilder constructor = new SqlConnectionStringBuilder(CadenaDeConexion);
            string baseDeDatos = constructor.InitialCatalog;
            constructor.InitialCatalog = "master";

            string nombre = "[" + baseDeDatos.Replace("]", "]]") + "]";

            // Quien lee el .bak es el SERVICIO de SQL Server, no la aplicación. Se usa la misma carpeta
            // que ya usa CrearBackup (la aplicación puede escribir ahí y el servicio ya puede leerla/escribirla).
            string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "BellezaTotal");
            Directory.CreateDirectory(carpeta);

            string archivoTemporal = Path.Combine(carpeta, "RestauracionTemporal.bak");

            File.Copy(ruta, archivoTemporal, true);

            try
            {
                using (SqlConnection cnx = new SqlConnection(constructor.ConnectionString))
                {
                    cnx.Open();

                    try
                    {
                        string consulta =
                            "ALTER DATABASE " + nombre + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " +
                            "RESTORE DATABASE " + nombre + " FROM DISK = @ruta WITH REPLACE; " +
                            "ALTER DATABASE " + nombre + " SET MULTI_USER;";

                        using (SqlCommand cmd = new SqlCommand(consulta, cnx))
                        {
                            cmd.Parameters.Add("@ruta", SqlDbType.NVarChar, 260).Value = archivoTemporal;
                            cmd.CommandTimeout = 600;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    finally
                    {
                        // Si el restore falla a mitad de camino la base queda en SINGLE_USER y nadie puede
                        // 
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("ALTER DATABASE " + nombre + " SET MULTI_USER;", cnx))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }
                        catch
                        {
                            
                        }
                    }
                }
            }
            finally
            {
                SqlConnection.ClearAllPools();

                if (File.Exists(archivoTemporal))
                    File.Delete(archivoTemporal);
            }
        }

    }
}
