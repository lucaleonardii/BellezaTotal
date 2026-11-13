using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_BE.Insumos
{
    public class Insumo
    {
        private int _idInsumo;
        public int IdInsumo
        {
            get { return _idInsumo; }
            set { _idInsumo = value; }
        }
        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private int _stockActual;
        public int StockActual
        {
            get { return _stockActual; }
            set { _stockActual = value; }
        }
        public Insumo(int idInsumo, string nombre, int stockActual) 
        { 
            _idInsumo = idInsumo;
            _nombre = nombre;
            _stockActual = stockActual;
        }
        public Insumo() { }
    }
}
