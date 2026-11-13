
using BellezaTotal_BE.Personas;
using System;
using System.Collections.Generic;
using System.Data;

namespace BellezaTotal_MAPPER.Clases
{
    public class ClienteMPP
    {
        public object[] ObtenerValores(Cliente cliente)
        {
            return new object[]
            {
                cliente.ClienteId,
                cliente.Nombre,
                cliente.Apellido,
                cliente.DNI,
                cliente.Email,
                cliente.Telefono,
                cliente.Activo
            };
        }

        public Cliente Mapear(
            DataRow fila,
            DataTable alergias,
            DataTable afecciones,
            DataTable contraindicaciones)
        {
            Cliente cliente = new Cliente();

            cliente.ClienteId = Convert.ToInt32(fila["ClienteId"]);
            cliente.Nombre = fila["Nombre"].ToString();
            cliente.Apellido = fila["Apellido"].ToString();
            cliente.DNI = Convert.ToInt32(fila["DNI"]);
            cliente.Email = fila["Email"].ToString();
            cliente.Telefono = fila["Telefono"].ToString();
            cliente.Activo = Convert.ToBoolean(fila["Activo"]);

            int id = cliente.ClienteId;

            
            foreach (DataRow registro in alergias.Rows)
            {
                if (Convert.ToInt32(registro["ClienteId"]) == id)
                {
                    cliente.FichaTecnicaAlergias.Add(
                        registro["Alergia"].ToString());
                }
            }


            foreach (DataRow registro in afecciones.Rows)
            {
                if (Convert.ToInt32(registro["ClienteId"]) == id)
                {
                    cliente.FichaTecnicaAfecciones.Add(
                        registro["Afeccion"].ToString());
                }
            }

            foreach (DataRow registro in contraindicaciones.Rows)
            {
                if (Convert.ToInt32(registro["ClienteId"]) == id)
                {
                    cliente.FichaTecnicaContraindicaciones.Add(
                        registro["Contraindicacion"].ToString());
                }
            }

            return cliente;
        }

        public List<Cliente> MapearLista(
            DataTable clientes,
            DataTable alergias,
            DataTable afecciones,
            DataTable contraindicaciones)
        {
            List<Cliente> lista = new List<Cliente>();

            foreach (DataRow fila in clientes.Rows)
            {
                Cliente cliente = Mapear(
                    fila,
                    alergias,
                    afecciones,
                    contraindicaciones);

                lista.Add(cliente);
            }

            return lista;
        }
    }
}
