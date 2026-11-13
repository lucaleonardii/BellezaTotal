using BellezaTotal_BE.Idiomas;
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
    public partial class UI_Mail : Form, IObserverIdioma
    {

        public UI_Mail()
        {
            InitializeComponent();
        }
        private void UI_Mail_Load(object sender, EventArgs e)
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
        }

        public void ActualizarIdioma()
        {
            TraductorDeControles.Traducir(this);
        }

        private void UI_Mail_FormClosing(object sender, FormClosingEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
        }

        public UI_Mail(string cuerpoInicial) : this()
        {
            txtboxCuerpoMail.Text = cuerpoInicial;
        }
        public string EmailDestinatario => txtboxMailDestinatario.Text;
        public string EmailCuerpo => txtboxCuerpoMail.Text;
        private void btnEnviarMail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailDestinatario) ||
           !System.Text.RegularExpressions.Regex.IsMatch(EmailDestinatario, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingresá un correo válido.");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelarEnvio_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
