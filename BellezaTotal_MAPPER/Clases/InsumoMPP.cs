using BellezaTotal_BE.Insumos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_MAPPER.Clases
{
    public class InsumoMPP
    {
        public Insumo Mapear(DataRow row)
        {
            Insumo insumo = new Insumo();

            insumo.IdInsumo = Convert.ToInt32(row["InsumoId"]);
            insumo.Nombre = row["Nombre"].ToString();
            insumo.StockActual = Convert.ToInt32(row["StockActual"]);

            return insumo;
        }

        public object[] ObtenerValores(Insumo insumo)
        {
            return new object[]
            {
                insumo.IdInsumo,
                insumo.Nombre,
                insumo.StockActual
            };
        }
    }
}
