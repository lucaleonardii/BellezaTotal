using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_BE.Servicios
{
    public interface ITratamiento
    {
        int IdTratamiento { get; set; }
        string Nombre { get; set; }

        decimal ObtenerPrecio();
        int ObtenerDuracion();
    }
}
