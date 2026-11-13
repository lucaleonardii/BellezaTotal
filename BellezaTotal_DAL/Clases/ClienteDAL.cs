
using BellezaTotal_BE.Personas;
using BellezaTotal_DAL.Interfaces;
using BellezaTotal_MAPPER.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BellezaTotal_DAL.Clases
{
    public class ClientesDAL : IABMC<Cliente>
    {
        private string cadenaDeConexion = Conexion.CadenaDeConexion;

        public void Alta(Cliente cliente)
        {
            string consulta =
                "INSERT INTO Negocio.Clientes " +
                "(Nombre, Apellido, DNI, Email, Telefono) " +
                "OUTPUT INSERTED.ClienteId " +
                "VALUES (@nombre, @apellido, @dni, @email, @telefono)";

            ClienteMPP mpp = new ClienteMPP();
            object[] valores = mpp.ObtenerValores(cliente);

            using (SqlConnection conexion =
                new SqlConnection(cadenaDeConexion))
            {
                conexion.Open();

                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        int clienteId;

                        using (SqlCommand comando =
                            new SqlCommand(consulta, conexion, transaccion))
                        {
                            comando.Parameters.Add(
                                "@nombre", SqlDbType.NVarChar, 50).Value = valores[1];

                            comando.Parameters.Add(
                                "@apellido", SqlDbType.NVarChar, 50).Value = valores[2];

                            comando.Parameters.Add(
                                "@dni", SqlDbType.Int).Value = valores[3];

                            comando.Parameters.Add(
                                "@email", SqlDbType.NVarChar, 100).Value = valores[4];

                            comando.Parameters.Add(
                                "@telefono", SqlDbType.NVarChar, 20).Value = valores[5];

                            clienteId = Convert.ToInt32(
                                comando.ExecuteScalar());
                        }

                        InsertarFichaTecnica(
                            conexion,
                            transaccion,
                            clienteId,
                            cliente);

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

        public void Baja(Cliente cliente)
        {
            string consulta =
                "UPDATE Negocio.Clientes " +
                "SET Activo = 0 " +
                "WHERE ClienteId = @clienteId";

            using (SqlConnection conexion =
                new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando =
                new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add(
                    "@clienteId", SqlDbType.Int).Value = cliente.ClienteId;

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                    throw new InvalidOperationException(
                        "No se encontró el cliente.");
            }
        }

        public void Modificacion(Cliente cliente, int id)
        {
            string consulta =
                "UPDATE Negocio.Clientes SET " +
                "Nombre = @nombre, " +
                "Apellido = @apellido, " +
                "DNI = @dni, " +
                "Email = @email, " +
                "Telefono = @telefono " +
                "WHERE ClienteId = @clienteId AND Activo = 1";

            ClienteMPP mpp = new ClienteMPP();
            object[] valores = mpp.ObtenerValores(cliente);

            using (SqlConnection conexion =
                new SqlConnection(cadenaDeConexion))
            {
                conexion.Open();

                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand comando =
                            new SqlCommand(consulta, conexion, transaccion))
                        {
                            comando.Parameters.Add(
                                "@nombre", SqlDbType.NVarChar, 50).Value = valores[1];

                            comando.Parameters.Add(
                                "@apellido", SqlDbType.NVarChar, 50).Value = valores[2];

                            comando.Parameters.Add(
                                "@dni", SqlDbType.Int).Value = valores[3];

                            comando.Parameters.Add(
                                "@email", SqlDbType.NVarChar, 100).Value = valores[4];

                            comando.Parameters.Add(
                                "@telefono", SqlDbType.NVarChar, 20).Value = valores[5];

                            comando.Parameters.Add(
                                "@clienteId", SqlDbType.Int).Value = id;

                            int filasAfectadas = comando.ExecuteNonQuery();

                            if (filasAfectadas == 0)
                                throw new InvalidOperationException(
                                    "No se encontró el cliente activo.");
                        }

                        // Eliminar la ficha técnica anterior
                        EliminarFichaTecnica(
                            conexion,
                            transaccion,
                            id);

                        // Insertar la nueva ficha técnica
                        InsertarFichaTecnica(
                            conexion,
                            transaccion,
                            id,
                            cliente);

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

        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            string consulta =
                "SELECT ClienteId, Nombre, Apellido, DNI, Email, Telefono, Activo " +
                "FROM Negocio.Clientes " +
                "WHERE Activo = 1; " +

                "SELECT a.ClienteId, a.Alergia " +
                "FROM Negocio.Cliente_Alergias a " +
                "INNER JOIN Negocio.Clientes c ON a.ClienteId = c.ClienteId " +
                "WHERE c.Activo = 1; " +

                "SELECT a.ClienteId, a.Afeccion " +
                "FROM Negocio.Cliente_Afecciones a " +
                "INNER JOIN Negocio.Clientes c ON a.ClienteId = c.ClienteId " +
                "WHERE c.Activo = 1; " +

                "SELECT c.ClienteId, c.Contraindicacion " +
                "FROM Negocio.Cliente_Contraindicaciones c " +
                "INNER JOIN Negocio.Clientes cli ON c.ClienteId = cli.ClienteId " +
                "WHERE cli.Activo = 1;";

            using (SqlConnection conexion =
                new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando =
                new SqlCommand(consulta, conexion))
            using (SqlDataAdapter adaptador =
                new SqlDataAdapter(comando))
            {
                DataSet datos = new DataSet();

                adaptador.Fill(datos);

                if (datos.Tables.Count >= 4)
                {
                    ClienteMPP mpp = new ClienteMPP();

                    lista = mpp.MapearLista(
                        datos.Tables[0],
                        datos.Tables[1],
                        datos.Tables[2],
                        datos.Tables[3]);
                }
            }

            return lista;
        }
        
        public HashSet<int> ObtenerDnisRegistrados()
        {
            HashSet<int> dnis = new HashSet<int>();

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand("SELECT DNI FROM Negocio.Clientes", conexion))
            {
                conexion.Open();

                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                        dnis.Add(lector.GetInt32(0));
                }
            }

            return dnis;
        }
        private void InsertarFichaTecnica(
            SqlConnection conexion,
            SqlTransaction transaccion,
            int clienteId,
            Cliente cliente)
        {
            // Insertar alergias
            if (cliente.FichaTecnicaAlergias != null)
            {
                foreach (string alergia in cliente.FichaTecnicaAlergias)
                {
                    using (SqlCommand comando = new SqlCommand(
                        "INSERT INTO Negocio.Cliente_Alergias " +
                        "(ClienteId, Alergia) VALUES (@id, @valor)",
                        conexion, transaccion))
                    {
                        comando.Parameters.Add(
                            "@id", SqlDbType.Int).Value = clienteId;

                        comando.Parameters.Add(
                            "@valor", SqlDbType.NVarChar, 100).Value = alergia;

                        comando.ExecuteNonQuery();
                    }
                }
            }

            if (cliente.FichaTecnicaAfecciones != null)
            {
                foreach (string afeccion in cliente.FichaTecnicaAfecciones)
                {
                    using (SqlCommand comando = new SqlCommand(
                        "INSERT INTO Negocio.Cliente_Afecciones " +
                        "(ClienteId, Afeccion) VALUES (@id, @valor)",
                        conexion, transaccion))
                    {
                        comando.Parameters.Add(
                            "@id", SqlDbType.Int).Value = clienteId;

                        comando.Parameters.Add(
                            "@valor", SqlDbType.NVarChar, 100).Value = afeccion;

                        comando.ExecuteNonQuery();
                    }
                }
            }

            if (cliente.FichaTecnicaContraindicaciones != null)
            {
                foreach (string contraindicacion in
                    cliente.FichaTecnicaContraindicaciones)
                {
                    using (SqlCommand comando = new SqlCommand(
                        "INSERT INTO Negocio.Cliente_Contraindicaciones " +
                        "(ClienteId, Contraindicacion) VALUES (@id, @valor)",
                        conexion, transaccion))
                    {
                        comando.Parameters.Add(
                            "@id", SqlDbType.Int).Value = clienteId;

                        comando.Parameters.Add(
                            "@valor", SqlDbType.NVarChar, 100).Value =
                            contraindicacion;

                        comando.ExecuteNonQuery();
                    }
                }
            }
        }

        private void EliminarFichaTecnica(
            SqlConnection conexion,
            SqlTransaction transaccion,
            int clienteId)
        {
            string[] consultas =
            {
                "DELETE FROM Negocio.Cliente_Alergias WHERE ClienteId = @id",
                "DELETE FROM Negocio.Cliente_Afecciones WHERE ClienteId = @id",
                "DELETE FROM Negocio.Cliente_Contraindicaciones WHERE ClienteId = @id"
            };

            foreach (string consulta in consultas)
            {
                using (SqlCommand comando =
                    new SqlCommand(consulta, conexion, transaccion))
                {
                    comando.Parameters.Add(
                        "@id", SqlDbType.Int).Value = clienteId;

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
