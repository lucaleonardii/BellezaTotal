using BellezaTotal_BE.Excepciones;
using BellezaTotal_BE.Servicios;
using BellezaTotal_DAL.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace BellezaTotal_BLL.Clases
{
    public class ServiciosBLL
    {
        private ServiciosDAL dal = new ServiciosDAL();

        // Servicios y planes habilitados
        public List<Servicio> Listar()
        {
            return dal.Listar();
        }
        public void Modificacion(int id, string tipo, string nombre, string descripcion, string especialidadNombre, decimal precio, int duracion)
        {
            dal.Modificacion(id, tipo, nombre, descripcion, especialidadNombre, precio, duracion);
        }
        public void Alta(string tipo, string nombre, string descripcion, string especialidadNombre, string precio, string duracion)
        {
            if (tipo != "CORPORAL" && tipo != "FACIAL" && tipo != "SERVICIO") throw new ExcepcionNegocio("EXP_ServicioInvalido");

            Servicio servicio = null;

            if (tipo == "CORPORAL") servicio = new TratamientoCorporal();
            if (tipo == "FACIAL") servicio = new TratamientoFacial();
            if (tipo == "SERVICIO") servicio = new ServicioEstetico();

            if (servicio == null) throw new ExcepcionNegocio("EXP_ServicioInvalido");


            dal.Alta(tipo, nombre, descripcion, especialidadNombre, Convert.ToDecimal(precio), Convert.ToInt32(duracion));
        }

        public List<string> ObtenerEspecialidades()
        {
            List<string> especialidades = dal.ObtenerEspecialidades();

            return especialidades;
        }

        public string ObtenerNombreEspecialidadPorId(int? id)
        {
            string nombre = dal.ObtenerNombreEspecialidadPorId(id);
            return nombre;
        }
    }
}
