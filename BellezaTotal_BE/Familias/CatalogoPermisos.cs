using System.Collections.Generic;

namespace BellezaTotal_BE.Familias
{
    
    public class CatalogoPermisos
    {
        public List<Patente> Patentes { get; set; } = new List<Patente>();
        public List<Familia> Familias { get; set; } = new List<Familia>();
    }
}