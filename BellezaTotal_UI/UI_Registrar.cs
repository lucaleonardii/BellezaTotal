using BellezaTotal_BE.Idiomas;
using BellezaTotal_BE.Personas;
using BellezaTotal_BE.Excepciones;

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

namespace BellezaTotal_UI
{
    public partial class UI_Registrar : Form, IObserverIdioma
    {
        public UI_Registrar()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            ActualizarIdioma();
        }

        private UsuariosBLL bll = new UsuariosBLL();

        private void UI_Login_Load(object sender, EventArgs e)
        {
            AdministradorDeSesion administradorDeSesion = AdministradorDeSesion.Instancia;

            TraductorDeControles.Traducir(this);


            IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
        }

        public void ActualizarIdioma()
        {
            TraductorDeControles.Traducir(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string usuario = tboxRUsuario.Text.Trim();
            string contrasena = tboxRContraseña.Text;
            string email = tboxEmail.Text;

            try
            {
                AdministradorDeSesion.Instancia.Registrase(usuario, contrasena, email);

                string mensaje = TraductorDeControles.ObtenerTexto("UI_Registrar.Msg_Exito", "Cuenta creada con éxito");
                string titulo = TraductorDeControles.ObtenerTexto("UI_Registrar.Titulo_Exito", "Éxito");

                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);



                this.Close();
            }
            catch(ExcepcionNegocio ex)
            {
                string mensaje = TraductorDeControles.ObtenerTexto(ex.Codigo, ex.Codigo);
                MessageBox.Show(mensaje,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
