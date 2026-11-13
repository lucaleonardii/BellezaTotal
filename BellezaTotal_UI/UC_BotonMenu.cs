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
    public partial class UC_BotonMenu : UserControl
    {
        public UC_BotonMenu()
        {
            InitializeComponent();
        }
        public event EventHandler MenuClickeado;
        public string TituloMenu
        {
            get { return btnAccion.Text; }
            set { btnAccion.Text = value; }
        }
        public Image ImagenBoton 
        {
            get { return btnAccion.Image; }
            set { btnAccion.Image = value; }
        }

        private void btnAccion_Click_1(object sender, EventArgs e)
        {
            MenuClickeado?.Invoke(this, e);
        }
    }
}
