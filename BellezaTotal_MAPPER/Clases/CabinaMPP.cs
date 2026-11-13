using BellezaTotal_BE.Agenda;
using System;
using System.Collections.Generic;
using System.Data;

namespace BellezaTotal_MAPPER.Clases
{
    public class CabinaMPP
    {
        public Cabina Mapear(DataRow fila)
        {
            Cabina cabina = new Cabina();

            cabina.CabinaId = Convert.ToInt32(fila["CabinaId"]);
            cabina.NumeroCabina = Convert.ToInt32(fila["NumeroCabina"]);
            cabina.Estado = fila["Estado"].ToString();

            return cabina;
        }

        public List<Cabina> MapearLista(DataTable tabla)
        {
            List<Cabina> lista = new List<Cabina>();

            foreach (DataRow fila in tabla.Rows)
                lista.Add(Mapear(fila));

            return lista;
        }

        public List<BloqueoCabina> MapearBloqueos(DataTable tabla)
        {
            List<BloqueoCabina> lista = new List<BloqueoCabina>();

            foreach (DataRow fila in tabla.Rows)
            {
                lista.Add(new BloqueoCabina(
                    fila["Motivo"].ToString(),
                    Convert.ToInt32(fila["BloqueoId"]),
                    Convert.ToInt32(fila["CabinaId"]).ToString(),
                    Convert.ToDateTime(fila["FechaDesde"]),
                    Convert.ToDateTime(fila["FechaHasta"])));
            }

            return lista;
        }
    }
}
