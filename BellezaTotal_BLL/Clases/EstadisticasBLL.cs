using BellezaTotal_BE.Agenda;
using BellezaTotal_BE.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BellezaTotal_BLL.Clases
{
    public class EstadisticasBLL
    {
        private TurnosBLL turnosBll = new TurnosBLL();

        
        public List<KeyValuePair<string, int>> ServiciosMasSolicitados(DateTime desde, DateTime hasta, int cantidadMaxima = 10)
        {
            return TurnosDelPeriodo(desde, hasta)
                .Where(t => t.Servicio != null)
                .GroupBy(t => t.Servicio.Nombre)
                .Select(g => new KeyValuePair<string, int>(g.Key, g.Count()))
                .OrderByDescending(p => p.Value)
                .ThenBy(p => p.Key)
                .Take(cantidadMaxima)
                .ToList();
        }

       
        public List<KeyValuePair<int, double>> UsoDeCabinas(DateTime desde, DateTime hasta)
        {
            List<Turno> turnos = TurnosDelPeriodo(desde, hasta);

            int minutosTotales = turnos.Sum(t => t.DuracionMinutos);

            if (minutosTotales == 0)
                return new List<KeyValuePair<int, double>>();

            return turnos
                .GroupBy(t => t.Cabina.NumeroCabina)
                .Select(g => new KeyValuePair<int, double>(
                    g.Key,
                    Math.Round(g.Sum(t => t.DuracionMinutos) * 100.0 / minutosTotales, 1)))
                .OrderBy(p => p.Key)
                .ToList();
        }

        private List<Turno> TurnosDelPeriodo(DateTime desde, DateTime hasta)
        {
            if (desde.Date > hasta.Date)
                throw new ExcepcionNegocio("EXP_RangoFechasInvalido");

            
            DateTime inicio = desde.Date;
            DateTime fin = hasta.Date.AddDays(1);

            return turnosBll.Listar()
                .Where(t => t.Estado != EstadoTurno.Cancelado
                         && t.FechaSesion >= inicio
                         && t.FechaSesion < fin)
                .ToList();
        }
    }
}