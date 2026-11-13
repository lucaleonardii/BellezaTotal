using BellezaTotal_BE.Auditoria;
using BellezaTotal_BE.Familias;
using BellezaTotal_DAL.Clases;
using BellezaTotal_SEC.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BellezaTotal_SEC
{
    public class FamiliasBLL
    {
        private const string PatenteRequerida = "pat_GestionarFamilias";

        // Convención de nombres: FAM_ + mayúsculas, números o guion bajo (máximo 50 caracteres en total)
        private static readonly Regex PatronNombre = new Regex("^FAM_[A-Z0-9_]{2,46}$");

        public CatalogoPermisos ObtenerCatalogo()
        {
            VerificarPermiso();
            return new FamiliasDAL().ObtenerCatalogo();
        }

        public int Crear(string nombre, IEnumerable<int> idsPatentes, IEnumerable<int> idsFamiliasHijas)
        {
            VerificarPermiso();

            FamiliasDAL accesoDatos = new FamiliasDAL();
            string nombreNormalizado = NormalizarNombre(nombre);
            List<int> patentesSinRepetidos = (idsPatentes ?? Enumerable.Empty<int>()).Distinct().ToList();
            List<int> hijasSinRepetidos = (idsFamiliasHijas ?? Enumerable.Empty<int>()).Distinct().ToList();

            ValidarFamilia(accesoDatos.ObtenerCatalogo(), 0, nombreNormalizado, patentesSinRepetidos, hijasSinRepetidos);

            int familiaId = accesoDatos.Insertar(nombreNormalizado, patentesSinRepetidos, hijasSinRepetidos);

            // Se registra después del Commit: si la transacción falla, no queda un evento que no ocurrió
            new BitacoraBLL().Registrar(
                AccionesBitacora.AltaFamilia, SeveridadBitacora.Info,
                $"Se creó {nombreNormalizado} con {patentesSinRepetidos.Count} patentes y {hijasSinRepetidos.Count} familias");

            return familiaId;
        }

        public void Modificar(int familiaId, string nombre, IEnumerable<int> idsPatentes, IEnumerable<int> idsFamiliasHijas)
        {
            VerificarPermiso();

            FamiliasDAL accesoDatos = new FamiliasDAL();
            string nombreNormalizado = NormalizarNombre(nombre);
            List<int> patentesSinRepetidos = (idsPatentes ?? Enumerable.Empty<int>()).Distinct().ToList();
            List<int> hijasSinRepetidos = (idsFamiliasHijas ?? Enumerable.Empty<int>()).Distinct().ToList();

            CatalogoPermisos catalogo = accesoDatos.ObtenerCatalogo();

            if (!catalogo.Familias.Any(familiaDelCatalogo => familiaDelCatalogo.PermisoId == familiaId))
                throw new InvalidOperationException("La familia no existe");

            ValidarFamilia(catalogo, familiaId, nombreNormalizado, patentesSinRepetidos, hijasSinRepetidos);

            accesoDatos.Modificar(familiaId, nombreNormalizado, patentesSinRepetidos, hijasSinRepetidos);

            new BitacoraBLL().Registrar(
                AccionesBitacora.ModificacionFamilia, SeveridadBitacora.Info,
                $"Se modificó {nombreNormalizado} (ahora con {patentesSinRepetidos.Count} patentes y {hijasSinRepetidos.Count} familias)");
        }

        public void Eliminar(int familiaId)
        {
            VerificarPermiso();

            FamiliasDAL accesoDatos = new FamiliasDAL();
            CatalogoPermisos catalogo = accesoDatos.ObtenerCatalogo();

            Familia familiaAEliminar = catalogo.Familias
                .FirstOrDefault(familiaDelCatalogo => familiaDelCatalogo.PermisoId == familiaId);

            if (familiaAEliminar == null)
                throw new InvalidOperationException("La familia no existe");

            int cantidadUsuarios = accesoDatos.ContarUsuariosConFamilia(familiaId);
            if (cantidadUsuarios > 0)
                throw new InvalidOperationException(
                    $"No se puede eliminar {familiaAEliminar.Nombre}: está asignada a {cantidadUsuarios} usuario(s)");

            List<string> nombresFamiliasPadre = accesoDatos.ObtenerNombresFamiliasPadre(familiaId);
            if (nombresFamiliasPadre.Count > 0)
                throw new InvalidOperationException(
                    $"No se puede eliminar {familiaAEliminar.Nombre}: está incluida en {string.Join(", ", nombresFamiliasPadre)}");

            accesoDatos.Eliminar(familiaId);

            new BitacoraBLL().Registrar(
                AccionesBitacora.BajaFamilia, SeveridadBitacora.Warning,
                $"Se eliminó {familiaAEliminar.Nombre}");
        }

        // ---------- Validaciones ----------

        private string NormalizarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new FormatException("Ingrese un nombre para la familia");

            string nombreNormalizado = nombre.Trim().ToUpperInvariant();

            if (!PatronNombre.IsMatch(nombreNormalizado))
                throw new FormatException(
                    "El nombre debe empezar con FAM_ y usar solo letras sin tildes, números y guion bajo (ej: FAM_LIMPIEZA)");

            return nombreNormalizado;
        }

        // familiaId = 0 significa "familia nueva"
        private void ValidarFamilia(CatalogoPermisos catalogo, int familiaId, string nombre,
                                    List<int> idsPatentes, List<int> idsFamiliasHijas)
        {
            if (idsPatentes.Count == 0 && idsFamiliasHijas.Count == 0)
                throw new ArgumentException("La familia debe contener al menos una patente o una familia");

            bool nombreRepetido = catalogo.Familias.Any(familiaDelCatalogo =>
                familiaDelCatalogo.PermisoId != familiaId &&
                string.Equals(familiaDelCatalogo.Nombre, nombre, StringComparison.OrdinalIgnoreCase));

            if (nombreRepetido)
                throw new ArgumentException($"Ya existe una familia llamada {nombre}");

            HashSet<int> idsPatentesExistentes = new HashSet<int>(
                catalogo.Patentes.Select(patenteDelCatalogo => patenteDelCatalogo.PermisoId));

            if (idsPatentes.Any(patenteId => !idsPatentesExistentes.Contains(patenteId)))
                throw new ArgumentException("Se indicó una patente que no existe");

            Familia familiaActual = catalogo.Familias
                .FirstOrDefault(familiaDelCatalogo => familiaDelCatalogo.PermisoId == familiaId);   // null si es nueva

            foreach (int familiaHijaId in idsFamiliasHijas)
            {
                if (familiaHijaId == familiaId)
                    throw new InvalidOperationException("Operación inválida: una familia no puede contenerse a sí misma");

                Familia familiaHija = catalogo.Familias
                    .FirstOrDefault(familiaDelCatalogo => familiaDelCatalogo.PermisoId == familiaHijaId);

                if (familiaHija == null)
                    throw new ArgumentException("Se indicó una familia que no existe");

                // Ciclo: si la hija ya contiene (en cualquier nivel) a esta familia, agregarla cerraría un círculo
                if (familiaActual != null && familiaHija.ContieneFamilia(familiaActual))
                    throw new InvalidOperationException(
                        $"Operación inválida: se detectó una relación circular en el rol ({familiaHija.Nombre} ya contiene a {familiaActual.Nombre})");
            }
        }

        private void VerificarPermiso()
        {
            AdministradorDeSesion administradorDeSesion = AdministradorDeSesion.Instancia;

            if (!administradorDeSesion.HaySesionActiva ||
                !administradorDeSesion.UsuarioActual.TienePermiso(PatenteRequerida))
                throw new UnauthorizedAccessException("No tiene permiso para gestionar familias");
        }
    }
}