using BellezaTotal_BE.Servicios;
using System;
using System.Collections.Generic;
using System.Data;

namespace BellezaTotal_MAPPER.Clases
{
    public class ServicioMPP
    {
        // Convierte las filas de Negocio.Servicios y Negocio.Plan_Servicio en el catálogo,
        // armando el árbol Composite (los planes contienen servicios u otros planes).
        public List<Servicio> MapearCatalogo(DataTable servicios, DataTable relaciones)
        {
            Dictionary<int, Servicio> porId = new Dictionary<int, Servicio>();

            foreach (DataRow fila in servicios.Rows)
            {
                Servicio servicio = Crear(fila);
                porId[servicio.IdServicio] = servicio;
            }

            HashSet<int> armados = new HashSet<int>();

            foreach (Servicio servicio in porId.Values)
            {
                PlanEstetico plan = servicio as PlanEstetico;

                if (plan != null)
                    ArmarPlan(plan, porId, relaciones, armados, new HashSet<int>());
            }

            List<Servicio> lista = new List<Servicio>(porId.Values);
            lista.Sort();

            return lista;
        }

        private void ArmarPlan(
            PlanEstetico plan,
            Dictionary<int, Servicio> porId,
            DataTable relaciones,
            HashSet<int> armados,
            HashSet<int> enProceso)
        {
            if (armados.Contains(plan.IdServicio)) return;

            // Defensa ante datos circulares en la base: no se vuelve a entrar en un plan en proceso
            if (!enProceso.Add(plan.IdServicio)) return;

            foreach (DataRow relacion in relaciones.Select("PlanId = " + plan.IdServicio))
            {
                int hijoId = Convert.ToInt32(relacion["ServicioId"]);

                Servicio hijo;
                if (!porId.TryGetValue(hijoId, out hijo)) continue;

                PlanEstetico subPlan = hijo as PlanEstetico;

                if (subPlan != null)
                    ArmarPlan(subPlan, porId, relaciones, armados, enProceso);

                plan.AgregarServicio(hijo);
            }

            enProceso.Remove(plan.IdServicio);
            armados.Add(plan.IdServicio);
        }

        private Servicio Crear(DataRow fila)
        {
            int id = Convert.ToInt32(fila["ServicioId"]);
            string tipo = fila["Tipo"].ToString();
            string nombre = fila["Nombre"].ToString();
            string descripcion = fila["Descripcion"] == DBNull.Value ? null : fila["Descripcion"].ToString();
            int? especialidadId = fila["EspecialidadId"] == DBNull.Value
                ? (int?)null
                : Convert.ToInt32(fila["EspecialidadId"]);
            decimal precio = Convert.ToDecimal(fila["Precio"]);
            int duracion = Convert.ToInt32(fila["Duracion"]);

            Servicio servicio;

            switch (tipo)
            {
                case "PLAN":
                    servicio = new PlanEstetico(id, nombre, descripcion, Convert.ToDecimal(fila["Descuento"]));
                    break;
                case "CORPORAL":
                    servicio = new TratamientoCorporal(id, nombre, descripcion, especialidadId, precio, duracion);
                    break;
                case "FACIAL":
                    servicio = new TratamientoFacial(id, nombre, descripcion, especialidadId, precio, duracion);
                    break;
                default:
                    servicio = new ServicioEstetico(id, nombre, descripcion, especialidadId, precio, duracion);
                    break;
            }

            servicio.Activo = Convert.ToBoolean(fila["Activo"]);

            return servicio;
        }
    }
}
