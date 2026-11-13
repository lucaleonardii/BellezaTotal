using BellezaTotal_BLL.Clases;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BellezaTotal_UI
{
    
    public class UC_Cuit : UserControl
    {
        private readonly MaskedTextBox mtbCuit = new MaskedTextBox();

        private static readonly Color ColorNormal = Color.White;
        private static readonly Color ColorError = Color.FromArgb(255, 205, 205);

        
        public event EventHandler CuitCambiado;

        public UC_Cuit()
        {
            
            mtbCuit.Mask = "00-00000000-0";
            mtbCuit.PromptChar = '_';
            mtbCuit.TextMaskFormat = MaskFormat.IncludeLiterals;
            mtbCuit.Dock = DockStyle.Fill;
            mtbCuit.TextChanged += mtbCuit_TextChanged;

            Controls.Add(mtbCuit);
            Size = new Size(160, mtbCuit.PreferredHeight);
        }

        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Cuit
        {
            get { return mtbCuit.MaskCompleted ? mtbCuit.Text : string.Empty; }
            set { mtbCuit.Text = SoloDigitos(value); }
        }

        
        [Browsable(false)]
        public bool EsValido
        {
            get { return ValidadorCuit.EsValido(Cuit); }
        }

        private static string SoloDigitos(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return string.Empty;

            System.Text.StringBuilder digitos = new System.Text.StringBuilder();

            foreach (char c in texto)
            {
                if (c >= '0' && c <= '9') digitos.Append(c);
            }

            return digitos.ToString();
        }

        public void Limpiar()
        {
            mtbCuit.Clear();
        }

        
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, mtbCuit.PreferredHeight, specified);
        }

        private void mtbCuit_TextChanged(object sender, EventArgs e)
        {
            bool incorrecto = mtbCuit.MaskCompleted && !ValidadorCuit.EsValido(mtbCuit.Text);
            mtbCuit.BackColor = incorrecto ? ColorError : ColorNormal;

            EventHandler manejador = CuitCambiado;
            if (manejador != null) manejador(this, EventArgs.Empty);
        }
    }
}