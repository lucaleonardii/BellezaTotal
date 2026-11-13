using BellezaTotal_BE.Agenda;
using BellezaTotal_BE.Excepciones;
using BellezaTotal_BE.Idiomas;
using BellezaTotal_BLL.Clases;
using BellezaTotal_SEC.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BellezaTotal_UI
{
    public partial class UI_GestionTurnos : Form, IObserverIdioma
    {
        
        public class FilaTurno
        {
            public int Id { get; set; }
            public string Hora { get; set; }
            public string Cliente { get; set; }
            public string Servicio { get; set; }
            public string Profesional { get; set; }
            public string Cabina { get; set; }
            public int Duracion { get; set; }
            public string Estado { get; set; }
        }

        private readonly TurnosBLL bll = new TurnosBLL();
        private List<Turno> turnosDelDia = new List<Turno>();
        private bool cargado;

        public UI_GestionTurnos()
        {
            InitializeComponent();
        }

        private void UI_GestionTurnos_Load(object sender, EventArgs e)
        {
            AdministradorDeSesion administradorDeSesion = AdministradorDeSesion.Instancia;

            if (!administradorDeSesion.HaySesionActiva)
            {
                Close();
                return;
            }

            ConfigurarGrilla();
            dtpFecha.Value = DateTime.Today;
            CargarTurnos();

            cargado = true;

            IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
        }

        public void ActualizarIdioma()
        {
            MostrarTurnos();
            TraductorDeControles.Traducir(this);
        }

        private void UI_GestionTurnos_FormClosing(object sender, FormClosingEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
        }

        private void ConfigurarGrilla()
        {
            datagvTurnos.ReadOnly = true;
            datagvTurnos.AllowUserToAddRows = false;
            datagvTurnos.AllowUserToDeleteRows = false;
            datagvTurnos.MultiSelect = false;
            datagvTurnos.RowHeadersVisible = false;
            datagvTurnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarTurnos()
        {
            try
            {
                turnosDelDia = bll.ListarPorFecha(dtpFecha.Value);
            }
            catch (Exception ex)
            {
                turnosDelDia = new List<Turno>();
                MessageBox.Show(ex.Message);
            }

            if (cargado)
                MostrarTurnos();
        }

        private void MostrarTurnos()
        {
            List<FilaTurno> filas = turnosDelDia
                .Select(t => new FilaTurno
                {
                    Id = t.TurnoId,
                    Hora = t.FechaSesion.ToString("HH:mm") + " - " + t.FechaFin.ToString("HH:mm"),
                    Cliente = t.Cliente.Apellido + ", " + t.Cliente.Nombre,
                    Servicio = t.Servicio != null ? t.Servicio.Nombre : string.Empty,
                    Profesional = t.Profesional.NombreCompleto,
                    Cabina = t.Cabina.NumeroCabina.ToString(),
                    Duracion = t.DuracionMinutos,
                    Estado = TraductorDeControles.ObtenerTexto("EstadoTurno." + t.Estado, t.Estado.ToString())
                })
                .ToList();

            datagvTurnos.DataSource = null;
            datagvTurnos.DataSource = filas;

            if (datagvTurnos.Columns["Id"] != null)
                datagvTurnos.Columns["Id"].Visible = false;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (!cargado) return;

            CargarTurnos();
        }

        private Turno ObtenerTurnoSeleccionado()
        {
            FilaTurno fila = datagvTurnos.CurrentRow == null
                ? null
                : datagvTurnos.CurrentRow.DataBoundItem as FilaTurno;

            Turno turno = fila == null ? null : turnosDelDia.FirstOrDefault(t => t.TurnoId == fila.Id);

            if (turno == null)
                MessageBox.Show(TraductorDeControles.ObtenerTexto(
                    "UI_GestionTurnos.Msg_SeleccionarTurno", "Seleccione un turno de la grilla"));

            return turno;
        }

        private void btnAgregarTurno_Click(object sender, EventArgs e)
        {
            DialogResult resultado;

            using (UI_AltaTurno formulario = new UI_AltaTurno())
            {
                resultado = formulario.ShowDialog();
            }

            if (resultado == DialogResult.OK)
                CargarTurnos();
        }

        private void btnModificarTurno_Click(object sender, EventArgs e)
        {
            Turno turno = ObtenerTurnoSeleccionado();
            if (turno == null) return;

            if (turno.Estado != EstadoTurno.Programado)
            {
                MessageBox.Show(TraductorDeControles.ObtenerTexto("EXP_TurnoEstadoInvalido", "EXP_TurnoEstadoInvalido"));
                return;
            }

            DialogResult resultado;

            using (UI_AltaTurno formulario = new UI_AltaTurno(turno))
            {
                resultado = formulario.ShowDialog();
            }

            if (resultado == DialogResult.OK)
                CargarTurnos();
        }

        private void btnCancelarTurno_Click(object sender, EventArgs e)
        {
            Turno turno = ObtenerTurnoSeleccionado();
            if (turno == null) return;

            string motivo;

            using (UI_MotivoTurno dialogo = new UI_MotivoTurno())
            {
                if (dialogo.ShowDialog() != DialogResult.OK) return;
                motivo = dialogo.Motivo;
            }

            try
            {
                turno.MotivoModificacion = motivo;
                bll.Baja(turno);

                MessageBox.Show(TraductorDeControles.ObtenerTexto(
                    "UI_GestionTurnos.Msg_TurnoCancelado", "El turno fue cancelado"));

                CargarTurnos();
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

        private void btnAtenderTurno_Click(object sender, EventArgs e)
        {
            Turno turno = ObtenerTurnoSeleccionado();
            if (turno == null) return;

            try
            {
                bll.Atender(turno);

                MessageBox.Show(TraductorDeControles.ObtenerTexto(
                    "UI_GestionTurnos.Msg_TurnoAtendido", "El turno fue marcado como atendido"));

                CargarTurnos();
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

        private void datagvTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
