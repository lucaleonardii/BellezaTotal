using BellezaTotal_BE.Agenda;
using BellezaTotal_BE.Idiomas;
using BellezaTotal_BE.Servicios;
using BellezaTotal_BLL.Clases;
using BellezaTotal_SEC.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BellezaTotal_UI.UI_GestionTurnos;

namespace BellezaTotal_UI
{
    public partial class UI_Servicios : Form, IObserverIdioma
    {

        public class FilaServicio
        {
            public int IdServicio { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public string EspecialidadId { get; set; }
            public decimal Precio { get; set; }
            public int Duracion { get; set; }
            public bool Activo { get; set; }
            public int idTratamiento { get; set; }
            public string Tipo { get; set; }

        }


        public UI_Servicios()
        {
            InitializeComponent();
        }
        private void UI_Servicios_Load(object sender, EventArgs e)
        {
            AdministradorDeSesion administradorDeSesion = AdministradorDeSesion.Instancia;

            if (!administradorDeSesion.HaySesionActiva)
            {
                Close();
                return;
            }
            TraductorDeControles.Traducir(this);
            IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();

            ConfigurarGrilla(datagvServicios);
            CargarServicios();

        }
        private ServiciosBLL bll = new ServiciosBLL();
        private bool cargado = false;
        private List<Servicio> ServiciosCargados = new List<Servicio>();
        private void CargarServicios()
        {
            try
            {
                ServiciosCargados = bll.Listar();
                datagvServicios.DataSource = ServiciosCargados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (cargado) { }
        }

        public void ActualizarIdioma()
        {
            TraductorDeControles.Traducir(this);
        }

        private void UI_Servicios_FormClosing(object sender, FormClosingEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
        }

        private void ConfigurarGrilla(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            DialogResult resultado;

            using (UI_AltaServicio formulario = new UI_AltaServicio())
            {
                resultado = formulario.ShowDialog();
            }

            if (resultado == DialogResult.OK)
            {
                MessageBox.Show(TraductorDeControles.ObtenerTexto("UI_Servicios.Msg_ExitoAlta", "El servicio fue agregado con éxito"));

                CargarServicio();
            }
        }

        private void CargarServicio()
        {
            CargarServicios();
        }

        private Servicio ObtenerServicioSeleccionado()
        {
            if (datagvServicios.CurrentRow == null)
            {
                MessageBox.Show(TraductorDeControles.ObtenerTexto("UI_Servicios.Msg_SeleccionarServicio", "Seleccione un servicio de la grilla"));
                return null;
            }

            
            Servicio servicio = datagvServicios.CurrentRow.DataBoundItem as Servicio;

            if (servicio == null)
            {
                MessageBox.Show(TraductorDeControles.ObtenerTexto("UI_Servicios.Msg_SeleccionarServicio", "Seleccione un servicio de la grilla"));
            }

            return servicio;
        }

        private void btnModificarServicio_Click(object sender, EventArgs e)
        {
            Servicio servicio = ObtenerServicioSeleccionado();
            if (servicio == null) return;

            DialogResult resultado;

            using (UI_AltaServicio formulario = new UI_AltaServicio(servicio))
            {
                resultado = formulario.ShowDialog();
            }

            if (resultado == DialogResult.OK)
            {
                MessageBox.Show(TraductorDeControles.ObtenerTexto("UI_Servicios.Msg_ExitoModificacion", "El servicio fue modificado con éxito"));
                CargarServicios();
            }
        }
    }
}
