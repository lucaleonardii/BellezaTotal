using BellezaTotal_BE.Agenda;
using BellezaTotal_BE.Excepciones;
using BellezaTotal_BE.Idiomas;
using BellezaTotal_BE.Personas;
using BellezaTotal_BE.Servicios;
using BellezaTotal_BLL.Clases;
using BellezaTotal_SEC.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BellezaTotal_UI
{

    public partial class UI_AltaTurno : Form, IObserverIdioma
    {
        
        public class Item<T>
        {
            public T Valor { get; set; }
            public string Texto { get; set; }
        }

        private readonly TurnosBLL turnosBll = new TurnosBLL();
        private readonly Turno turnoEnEdicion;
        private List<Profesional> profesionales = new List<Profesional>();
        private bool cargando;

        public UI_AltaTurno() : this(null)
        {
        }

        public UI_AltaTurno(Turno turnoAEditar)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            turnoEnEdicion = turnoAEditar;
        }

        private void UI_AltaTurno_Load(object sender, EventArgs e)
        {
            if (!AdministradorDeSesion.Instancia.HaySesionActiva)
            {
                Close();
                return;
            }

            cargando = true;

            try
            {
                CargarClientes();
                CargarServicios();
                profesionales = new ProfesionalesBLL().Listar();
                FiltrarProfesionales();
                CargarCabinas();

                bool editando = turnoEnEdicion != null;
                lblMotivo.Visible = editando;
                tboxMotivo.Visible = editando;

                if (editando)
                    CargarDatosDelTurno();
                else
                    dtpFechaHora.Value = ProximaHoraEnPunto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cargando = false;
                Close();
                return;
            }

            cargando = false;

            IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
        }

        public void ActualizarIdioma()
        {
            TraductorDeControles.Traducir(this);

            if (turnoEnEdicion != null)
                lTituloTurno.Text = TraductorDeControles.ObtenerTexto("UI_AltaTurno.Titulo_Modificar", "Reprogramar turno");

            ActualizarResumen();
        }

        private void UI_AltaTurno_FormClosing(object sender, FormClosingEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
        }

        private void CargarClientes()
        {
            List<Item<Cliente>> items = new ClientesBLL().Listar()
                .OrderBy(c => c.Apellido).ThenBy(c => c.Nombre)
                .Select(c => new Item<Cliente>
                {
                    Valor = c,
                    Texto = c.Apellido + ", " + c.Nombre + " (DNI " + c.DNI + ")"
                })
                .ToList();

            Enlazar(cmbCliente, items);
        }

        private void CargarServicios()
        {
            List<Item<Servicio>> items = new ServiciosBLL().Listar()
                .OrderBy(s => s.Nombre)
                .Select(s => new Item<Servicio>
                {
                    Valor = s,
                    Texto = s.Nombre + (s is PlanEstetico ? " [Plan]" : string.Empty)
                })
                .ToList();

            Enlazar(cmbServicio, items);
        }

        private void CargarCabinas()
        {
            string textoCabina = TraductorDeControles.ObtenerTexto("UI_AltaTurno.lblCabina", "Cabina");

            List<Item<Cabina>> items = new CabinasBLL().Listar()
                .Where(c => c.Estado == Cabina.EstadoDisponible)
                .Select(c => new Item<Cabina>
                {
                    Valor = c,
                    Texto = textoCabina + " " + c.NumeroCabina
                })
                .ToList();

            Enlazar(cmbCabina, items);
        }

        // Solo se ofrecen los profesionales capacitados para el servicio elegido
        private void FiltrarProfesionales()
        {
            Servicio servicio = ValorSeleccionado<Servicio>(cmbServicio);
            Profesional actual = ValorSeleccionado<Profesional>(cmbProfesional);

            List<Item<Profesional>> items = profesionales
                .Where(p => servicio == null
                         || !servicio.EspecialidadId.HasValue
                         || p.EspecialidadId == servicio.EspecialidadId)
                .Select(p => new Item<Profesional>
                {
                    Valor = p,
                    Texto = p.NombreCompleto +
                            (string.IsNullOrEmpty(p.Especialidad) ? string.Empty : " - " + p.Especialidad)
                })
                .ToList();

            Enlazar(cmbProfesional, items);

            if (actual != null)
                Seleccionar<Profesional>(cmbProfesional, p => p.ProfesionalId == actual.ProfesionalId);
        }

        private void CargarDatosDelTurno()
        {
            if (turnoEnEdicion.Cliente != null)
                Seleccionar<Cliente>(cmbCliente, c => c.ClienteId == turnoEnEdicion.Cliente.ClienteId);

            if (turnoEnEdicion.Servicio != null)
                Seleccionar<Servicio>(cmbServicio, s => s.IdServicio == turnoEnEdicion.Servicio.IdServicio);

            FiltrarProfesionales();

            if (turnoEnEdicion.Profesional != null)
                Seleccionar<Profesional>(cmbProfesional, p => p.ProfesionalId == turnoEnEdicion.Profesional.ProfesionalId);

            if (turnoEnEdicion.Cabina != null)
                Seleccionar<Cabina>(cmbCabina, c => c.CabinaId == turnoEnEdicion.Cabina.CabinaId);

            dtpFechaHora.Value = turnoEnEdicion.FechaSesion;
        }

        private void cmbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargando) return;

            FiltrarProfesionales();
            ActualizarResumen();
        }

        private void ActualizarResumen()
        {
            Servicio servicio = ValorSeleccionado<Servicio>(cmbServicio);

            if (servicio == null)
            {
                lblResumen.Text = string.Empty;
                return;
            }

            string plantilla = TraductorDeControles.ObtenerTexto(
                "UI_AltaTurno.Resumen", "Duración: {0} min - Precio: {1}");

            lblResumen.Text = string.Format(
                plantilla,
                servicio.ObtenerDuracion(),
                servicio.ObtenerPrecio().ToString("C"));
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = dtpFechaHora.Value;

                Turno turno = new Turno();
                turno.Cliente = ValorSeleccionado<Cliente>(cmbCliente);
                turno.Servicio = ValorSeleccionado<Servicio>(cmbServicio);
                turno.Profesional = ValorSeleccionado<Profesional>(cmbProfesional);
                turno.Cabina = ValorSeleccionado<Cabina>(cmbCabina);
                turno.FechaSesion = new DateTime(fecha.Year, fecha.Month, fecha.Day, fecha.Hour, fecha.Minute, 0);

                if (turnoEnEdicion == null)
                {
                    turnosBll.Alta(turno);
                }
                else
                {
                    turno.MotivoModificacion = tboxMotivo.Text.Trim();
                    turnosBll.Modificacion(turno, turnoEnEdicion.TurnoId);
                }

                DialogResult = DialogResult.OK;
            }
            catch (ExcepcionNegocio ex)
            {
                MessageBox.Show(TraductorDeControles.ObtenerTexto(ex.Codigo, ex.Codigo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private DateTime ProximaHoraEnPunto()
        {
            DateTime ahora = DateTime.Now;
            return new DateTime(ahora.Year, ahora.Month, ahora.Day, ahora.Hour, 0, 0).AddHours(1);
        }

        private void Enlazar<T>(ComboBox combo, List<Item<T>> items)
        {
            combo.DataSource = null;
            combo.DisplayMember = "Texto";
            combo.DataSource = items;
            combo.SelectedIndex = items.Count > 0 ? 0 : -1;
        }

        private T ValorSeleccionado<T>(ComboBox combo) where T : class
        {
            Item<T> item = combo.SelectedItem as Item<T>;
            return item == null ? null : item.Valor;
        }

        private void Seleccionar<T>(ComboBox combo, Func<T, bool> coincide) where T : class
        {
            for (int i = 0; i < combo.Items.Count; i++)
            {
                Item<T> item = combo.Items[i] as Item<T>;

                if (item != null && coincide(item.Valor))
                {
                    combo.SelectedIndex = i;
                    return;
                }
            }
        }
    }
}
