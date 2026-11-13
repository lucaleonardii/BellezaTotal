namespace BellezaTotal_BE.Servicios
{
    public class ServicioEstetico : Servicio
    {
        public override string Tipo { get { return "SERVICIO"; } }

        public ServicioEstetico()
        {
        }

        public ServicioEstetico(int idServicio, string nombre, string descripcion, int? especialidadId, decimal precio, int duracion)
            : base(idServicio, nombre, descripcion, especialidadId, precio, duracion)
        {
        }
    }
}