using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BellezaTotal_BE.Idiomas
{
    public class IdiomaSistema
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public IdiomaSistema(string codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
        }
    }
}
