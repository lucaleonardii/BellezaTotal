using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_DAL.Interfaces
{
    public interface IABMC<T>
    {
        void Alta(T t);

        void Baja(T t);

        void Modificacion(T t, int id);

        //T Consulta(int id);

        List<T> Listar();
    }
}
