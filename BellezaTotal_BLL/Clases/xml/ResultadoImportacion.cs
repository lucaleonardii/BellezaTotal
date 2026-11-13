using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_BLL.Clases.xml
{
    public class ResultadoImportacion
    {
        public int Importados { get; set; }
        public List<ErrorImportacion> Errores { get; private set; }

        public ResultadoImportacion()
        {
            Errores = new List<ErrorImportacion>();
        }
    }

}
