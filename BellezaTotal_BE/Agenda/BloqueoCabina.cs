using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_BE.Agenda
{
    public class BloqueoCabina
    {
        private string _motivo;
        private int _bloqueoId;
        private string _cabinaBloqueadaId;
        private DateTime _fechaDesde;
        private DateTime _fechaHasta;
        public string Motivo
        {
            get { return _motivo; }
            set { _motivo = value; }
        }
        public int BloqueoId
        {
            get { return _bloqueoId; }
            set { _bloqueoId = value; }
        }
        public string CabinaBloqueadaID
        {
            get { return _cabinaBloqueadaId; }
            set { _cabinaBloqueadaId = value; }
        }
        public DateTime FechaDesde
        {
            get { return _fechaDesde; }
            set { _fechaDesde = value; }
        }
        public DateTime FechaHasta 
        { 
            get {return _fechaHasta; }
            set {_fechaHasta = value; }
        }
        public BloqueoCabina(string motivo, int bloqueoId, string cabinaBloqueadaId, DateTime fechaDesde, DateTime fechaHasta) 
        { 
            _motivo = motivo;
            _bloqueoId = bloqueoId;
            _cabinaBloqueadaId = cabinaBloqueadaId; 
            _fechaDesde = fechaDesde;
            _fechaHasta = fechaHasta;
        }
    }
}
