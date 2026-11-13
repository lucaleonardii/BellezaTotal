using BellezaTotal_BE.Agenda;
using BellezaTotal_BE.Excepciones;
using BellezaTotal_BE.Personas;
using BellezaTotal_BE.Servicios;
using BellezaTotal_BLL.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BellezaTotal_UI
{
    
    public partial class UI_AltaServicio : Form
    {
        public UI_AltaServicio() : this(null)
        {
           

        }
        public UI_AltaServicio(Servicio servicioAEditar)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            ServicioEdicion = servicioAEditar;


            cboxEspecialidad.DataSource = bll.ObtenerEspecialidades();
        }

        private ServiciosBLL bll = new ServiciosBLL();
        private readonly Servicio ServicioEdicion;

        private void btnRegistrarServicio_Click(object sender, EventArgs e)
        {
            string tipo = cboxTipo.Text;
            string nombre = tboxNombreServicio.Text;
            string descripcion = tboxDescServicio.Text;


            if (cboxEspecialidad.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una especialidad.");
                return;
            }
            string especialidadNombre = cboxEspecialidad.Text; 

            string precio = tboxPrecio.Text;
            string duracion = tboxDuracionServicio.Text;

            try
            {
                if (ServicioEdicion == null) bll.Alta(tipo, nombre, descripcion, especialidadNombre, precio, duracion);
                else bll.Modificacion(ServicioEdicion.IdServicio, tipo, nombre, descripcion, especialidadNombre, Convert.ToDecimal(precio), Convert.ToInt32(duracion));


                DialogResult = DialogResult.OK;
            }
            catch (ExcepcionNegocio ex) { MessageBox.Show(TraductorDeControles.ObtenerTexto(ex.Codigo, ex.Codigo)); }
        }

        private void UI_AltaServicio_Load(object sender, EventArgs e)
        {

            bool editando = ServicioEdicion != null;
            if (editando) CargarDatosDelServicio();


        }

        private void CargarDatosDelServicio()
        {
            cboxTipo.Text = ServicioEdicion.Tipo;
            tboxNombreServicio.Text = ServicioEdicion.Nombre;
            tboxDescServicio.Text = ServicioEdicion.Descripcion;
            cboxEspecialidad.Text = bll.ObtenerNombreEspecialidadPorId(ServicioEdicion.EspecialidadId);
            tboxPrecio.Text = ServicioEdicion.Precio.ToString();
            tboxDuracionServicio.Text = ServicioEdicion.Duracion.ToString();
        }

        private void btnCancelarServicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
