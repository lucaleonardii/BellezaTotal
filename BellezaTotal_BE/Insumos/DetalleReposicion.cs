using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_BE.Insumos
{
    public class DetalleReposicion
    {
        public Insumo InsumoReStock { get; set; }
        private int _cantidadSolicitada;
        public int CantidadSolicitada 
        { 
            get {return _cantidadSolicitada;}
            set { _cantidadSolicitada = value;}
        }
        public DetalleReposicion(Insumo insumoReStock, int cantidadSolicitada) 
        { 
            InsumoReStock = insumoReStock;
            _cantidadSolicitada= cantidadSolicitada;
        }
    }
}
