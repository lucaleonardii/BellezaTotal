using BellezaTotal_BE.Personas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_MAPPER.Clases
{
    public class UsuariosMPP
    {
        public object[] ObtenerValores(Usuario usuario)
        {
            return new object[]
            {
                usuario.UsuarioId,
                usuario.NombreUsuario,
                usuario.ContraseñaHash,
                usuario.Email,
                usuario.IdiomaPreferido,
                usuario.IntentosFallidos,
                Convert.ToInt32(usuario.Estado),
            };
        }

        public Usuario Mapear(SqlDataReader lector)
        {
            int UsuarioId = Convert.ToInt32(lector["UsuarioId"]);
            string NombreUsuario = lector["NombreUsuario"].ToString();
            string ContraseñaHash = lector["ContrasenaHash"].ToString();
            string Email = lector["Email"].ToString();
            string IdiomaPreferido = lector["IdiomaPreferido"].ToString();
            int IntentosFallidos = Convert.ToInt32(lector["IntentosFallidos"]);
            bool Estado = Convert.ToBoolean(lector["Activo"]);

            return new Usuario(UsuarioId, NombreUsuario, ContraseñaHash, Email, IdiomaPreferido, IntentosFallidos, Estado);

        }
    }
}
