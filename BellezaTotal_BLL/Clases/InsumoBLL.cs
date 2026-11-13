using BellezaTotal_BE.Insumos;
using BellezaTotal_DAL.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BellezaTotal_BE.Excepciones;

namespace BellezaTotal_BLL.Clases
{
    public class InsumoBLL
    {
        private InsumoDAL dal = new InsumoDAL();

        public void Alta(Insumo insumo)
        {
            Validar(insumo);
            dal.Alta(insumo);
        }

        public void Baja(Insumo insumo)
        {
            if (insumo == null)
                throw new ExcepcionNegocio("EXP_InsumoNull");

            if (insumo.IdInsumo <= 0)
                throw new ExcepcionNegocio("EXP_IdInvalido");

            dal.Baja(insumo);
        }

        public void Modificacion(Insumo insumo, int id)
        {
            if (id <= 0)
                throw new ExcepcionNegocio("EXP_IdInvalido");

            Validar(insumo);
            dal.Modificacion(insumo, id);
        }

        public List<Insumo> Listar()
        {
            return dal.Listar();
        }

        private void Validar(Insumo insumo)
        {
            if (insumo == null)
                throw new ExcepcionNegocio("EXP_InsumoNull");

            if (string.IsNullOrWhiteSpace(insumo.Nombre))
                throw new ExcepcionNegocio("EXP_FaltaNombreInsumo");

            if (insumo.Nombre.Length > 50)
                throw new ExcepcionNegocio("EXP_NombreInsumoMayor50");

            if (insumo.StockActual < 0)
                throw new ExcepcionNegocio("EXP_StockInsumoNegativo");
        }
    }
}
