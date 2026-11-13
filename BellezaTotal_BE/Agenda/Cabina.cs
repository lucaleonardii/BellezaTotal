namespace BellezaTotal_BE.Agenda
{
    public class Cabina
    {
        public const string EstadoDisponible = "Disponible";
        public const string EstadoMantenimiento = "Mantenimiento";

        private string _estado;
        private int _cabinaId;
        private int _numeroCabina;

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public int CabinaId
        {
            get { return _cabinaId; }
            set { _cabinaId = value; }
        }

        public int NumeroCabina
        {
            get { return _numeroCabina; }
            set { _numeroCabina = value; }
        }
    }
}
