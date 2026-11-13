using BellezaTotal_BE.Personas;
using System;
using System.Collections.Generic;
using System.Data;

namespace BellezaTotal_MAPPER.Clases
{
    public class ProveedorMPP
    {
        public Proveedor Mapear(DataRow fila)
        {
            Proveedor proveedor = new Proveedor();

            proveedor.ProveedorId = Convert.ToInt32(fila["ProveedorId"]);
            proveedor.Nombre = fila["Nombre"].ToString();
            proveedor.CUIT = fila["CUIT"].ToString();
            proveedor.Email = fila["Email"].ToString();
            proveedor.Telefono = fila["Telefono"] == DBNull.Value ? string.Empty : fila["Telefono"].ToString();
            proveedor.Activo = Convert.ToBoolean(fila["Activo"]);

            return proveedor;
        }

        public List<Proveedor> MapearLista(DataTable tabla)
        {
            List<Proveedor> lista = new List<Proveedor>();

            foreach (DataRow fila in tabla.Rows)
                lista.Add(Mapear(fila));

            return lista;
        }
    }
}