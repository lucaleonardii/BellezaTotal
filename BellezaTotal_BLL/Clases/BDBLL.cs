using BellezaTotal_BE.Excepciones;
using BellezaTotal_DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellezaTotal_BLL.Clases
{
    public class BDBLL
    {
        private readonly BDDAL dal = new BDDAL();

        public void CrearBackup(string nombreArchivo, string ruta)
        {
            if (string.IsNullOrEmpty(nombreArchivo)) throw new ExcepcionNegocio("EXP_NombreArchivoNull");
            if (string.IsNullOrEmpty(ruta)) throw new ExcepcionNegocio("EXP_RutaNull");

            if (nombreArchivo.Length > 50) throw new ExcepcionNegocio("EXP_NombreArchivoLargo");
            if (ruta.Length > 256) throw new ExcepcionNegocio("EXP_RutaLarga");


            dal.CrearBackup(nombreArchivo, ruta);
        }

        public void RestaurarBackup(string ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta)) throw new ExcepcionNegocio("EXP_RutaNull");

            bool esBak = string.Equals(Path.GetExtension(ruta), ".bak", StringComparison.OrdinalIgnoreCase);

            if (!esBak || !File.Exists(ruta)) throw new ExcepcionNegocio("EXP_ArchivoBackupInvalido");

            dal.RestaurarBackup(ruta);
        }
    }
}
