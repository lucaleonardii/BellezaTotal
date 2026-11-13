using System;
using System.Collections.Generic;
using System.Linq;
using BellezaTotal_BE.Excepciones;

namespace BellezaTotal_BE.Servicios
{
   
    public class PlanEstetico : Servicio
    {
        private readonly List<Servicio> _servicios = new List<Servicio>();

        public decimal Descuento { get; set; }

        public IReadOnlyList<Servicio> Servicios
        {
            get { return _servicios; }
        }

        public override string Tipo { get { return "PLAN"; } }

        public PlanEstetico()
        {
        }

        public PlanEstetico(int idServicio, string nombre, string descripcion, decimal descuento)
            : base(idServicio, nombre, descripcion, null, 0m, 0)
        {
            Descuento = descuento;
        }

        public void AgregarServicio(Servicio servicio)
        {
            if (servicio == null) throw new ArgumentNullException(nameof(servicio));

            if (EsMismo(this, servicio)) throw new ExcepcionNegocio("EXP_PlanCiclico");

            PlanEstetico plan = servicio as PlanEstetico;
            if (plan != null && plan.Contiene(this)) throw new ExcepcionNegocio("EXP_PlanCiclico");

            if (_servicios.Any(s => EsMismo(s, servicio)))
                throw new ExcepcionNegocio("EXP_ServicioRepetidoEnPlan");

            _servicios.Add(servicio);
        }

        public bool EliminarServicio(Servicio servicio)
        {
            if (servicio == null) return false;
            return _servicios.RemoveAll(s => EsMismo(s, servicio)) > 0;
        }

        // Búsqueda recursiva en todo el árbol
        public bool Contiene(Servicio servicio)
        {
            foreach (Servicio hijo in _servicios)
            {
                if (EsMismo(hijo, servicio)) return true;

                PlanEstetico subPlan = hijo as PlanEstetico;
                if (subPlan != null && subPlan.Contiene(servicio)) return true;
            }
            return false;
        }

        public override decimal ObtenerPrecio()
        {
            decimal total = 0m;
            foreach (Servicio s in _servicios) total += s.ObtenerPrecio();

            return Math.Round(total * (100m - Descuento) / 100m, 2);
        }

        public override int ObtenerDuracion()
        {
            int total = 0;
            foreach (Servicio s in _servicios) total += s.ObtenerDuracion();

            return total;
        }


        private static bool EsMismo(Servicio a, Servicio b)
        {
            return ReferenceEquals(a, b) || (a.IdServicio != 0 && a.IdServicio == b.IdServicio);
        }
    }
}