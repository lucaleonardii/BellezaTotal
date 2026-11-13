using BellezaTotal_BE.Personas;
using BellezaTotal_DAL.Clases;
using System.Collections.Generic;

namespace BellezaTotal_BLL.Clases
{
    public class ProfesionalesBLL
    {
        private ProfesionalesDAL dal = new ProfesionalesDAL();

        public List<Profesional> Listar()
        {
            return dal.Listar();
        }
    }
}
