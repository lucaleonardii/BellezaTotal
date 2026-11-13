using BellezaTotal_BE.Personas;
using System;
using System.Collections.Generic;
using System.Data;

namespace BellezaTotal_MAPPER.Clases
{
    public class ProfesionalMPP
    {
        public Profesional Mapear(DataRow fila)
        {
            Profesional profesional = new Profesional();

            profesional.ProfesionalId = Convert.ToInt32(fila["ProfesionalId"]);
            profesional.UsuarioId = fila["UsuarioId"] == DBNull.Value ? 0 : Convert.ToInt32(fila["UsuarioId"]);
            profesional.Nombre = fila["Nombre"].ToString();
            profesional.Apellido = fila["Apellido"].ToString();
            profesional.EspecialidadId = fila["EspecialidadId"] == DBNull.Value
                ? (int?)null
                : Convert.ToInt32(fila["EspecialidadId"]);
            profesional.Especialidad = fila["Especialidad"] == DBNull.Value ? null : fila["Especialidad"].ToString();

            return profesional;
        }

        public List<Profesional> MapearLista(DataTable tabla)
        {
            List<Profesional> lista = new List<Profesional>();

            foreach (DataRow fila in tabla.Rows)
                lista.Add(Mapear(fila));

            return lista;
        }
    }
}
