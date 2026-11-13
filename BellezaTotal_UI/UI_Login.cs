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

using BellezaTotal_SEC.Clases;
using BellezaTotal_BE.Idiomas;
using BellezaTotal_BE.Excepciones;
namespace BellezaTotal_UI
{
    public partial class UI_Login : Form, IObserverIdioma
    {
        public UI_Login()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            ActualizarIdioma();
            ConfigurarControl();
        }

        private void UI_Login_Load(object sender, EventArgs e)
        {
            AdministradorDeSesion administradorDeSesion = AdministradorDeSesion.Instancia;

            //if (!administradorDeSesion.HaySesionActiva)
            //{
            //    Close();
            //    return;
            //}
            TraductorDeControles.Traducir(this);


            IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
        }

        public void ActualizarIdioma()
        {
            TraductorDeControles.Traducir(this);
        }
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            using (UI_Registrar formularioRegistro = new UI_Registrar())
            {
                DialogResult resultado = formularioRegistro.ShowDialog(this);

                if (resultado == DialogResult.OK)
                {
                   
                }
            }
        }

        private Dictionary<string, Image> diccionarioBanderas;
        private void SeleccionarIdiomaActual()
        {
            if (comboboxIdiomas.DataSource == null) return;

            comboboxIdiomas.SelectedValue = IdiomaManager.Instancia.CodigoIdiomaActual;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            try
            {
                comboboxIdiomas.DataSource = IdiomaManager.Instancia.ObtenerIdiomasDisponibles();
                SeleccionarIdiomaActual();
            }
            catch (Exception)
            {
                comboboxIdiomas.Enabled = false;
            }

            IdiomaManager.Instancia.Suscribir(this);

            Disposed += (remitente, argumentos) => IdiomaManager.Instancia.Desuscribir(this);
        }


        private void ConfigurarControl()
        {

            diccionarioBanderas = new Dictionary<string, Image>
            {
                { "es", Properties.Resources.flag_es },
                { "en", Properties.Resources.flag_us }
            };

            comboboxIdiomas.DrawMode = DrawMode.OwnerDrawFixed;
            comboboxIdiomas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboboxIdiomas.ItemHeight = 24;
            comboboxIdiomas.DisplayMember = "Nombre";
            comboboxIdiomas.ValueMember = "Codigo";

            comboboxIdiomas.SelectionChangeCommitted += comboboxIdiomas_SelectionChangeCommitted;
        }


        private void comboboxIdiomas_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            IdiomaSistema idiomaActual = (IdiomaSistema)comboboxIdiomas.Items[e.Index];

            if (diccionarioBanderas.ContainsKey(idiomaActual.Codigo))
            {
                Image bandera = diccionarioBanderas[idiomaActual.Codigo];
                e.Graphics.DrawImage(bandera, new Rectangle(e.Bounds.Left + 5, e.Bounds.Top + 4, 20, 14));
            }

            using (Brush textoBrush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(idiomaActual.Nombre, e.Font, textoBrush, new PointF(e.Bounds.Left + 35, e.Bounds.Top + 4));
            }

            e.DrawFocusRectangle();
        }

        private void comboboxIdiomas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            IdiomaSistema idiomaElegido = comboboxIdiomas.SelectedItem as IdiomaSistema;
            if (idiomaElegido == null) return;

            try
            {
                IdiomaManager.Instancia.CambiarIdioma(idiomaElegido.Codigo);
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Idioma", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                SeleccionarIdiomaActual();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void IniciarSesion()
        {
            try
            {
                string nombre = tboxUsuario.Text;
                string clave = tboxContrasena.Text;

                AdministradorDeSesion.Instancia.IniciarSesion(nombre, clave);

                MessageBox.Show(
                TraductorDeControles.ObtenerTexto(
                "UI_Login.Msg_IniciarSesion",
                $"Sesión iniciada con éxito. Bienvenido/a,") + $" {AdministradorDeSesion.Instancia.UsuarioActual.NombreUsuario}",
                TraductorDeControles.ObtenerTexto(
                    "UI_Login.Titulo_IniciarSesion",
                    "Iniciar sesión"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }

            catch (ExcepcionNegocio ex)
            {
                string mensaje = TraductorDeControles.ObtenerTexto(ex.Codigo, ex.Codigo);
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Mensaje de error: {ex.Message}", "Error de ejecución", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tboxContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                e.SuppressKeyPress = true;
                e.Handled = true;

                IniciarSesion();
            }
        }

        private void btnIniciarSesion_MouseHover(object sender, EventArgs e)
        {
            Hover(sender as Button);
        }

        private void btnIniciarSesion_MouseLeave(object sender, EventArgs e)
        {
            Leaving(sender as Button);
        }

        private void btnIniciarSesion_MouseEnter(object sender, EventArgs e)
        {
            Hover(sender as Button);
        }

        private void Hover(Button btn)
        {
            btn.BackColor = Color.FromArgb(104, 89, 112);
        }
        private void Leaving(Button btn)
        {
            btn.BackColor = Color.FromArgb(175, 151, 189);
        }

        private void btnRegistrarUsuario_MouseEnter(object sender, EventArgs e)
        {
            Hover(sender as Button);
        }

        private void btnRegistrarUsuario_MouseLeave(object sender, EventArgs e)
        {
            Leaving(sender as Button);
        }
    }
}
