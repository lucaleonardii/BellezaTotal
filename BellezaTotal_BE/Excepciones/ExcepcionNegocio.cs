using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_BE.Excepciones
{
    public class ExcepcionNegocio : Exception
    {
        public string Codigo { get; private set; }


        public ExcepcionNegocio(string codigo) : base(codigo)
        {
            Codigo = codigo;
        }
    }
}
