using BellezaTotal_BE.Idiomas;
using System.Collections.Generic;
using System.Data;

namespace BellezaTotal_MAPPER.Clases
{
    public class IdiomaMPP
    {
        public List<IdiomaSistema> ArmarIdiomas(DataTable tablaIdiomas)
        {
            List<IdiomaSistema> idiomas = new List<IdiomaSistema>();

            foreach (DataRow filaIdioma in tablaIdiomas.Rows)
            {
                idiomas.Add(new IdiomaSistema((string)filaIdioma["Codigo"], (string)filaIdioma["Nombre"]));
            }

            return idiomas;
        }

        public List<Leyenda> ArmarLeyendas(DataTable tablaLeyendas)
        {
            List<Leyenda> leyendas = new List<Leyenda>();

            foreach (DataRow filaLeyenda in tablaLeyendas.Rows)
            {
                leyendas.Add(new Leyenda
                {
                    Clave = (string)filaLeyenda["Clave"],
                    Texto = (string)filaLeyenda["Texto"]
                });
            }

            return leyendas;
        }
    }
}