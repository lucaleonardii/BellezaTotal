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
    public partial class UI_Profesionales : Form, IObserverIdioma
    {
        public UI_Profesionales()
        {
            InitializeComponent();
        }
        private void UI_PRofesionales_Load(object sender, EventArgs e)
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

        private void UI_Profesionales_FormClosing(object sender, FormClosingEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {

        }

        private void btnProfesionalizar_Click(object sender, EventArgs e)
        {

        }
    }
}
