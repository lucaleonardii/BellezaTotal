using BellezaTotal_BE.Agenda;
using BellezaTotal_DAL.Clases;
using System.Collections.Generic;

namespace BellezaTotal_BLL.Clases
{
    public class CabinasBLL
    {
        private CabinasDAL dal = new CabinasDAL();

        public List<Cabina> Listar()
        {
            return dal.Listar();
        }
    }
}
