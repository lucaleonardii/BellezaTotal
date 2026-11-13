using BellezaTotal_BE.Auditoria;
using BellezaTotal_BE.Idiomas;
using BellezaTotal_DAL.Clases;
using BellezaTotal_SEC;      
using BellezaTotal_SEC.Clases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BellezaTotal_BLL.Clases
{
    public sealed class IdiomaManager
    {
        public const string CodigoIdiomaBase = "es";

        private static readonly Lazy<IdiomaManager> _instancia = new Lazy<IdiomaManager>(() => new IdiomaManager());

        public static IdiomaManager Instancia => _instancia.Value;

        private readonly object _lock = new object();
        private readonly List<IObserverIdioma> _observadores = new List<IObserverIdioma>();
        private readonly HashSet<string> _clavesFaltantesInformadas = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        private Dictionary<string, string> _leyendasBase = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private Dictionary<string, string> _leyendasActuales = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private string _codigoIdiomaActual = CodigoIdiomaBase;

        private IdiomaManager() { }

        public string CodigoIdiomaActual
        {
            get { lock (_lock) { return _codigoIdiomaActual; } }
        }

        public List<IdiomaSistema> ObtenerIdiomasDisponibles()
        {
            return new IdiomaDAL().ObtenerIdiomas();
        }

        
        public void AplicarIdioma(string codigoIdioma)
        {
            AsegurarLeyendasBase();

            string codigoExistente = BuscarCodigoExistente(codigoIdioma) ?? CodigoIdiomaBase;
            Dictionary<string, string> leyendas = LeerLeyendas(codigoExistente);

            Establecer(codigoExistente, leyendas);
            NotificarObservadores();
        }
        public void CambiarIdioma(string codigoIdioma)
        {
            AsegurarLeyendasBase();

            string codigoExistente = BuscarCodigoExistente(codigoIdioma);
            if (codigoExistente == null) throw new ArgumentException("El idioma seleccionado no existe");

            Dictionary<string, string> leyendas = LeerLeyendas(codigoExistente);

            AdministradorDeSesion administradorDeSesion = AdministradorDeSesion.Instancia;
            if (administradorDeSesion.HaySesionActiva)
                new IdiomaDAL().ActualizarIdiomaPreferido(administradorDeSesion.UsuarioActual.UsuarioId, codigoExistente);

            Establecer(codigoExistente, leyendas);
            NotificarObservadores();
        }

        public bool TryObtenerLeyenda(string clave, out string texto)
        {

            lock (_lock)
            {
                if (_leyendasActuales.TryGetValue(clave, out texto)) return true;

            AsegurarLeyendasBase();

                lock (_lock)
                {
                    if (_leyendasActuales.TryGetValue(clave, out texto))
                        return true;
                }
                   return _leyendasBase.TryGetValue(clave, out texto);
            }
        }


        public string Traducir(string clave)
        {
            if (TryObtenerLeyenda(clave, out string texto)) return texto;

            InformarLeyendaFaltante(clave);
            return clave;
        }

      

        public void Suscribir(IObserverIdioma observador)
        {
            lock (_lock)
            {
                if (!_observadores.Contains(observador))
                    _observadores.Add(observador);
            }
        }

        public void Desuscribir(IObserverIdioma observador)
        {
            lock (_lock)
            {
                _observadores.Remove(observador);
            }
        }

        private void NotificarObservadores()
        {
            
            List<IObserverIdioma> copiaDeObservadores;
            lock (_lock)
            {
                copiaDeObservadores = _observadores.ToList();
            }

            foreach (IObserverIdioma observador in copiaDeObservadores)
            {
                observador.ActualizarIdioma();
            }
        }

 

        private void AsegurarLeyendasBase()
        {
            lock (_lock)
            {
                if (_leyendasBase.Count > 0) return;
            }

            Dictionary<string, string> leyendasBase = LeerLeyendas(CodigoIdiomaBase);

            lock (_lock)
            {
                _leyendasBase = leyendasBase;
            }
        }

        private string BuscarCodigoExistente(string codigoIdioma)
        {
            if (string.IsNullOrWhiteSpace(codigoIdioma)) return null;

            IdiomaSistema idiomaEncontrado = ObtenerIdiomasDisponibles().FirstOrDefault(idiomaDisponible => string.Equals(idiomaDisponible.Codigo, codigoIdioma.Trim(), StringComparison.OrdinalIgnoreCase));

            return idiomaEncontrado?.Codigo;
        }

        private Dictionary<string, string> LeerLeyendas(string codigoIdioma)
        {
            Dictionary<string, string> leyendas = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (Leyenda leyenda in new IdiomaDAL().ObtenerLeyendas(codigoIdioma))
            {
                leyendas[leyenda.Clave] = leyenda.Texto;
            }

            return leyendas;
        }

        private void Establecer(string codigoIdioma, Dictionary<string, string> leyendas)
        {
            lock (_lock)
            {
                _codigoIdiomaActual = codigoIdioma;
                _leyendasActuales = leyendas;
            }
        }

        private void InformarLeyendaFaltante(string clave)
        {
            string codigoIdioma;

            lock (_lock)
            {
                if (!_clavesFaltantesInformadas.Add(clave)) return;   
                codigoIdioma = _codigoIdiomaActual;
            }

      
            new BitacoraBLL().Registrar( AccionesBitacora.LeyendaFaltante, SeveridadBitacora.Warning, $"Falta la leyenda '{clave}' (idioma {codigoIdioma})");
        }
    }
}