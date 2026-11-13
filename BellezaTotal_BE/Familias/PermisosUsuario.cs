using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_BE.Familias
{
    public class PermisosUsuario//
    {
        public List<Permiso> Asignados { get; } = new List<Permiso>();
        public List<Permiso> Denegados { get; } = new List<Permiso>();

    }
}
