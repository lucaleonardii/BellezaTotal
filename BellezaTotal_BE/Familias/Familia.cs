using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_BE.Familias
{
    public sealed class Familia : Permiso//
    {
        private List<Permiso> _hijos = new List<Permiso>();
        public IReadOnlyList<Permiso> Hijos => _hijos;

        public void Agregar(Permiso permisoHijo)
        {
            if (permisoHijo == null) throw new ArgumentNullException("El permiso especificado es nulo");
            if (permisoHijo is Familia familiaHija)
            {
                bool esLaMismaFamilia = EsLaMismaFamilia(familiaHija, this);

                if (esLaMismaFamilia || familiaHija.ContieneFamilia(this)) throw new InvalidOperationException("Operación inválida: se detectó una relación circular en el rol");
            }

            _hijos.Add(permisoHijo);
        }

        public void Quitar(Permiso quitado) => _hijos.Remove(quitado);

        public bool ContieneFamilia(Familia familiaBuscada)
        {
            foreach(Permiso permisoHijo in _hijos)
            {
                if (permisoHijo is Familia familiaHija)
                {
                    if (EsLaMismaFamilia(familiaHija, familiaBuscada)) return true;
                    if (familiaHija.ContieneFamilia(familiaBuscada)) return true;
                }
            }
            return false;
        }

        public override IEnumerable<Patente> ObtenerPatentes() => _hijos.SelectMany(hijo => hijo.ObtenerPatentes());

        private static bool EsLaMismaFamilia(Familia primera, Familia segunda)
        {
            if (ReferenceEquals(primera, segunda)) return true;
            return primera.PermisoId != 0 && primera.PermisoId == segunda.PermisoId;
        }
    }
}
