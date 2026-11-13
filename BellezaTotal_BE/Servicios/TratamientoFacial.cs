namespace BellezaTotal_BE.Servicios
{
    public class TratamientoFacial : Servicio
    {
        public override string Tipo { get { return "FACIAL"; } }

        public TratamientoFacial()
        {
        }

        public TratamientoFacial(int idServicio, string nombre, string descripcion,
                  int? especialidadId, decimal precio, int duracion)
            : base(idServicio, nombre, descripcion, especialidadId, precio, duracion)
        {
        }
    }
}