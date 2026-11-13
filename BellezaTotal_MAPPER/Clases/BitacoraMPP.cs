using BellezaTotal_BE.Auditoria;
using System;
using System.Collections.Generic;
using System.Data;

namespace BellezaTotal_MPP
{
    public class BitacoraMPP
    {
        public List<Bitacora> ArmarBitacoras(DataTable tablaBitacora)
        {
            List<Bitacora> registros = new List<Bitacora>();

            foreach (DataRow filaBitacora in tablaBitacora.Rows)
            {
                Bitacora registro = new Bitacora
                {
                    BitacoraId = (int)filaBitacora["BitacoraId"],
                    FechaHora = (DateTime)filaBitacora["FechaHora"],
                    UsuarioId = filaBitacora["UsuarioId"] == DBNull.Value
                        ? (int?)null
                        : (int)filaBitacora["UsuarioId"],
                    NombreUsuario = filaBitacora["NombreUsuario"] == DBNull.Value
                        ? null
                        : (string)filaBitacora["NombreUsuario"],
                    Severidad = ConvertirSeveridad((string)filaBitacora["Severidad"]),
                    Accion = (string)filaBitacora["Accion"],
                    Descripcion = filaBitacora["Descripcion"] == DBNull.Value
                        ? null
                        : (string)filaBitacora["Descripcion"]
                };

                registros.Add(registro);
            }

            return registros;
        }

        // En la base se guarda 'INFO', 'WARNING' o 'ERROR'. El true ignora mayúsculas y minúsculas
        private SeveridadBitacora ConvertirSeveridad(string textoSeveridad)
        {
            return (SeveridadBitacora)Enum.Parse(typeof(SeveridadBitacora), textoSeveridad, true);
        }
    }
}