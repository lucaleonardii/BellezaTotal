namespace BellezaTotal_BE.Personas
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }

        public string Nombre { get; set; }

        public string CUIT { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public bool Activo { get; set; }

        public Proveedor()
        {
            Activo = true;
        }
    }
}