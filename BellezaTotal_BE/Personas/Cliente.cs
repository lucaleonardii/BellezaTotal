namespace BellezaTotal_BE.Personas
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
        public BindingList<string> FichaTecnicaAlergias { get; set; }
        public BindingList<string> FichaTecnicaContraindicaciones { get; set; }
        public BindingList<string> FichaTecnicaAfecciones { get; set; }

        public Cliente()
        {
            FichaTecnicaAlergias = new BindingList<string>();
            FichaTecnicaContraindicaciones = new BindingList<string>();
            FichaTecnicaAfecciones = new BindingList<string>();
        }
    }
}