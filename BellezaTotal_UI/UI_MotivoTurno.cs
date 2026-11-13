using System;
using System.Drawing;
using System.Windows.Forms;

namespace BellezaTotal_UI
{
    // Diálogo simple para pedir el motivo de una cancelación (se arma por código, sin Designer)
    public class UI_MotivoTurno : Form
    {
        private readonly Label lblMotivo = new Label();
        private readonly TextBox tboxMotivo = new TextBox();
        private readonly Button btnAceptar = new Button();
        private readonly Button btnVolver = new Button();

        public string Motivo
        {
            get { return tboxMotivo.Text.Trim(); }
        }

        public UI_MotivoTurno()
        {
            Text = TraductorDeControles.ObtenerTexto("UI_MotivoTurno.Text", "Motivo de la cancelación");
            ClientSize = new Size(440, 150);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.FromArgb(218, 199, 226);

            lblMotivo.AutoSize = true;
            lblMotivo.Location = new Point(20, 20);
            lblMotivo.Text = TraductorDeControles.ObtenerTexto(
                "UI_MotivoTurno.Etiqueta", "Indique el motivo de la cancelación:");

            tboxMotivo.Location = new Point(20, 50);
            tboxMotivo.Size = new Size(400, 22);
            tboxMotivo.MaxLength = 200;

            btnAceptar.Location = new Point(20, 95);
            btnAceptar.Size = new Size(195, 35);
            btnAceptar.Text = TraductorDeControles.ObtenerTexto("UI_MotivoTurno.Aceptar", "Aceptar");
            btnAceptar.DialogResult = DialogResult.OK;

            btnVolver.Location = new Point(225, 95);
            btnVolver.Size = new Size(195, 35);
            btnVolver.Text = TraductorDeControles.ObtenerTexto("UI_MotivoTurno.Cancelar", "Volver");
            btnVolver.DialogResult = DialogResult.Cancel;

            Controls.Add(lblMotivo);
            Controls.Add(tboxMotivo);
            Controls.Add(btnAceptar);
            Controls.Add(btnVolver);

            AcceptButton = btnAceptar;
            CancelButton = btnVolver;
        }
    }
}
