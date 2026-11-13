
using BellezaTotal_BE.Excepciones;
using BellezaTotal_BE.Personas;

using BellezaTotal_DAL.Clases;
using System;
using System.Collections.Generic;

using System.ComponentModel;

namespace BellezaTotal_BLL.Clases
{
    public class ClientesBLL
    {
        private ClientesDAL dal = new ClientesDAL();

        public void Alta(Cliente cliente)
        {
            Validar(cliente);

            dal.Alta(cliente);
        }

        public void Baja(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            if (cliente.ClienteId <= 0)
                throw new ExcepcionNegocio("EXP_IdClienteInvalido");

            dal.Baja(cliente);
        }

        public void Modificacion(Cliente cliente, int id)
        {
            if (id <= 0)
                throw new ExcepcionNegocio("EXP_IdClienteInvalido");

            Validar(cliente);

            dal.Modificacion(cliente, id);
        }

        public List<Cliente> Listar()
        {
            return dal.Listar();
        }

        private void Validar(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            if (string.IsNullOrWhiteSpace(cliente.Nombre)) throw new ExcepcionNegocio("EXP_FaltaNombreCliente");

            if (cliente.Nombre.Length > 50) throw new ExcepcionNegocio("EXP_NombreMayor50");

            if (string.IsNullOrWhiteSpace(cliente.Apellido)) throw new ExcepcionNegocio("EXP_FaltaApellidoCliente");

            if (cliente.Apellido.Length > 50) throw new ExcepcionNegocio("EXP_ApellidoMayor50");

            if (string.IsNullOrWhiteSpace(cliente.Email)) throw new ExcepcionNegocio("EXP_FaltaEmailCliente");

            if (cliente.Email.Length > 100) throw new ExcepcionNegocio("EXP_EmailMayor100");

            if (string.IsNullOrWhiteSpace(cliente.Telefono)) throw new ExcepcionNegocio("EXP_FaltaTelefonoCliente");

            if (cliente.Telefono.Length > 20) throw new ExcepcionNegocio("EXP_TelefonoMayor20");


            ValidarLista(cliente.FichaTecnicaAlergias, "Alergia");
            ValidarLista(cliente.FichaTecnicaAfecciones, "Afección");
            ValidarLista(cliente.FichaTecnicaContraindicaciones, "Contraindicación");
        }

        private void ValidarLista(BindingList<string> lista, string nombreCampo)
        {
            if (lista == null)
                return;

            foreach (string valor in lista)
            {
                if (string.IsNullOrWhiteSpace(valor))
                    throw new ArgumentException(
                        nombreCampo + ": no se permiten valores vacíos.");

                if (valor.Length > 100)
                    throw new ArgumentException(
                        nombreCampo + ": no puede superar los 100 caracteres.");
            }
        }
    }
}
