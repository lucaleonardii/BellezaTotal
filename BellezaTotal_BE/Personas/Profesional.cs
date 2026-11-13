namespace BellezaTotal_BE.Personas
{
    public class Profesional
    {
        public int ProfesionalId { get; set; }

        public int UsuarioId { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int? EspecialidadId { get; set; }

        public string Especialidad { get; set; }

        public string NombreCompleto
        {
            get { return Apellido + ", " + Nombre; }
        }
    }
}
