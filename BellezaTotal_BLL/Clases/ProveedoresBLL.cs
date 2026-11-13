using BellezaTotal_BE.Auditoria;
using BellezaTotal_BE.Excepciones;
using BellezaTotal_BE.Personas;
using BellezaTotal_DAL.Clases;
using BellezaTotal_SEC.Clases;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BellezaTotal_BLL.Clases
{
    public class ProveedoresBLL
    {
        private readonly ProveedoresDAL dal = new ProveedoresDAL();
        private readonly BitacoraBLL bitacora = new BitacoraBLL();

        private static readonly Regex RegexEmail = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+\z", RegexOptions.Compiled);
        private static readonly Regex RegexTelefono = new Regex(@"^[0-9+\-\s()]{6,20}\z", RegexOptions.Compiled);

        public void Alta(Proveedor proveedor)
        {
            Normalizar(proveedor);
            Validar(proveedor, 0);

            dal.Alta(proveedor);

            bitacora.Registrar(
                AccionesBitacora.AltaProveedor,
                SeveridadBitacora.Info,
                proveedor.Nombre + " (CUIT " + proveedor.CUIT + ")");
        }

        public void Modificacion(Proveedor proveedor, int id)
        {
            if (id <= 0) throw new ExcepcionNegocio("EXP_ProveedorInexistente");

            Normalizar(proveedor);
            Validar(proveedor, id);

            dal.Modificacion(proveedor, id);

            bitacora.Registrar(
                AccionesBitacora.ModificacionProveedor,
                SeveridadBitacora.Info,
                proveedor.Nombre + " (CUIT " + proveedor.CUIT + ")");
        }

        public void Baja(Proveedor proveedor)
        {
            if (proveedor == null) throw new ArgumentNullException(nameof(proveedor));
            if (proveedor.ProveedorId <= 0) throw new ExcepcionNegocio("EXP_ProveedorInexistente");

            dal.Baja(proveedor);

            bitacora.Registrar(
                AccionesBitacora.BajaProveedor,
                SeveridadBitacora.Info,
                proveedor.Nombre + " (CUIT " + proveedor.CUIT + ")");
        }

        public List<Proveedor> Listar()
        {
            return dal.Listar();
        }

        private void Normalizar(Proveedor proveedor)
        {
            if (proveedor == null) throw new ArgumentNullException(nameof(proveedor));

            proveedor.Nombre = (proveedor.Nombre ?? string.Empty).Trim();
            proveedor.CUIT = (proveedor.CUIT ?? string.Empty).Trim();
            proveedor.Email = (proveedor.Email ?? string.Empty).Trim();
            proveedor.Telefono = (proveedor.Telefono ?? string.Empty).Trim();
        }

        private void Validar(Proveedor proveedor, int idAExcluir)
        {
            if (proveedor.Nombre.Length == 0) throw new ExcepcionNegocio("EXP_NombreProveedorVacio");
            if (proveedor.Nombre.Length > 100) throw new ExcepcionNegocio("EXP_NombreProveedorLargo");

            if (!ValidadorCuit.EsValido(proveedor.CUIT)) throw new ExcepcionNegocio("EXP_CuitInvalido");

            if (!RegexEmail.IsMatch(proveedor.Email) || proveedor.Email.Length > 100)
                throw new ExcepcionNegocio("EXP_EmailInvalido");

            
            if (proveedor.Telefono.Length > 0 && !RegexTelefono.IsMatch(proveedor.Telefono))
                throw new ExcepcionNegocio("EXP_TelefonoInvalido");

            if (dal.ExisteCuit(proveedor.CUIT, idAExcluir)) throw new ExcepcionNegocio("EXP_CuitDuplicado");
        }
    }
}