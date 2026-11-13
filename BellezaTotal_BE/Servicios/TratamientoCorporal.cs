namespace BellezaTotal_BE.Servicios
{
    public class TratamientoCorporal : Servicio
    {
        public override string Tipo { get { return "CORPORAL"; } }

        public TratamientoCorporal()
        {
        }

        public TratamientoCorporal(int idServicio, string nombre, string descripcion,
                  int? especialidadId, decimal precio, int duracion)
            : base(idServicio, nombre, descripcion, especialidadId, precio, duracion)
        {
        }
    }
}