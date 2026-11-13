using BellezaTotal_BE.Excepciones;
using BellezaTotal_BE.Personas;
using BellezaTotal_DAL.Clases;
using BellezaTotal_SEC.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_BLL.Clases
{
    public class UsuariosBLL
    {
        private UsuariosDAL dal = new UsuariosDAL();
        public void DeshabilitarUsuario(int id)
        {
            if (id == null) throw new ExcepcionNegocio("EXP_IdInvalida");
            dal.DeshabilitarUsuario(id);
        }

        public void HabilitarUsuario(int id)
        {
            if (id == null) throw new ExcepcionNegocio("EXP_IdInvalida");
            dal.HabilitarUsuario(id);
        }
        public bool IniciarSesion(string usuario, string clave)
        {
            AdministradorDeSesion ads = AdministradorDeSesion.Instancia;
            if (ads.IniciarSesion(usuario, clave)) return true;
            else throw new Exception();
        }

        public void Alta(UsuariosDAL usuario)
        {
            
        }

        public List<Usuario> Listar() => dal.Listar();

        public DataTable ListarParaDGV()
        {
            List<Usuario> lista = dal.Listar();

            DataTable dt = ToDataTable(lista);
            dt.Columns.Remove("ContraseñaHash");
            dt.Columns["Estado"].SetOrdinal(0);

            return dt;
        }


    
        private DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            
            foreach (PropertyInfo prop in props)
            {
                Type type = prop.PropertyType;

                
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    type = Nullable.GetUnderlyingType(type);
                }

                dataTable.Columns.Add(prop.Name, type);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null) ?? DBNull.Value;
                }
                dataTable.Rows.Add(values);
            }
            
            return dataTable;
        }
    }

}

