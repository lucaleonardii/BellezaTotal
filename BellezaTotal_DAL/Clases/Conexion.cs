using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace BellezaTotal_DAL.Clases
{
    public class Conexion
    {
        public static readonly string CadenaDeConexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
    }
}
