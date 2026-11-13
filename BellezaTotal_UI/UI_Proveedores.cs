using BellezaTotal_BE.Excepciones;
using BellezaTotal_BE.Idiomas;
using BellezaTotal_BE.Personas;
using BellezaTotal_BLL.Clases;
using BellezaTotal_SEC.Clases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BellezaTotal_UI
{
    public partial class UI_Proveedores : Form, IObserverIdioma
    {
        private readonly ProveedoresBLL bll = new ProveedoresBLL();
        private Proveedor proveedorEnEdicion;     
        private bool cargado;

        public UI_Proveedores()
        {
            InitializeComponent();

           
            Load -= UI_Proveedores_Load;
            Load += UI_Proveedores_Load;
            FormClosing -= UI_Proveedores_FormClosing;
            FormClosing += UI_Proveedores_FormClosing;
            btnNuevo.Click -= btnNuevo_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click -= btnGuardar_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEliminar.Click -= btnEliminar_Click;
            btnEliminar.Click += btnEliminar_Click;
            datagvProveedores.SelectionChanged -= datagvProveedores_SelectionChanged;
            datagvProveedores.SelectionChanged += datagvProveedores_SelectionChanged;
        }

        private void UI_Proveedores_Load(object sender, EventArgs e)
        {
            if (!AdministradorDeSesion.Instancia.HaySesionActiva)
            {
                Close();
                return;
            }

            ConfigurarGrilla();
            CargarProveedores();
            LimpiarFormulario();

            cargado = true;

            IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();

            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void UI_Proveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
        }

        public void ActualizarIdioma()
        {
            TraductorDeControles.Traducir(this);
        }

        private void ConfigurarGrilla()
        {
            datagvProveedores.ReadOnly = true;
            datagvProveedores.AllowUserToAddRows = false;
            datagvProveedores.AllowUserToDeleteRows = false;
            datagvProveedores.MultiSelect = false;
            datagvProveedores.RowHeadersVisible = false;
            datagvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarProveedores()
        {
            try
            {
                datagvProveedores.DataSource = null;
                datagvProveedores.DataSource = bll.Listar();

                if (datagvProveedores.Columns["ProveedorId"] != null)
                    datagvProveedores.Columns["ProveedorId"].Visible = false;

                if (datagvProveedores.Columns["Activo"] != null)
                    datagvProveedores.Columns["Activo"].Visible = false;

                
                if (cargado)
                    TraductorDeControles.Traducir(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimpiarFormulario()
        {
            proveedorEnEdicion = null;
            tboxNombre.Clear();
            ucCuit.Limpiar();
            tboxEmail.Clear();
            tboxTelefono.Clear();
            datagvProveedores.ClearSelection();
            tboxNombre.Focus();
        }

        private void datagvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (!cargado) return;

            Proveedor seleccionado = datagvProveedores.CurrentRow == null
                ? null
                : datagvProveedores.CurrentRow.DataBoundItem as Proveedor;

            if (seleccionado == null || !datagvProveedores.CurrentRow.Selected) return;

            proveedorEnEdicion = seleccionado;
            tboxNombre.Text = seleccionado.Nombre;
            ucCuit.Cuit = seleccionado.CUIT;
            tboxEmail.Text = seleccionado.Email;
            tboxTelefono.Text = seleccionado.Telefono;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor datos = new Proveedor();
                datos.Nombre = tboxNombre.Text;
                datos.CUIT = ucCuit.Cuit;
                datos.Email = tboxEmail.Text;
                datos.Telefono = tboxTelefono.Text;

                if (proveedorEnEdicion == null)
                    bll.Alta(datos);
                else
                    bll.Modificacion(datos, proveedorEnEdicion.ProveedorId);

                MessageBox.Show(Leyenda("UI_Proveedores.Msg_Guardado", "El proveedor se guardó correctamente"));

                CargarProveedores();
                LimpiarFormulario();
            }
            catch (ExcepcionNegocio ex)
            {
                MessageBox.Show(Leyenda(ex.Codigo, ex.Codigo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (proveedorEnEdicion == null)
            {
                MessageBox.Show(Leyenda("UI_Proveedores.Msg_Seleccionar", "Seleccione un proveedor de la grilla"));
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                Leyenda("UI_Proveedores.Msg_ConfirmarBaja", "¿Seguro que desea eliminar este proveedor?"),
                Leyenda("UI_Proveedores.Text", "Proveedores"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                bll.Baja(proveedorEnEdicion);

                CargarProveedores();
                LimpiarFormulario();
            }
            catch (ExcepcionNegocio ex)
            {
                MessageBox.Show(Leyenda(ex.Codigo, ex.Codigo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string Leyenda(string clave, string valorPorDefecto)
        {
            return TraductorDeControles.ObtenerTexto(clave, valorPorDefecto);
        }

        private void UI_Proveedores_Load_1(object sender, EventArgs e)
        {
            
        }

        private void ucCuit_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            btnEliminar.BackColor = Color.FromArgb(175, 151, 189);
        }

        private void btnEliminar_MouseEnter(object sender, EventArgs e)
        {
            btnEliminar.BackColor = Color.FromArgb(189, 115, 115);
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {

        }
    }
}