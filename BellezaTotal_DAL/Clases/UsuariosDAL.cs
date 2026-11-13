using BellezaTotal_BE.Personas;
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
    public class UsuariosDAL : IABMC<Usuario>
    {
        private string cadenaDeConexion = Conexion.CadenaDeConexion;

        public void Alta(Usuario usuario)
        {
            string consulta = "INSERT INTO Seguridad.Usuarios (NombreUsuario, ContrasenaHash, Email) VALUES (@nombreUsuario, @contrasenaHash, @email)";

            UsuariosMPP mpp = new UsuariosMPP();

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@nombreUsuario", SqlDbType.NVarChar, 50);
                comando.Parameters.Add("@contrasenaHash", SqlDbType.NVarChar, 255);
                comando.Parameters.Add("@email", SqlDbType.NVarChar, 50);

                object[] valores = mpp.ObtenerValores(usuario);

                comando.Parameters["@nombreUsuario"].Value = valores[1];
                comando.Parameters["@contrasenaHash"].Value = valores[2];
                comando.Parameters["@email"].Value = valores[3];


                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void Baja(Usuario usuario)
        {
            string consulta = "DELETE FROM Seguridad.Usuarios WHERE UsuarioId = @usuarioId";

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            {
                cmd.Parameters.Add("@usuarioId", SqlDbType.Int);
                cmd.Parameters["@usuarioId"].Value = usuario.UsuarioId;

                conexion.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void Modificacion(Usuario postUsuario, int id)
        {
            string consulta =
                "UPDATE Seguridad.Usuarios SET " +
                "NombreUsuario = @postNombreUsuario," +
                "ContrasenaHash = @postContrasenaHash," +
                "Email = @postEmail," +
                "IdiomaPreferido = @postIdiomaPreferido," +
                "IntentosFallidos = @postIntentosFallidos," +
                "Activo = @postActivo " +
                "WHERE UsuarioId = @preUsuarioId";

            UsuariosMPP mpp = new UsuariosMPP();


            object[] valoresPost = mpp.ObtenerValores(postUsuario);

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@postNombreUsuario", SqlDbType.NVarChar, 50);
                comando.Parameters.Add("@postContrasenaHash", SqlDbType.NVarChar, 255);
                comando.Parameters.Add("@postEmail", SqlDbType.NVarChar, 50);
                comando.Parameters.Add("@postIdiomaPreferido", SqlDbType.NVarChar, 20);
                comando.Parameters.Add("@postIntentosFallidos", SqlDbType.Int);
                comando.Parameters.Add("@postActivo", SqlDbType.Bit);

                comando.Parameters.Add("@preUsuarioId", SqlDbType.Int);

                comando.Parameters["@postNombreUsuario"].Value = valoresPost[1];
                comando.Parameters["@postContrasenaHash"].Value = valoresPost[2];
                comando.Parameters["@postEmail"].Value = valoresPost[3];
                comando.Parameters["@postIdiomaPreferido"].Value = valoresPost[4];
                comando.Parameters["@postIntentosFallidos"].Value = valoresPost[5];
                comando.Parameters["@postActivo"].Value = valoresPost[6];

                comando.Parameters["@preUsuarioId"].Value = id;

                conexion.Open();

                comando.ExecuteNonQuery();

            }

        }

        public void EstablecerFamilia(string usuario, string nombreFamilia)
        {
            string consulta =   "INSERT INTO Seguridad.Usuario_Familia (UsuarioId, FamiliaId) " +
                                "SELECT usuario.UsuarioId, familia.FamiliaId " +
                                "FROM Seguridad.Usuarios AS usuario, Seguridad.Familia AS familia " +
                                "WHERE usuario.NombreUsuario = @usuario AND familia.Nombre = @nombreFamilia;";



            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            {
                cmd.Parameters.Add("@usuario", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@nombreFamilia", SqlDbType.NVarChar, 256);

                cmd.Parameters["@usuario"].Value = usuario;
                cmd.Parameters["@nombreFamilia"].Value = nombreFamilia;

                conexion.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void EstablecerFamiliaInvitado(string usuario)
        {
            string consulta = "INSERT INTO Seguridad.Usuario_Familia (UsuarioId, FamiliaId) " +
                                "SELECT usuario.UsuarioId, familia.FamiliaId " +
                                "FROM Seguridad.Usuarios AS usuario, Seguridad.Familia AS familia " +
                                "WHERE usuario.NombreUsuario = @usuario AND familia.Nombre = 'FAM_INVITADO';";



            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            {
                cmd.Parameters.Add("@usuario", SqlDbType.NVarChar, 50);
                cmd.Parameters["@usuario"].Value = usuario;

                conexion.Open();

                cmd.ExecuteNonQuery();

            }
        }
        public Usuario ObtenerPorNombre(string nombreUsuario)
        {
            Usuario usuario = null;

            string consulta = "SELECT UsuarioId, NombreUsuario, ContrasenaHash, Email, IdiomaPreferido, IntentosFallidos, Activo FROM Seguridad.Usuarios WHERE NombreUsuario = @nombreUsuario";

            using (SqlConnection conexion = new SqlConnection(cadenaDeConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@nombreUsuario", SqlDbType.NVarChar, 50);
                comando.Parameters["@nombreUsuario"].Value = nombreUsuario;

                conexion.Open();

                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    if (lector.Read())
                    {
                        UsuariosMPP mpp = new UsuariosMPP();
                        usuario = mpp.Mapear(lector);
                    }
                }
            }

            return usuario;
        }


        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            string consulta = "SELECT UsuarioId, NombreUsuario, ContrasenaHash, Email, IdiomaPreferido, IntentosFallidos, Activo FROM Seguridad.Usuarios";

            using (SqlConnection cnx = new SqlConnection(cadenaDeConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, cnx))
            {
                cnx.Open();

                UsuariosMPP mpp = new UsuariosMPP();

                using (SqlDataReader lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Usuario usuario = mpp.Mapear(lector);
                        lista.Add(usuario);
                    }
                }
            }

            return lista;
        }

        public void DeshabilitarUsuario(int id)
        {
            string consulta = "UPDATE Seguridad.Usuarios SET Activo = 0 WHERE UsuarioId = @id";

            using (SqlConnection cnx = new SqlConnection(cadenaDeConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, cnx))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int);

                cmd.Parameters["@id"].Value = id;

                cnx.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void HabilitarUsuario(int id)
        {
            string consulta = "UPDATE Seguridad.Usuarios SET Activo = 1 WHERE UsuarioId = @id";

            using (SqlConnection cnx = new SqlConnection(cadenaDeConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, cnx))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int);

                cmd.Parameters["@id"].Value = id;

                cnx.Open();

                cmd.ExecuteNonQuery();
            }
        }

    }
}
