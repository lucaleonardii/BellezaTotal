using BellezaTotal_BE.Familias;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BellezaTotal_MPP
{
    public class FamiliasMPP
    {
        public CatalogoPermisos ArmarCatalogo(
            DataTable tablaPatentes, DataTable tablaFamilias,
            DataTable tablaFamiliaPatente, DataTable tablaFamiliaFamilia)
        {
            Dictionary<int, Patente> patentePorId = new Dictionary<int, Patente>();
            foreach (DataRow filaPatente in tablaPatentes.Rows)
            {
                int patenteId = (int)filaPatente["PatenteId"];
                patentePorId[patenteId] = new Patente { PermisoId = patenteId, Nombre = (string)filaPatente["Nombre"] };
            }

            Dictionary<int, Familia> familiaPorId = new Dictionary<int, Familia>();
            foreach (DataRow filaFamilia in tablaFamilias.Rows)
            {
                int familiaId = (int)filaFamilia["FamiliaId"];
                familiaPorId[familiaId] = new Familia { PermisoId = familiaId, Nombre = (string)filaFamilia["Nombre"] };
            }

            foreach (DataRow filaRelacion in tablaFamiliaPatente.Rows)
            {
                Familia familia = familiaPorId[(int)filaRelacion["FamiliaId"]];
                Patente patente = patentePorId[(int)filaRelacion["PatenteId"]];
                familia.Agregar(patente);
            }

            foreach (DataRow filaRelacion in tablaFamiliaFamilia.Rows)
            {
                Familia familiaPadre = familiaPorId[(int)filaRelacion["FamiliaPadreId"]];
                Familia familiaHija = familiaPorId[(int)filaRelacion["FamiliaHijaId"]];
                familiaPadre.Agregar(familiaHija);
            }

            return new CatalogoPermisos
            {
                Patentes = patentePorId.Values.OrderBy(patente => patente.Nombre).ToList(),
                Familias = familiaPorId.Values.OrderBy(familia => familia.Nombre).ToList()
            };
        }

        public List<string> ArmarNombres(DataTable tablaNombres)
        {
            List<string> nombres = new List<string>();

            foreach (DataRow filaNombre in tablaNombres.Rows)
            {
                nombres.Add((string)filaNombre["Nombre"]);
            }

            return nombres;
        }
    }
}