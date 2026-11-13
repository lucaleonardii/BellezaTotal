using BellezaTotal_BE.Idiomas;
using BellezaTotal_BLL;
using BellezaTotal_BLL.Clases;

using BellezaTotal_SEC.Clases;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BellezaTotal_UI
{
    public partial class UC_Titulo : UserControl, IObserverIdioma
    {
        private Dictionary<string, Image> diccionarioBanderas;

        public UC_Titulo()
        {
            InitializeComponent();
            ActualizarIdioma();
            ConfigurarControl();
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


        public void ActualizarIdioma()
        {
            SeleccionarIdiomaActual();
        }

        private void SeleccionarIdiomaActual()
        {
            if (comboboxIdiomas.DataSource == null) return;

            comboboxIdiomas.SelectedValue = IdiomaManager.Instancia.CodigoIdiomaActual;
        }

  
        private void cmbIdiomas_DrawItem(object sender, DrawItemEventArgs e)
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

        private void comboboxIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxIdiomas.SelectedValue = IdiomaManager.Instancia.CodigoIdiomaActual;
            IdiomaManager.Instancia.AplicarIdioma(IdiomaManager.Instancia.CodigoIdiomaActual);
        }


        private void UC_Titulo_Load(object sender, EventArgs e)
        {
            
        }

    }
}