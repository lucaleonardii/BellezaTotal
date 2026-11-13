using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_BE.Familias
{
    public class Patente : Permiso//
    {
        public override IEnumerable<Patente> ObtenerPatentes()
        {
            yield return this;
        }
    }
}
