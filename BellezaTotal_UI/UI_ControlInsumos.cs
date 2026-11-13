using BellezaTotal_BE.Idiomas;
using BellezaTotal_BE.Insumos;
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
    public partial class UI_ControlInsumos : Form, IObserverIdioma
    {
        public UI_ControlInsumos()
        {
            InitializeComponent();
        }
        private void UI_ControlInsumos_Load(object sender, EventArgs e)
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

        private void UI_ControlInsumos_FormClosing(object sender, FormClosingEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
        }


        private async void btnMandarMail_Click(object sender, EventArgs e)
        {
            datagvInsumosDisp.EndEdit();

            List<DetalleReposicion> detalles = new List<DetalleReposicion>();

            foreach (DataGridViewRow fila in datagvInsumosDisp.Rows)
            {
                if (fila.IsNewRow) continue;

                bool seleccionado = Convert.ToBoolean(fila.Cells["ColumnaRestock"].Value ?? false);
                if (!seleccionado) continue;

                if (!int.TryParse(Convert.ToString(fila.Cells["ColumnaCantidad"].Value), out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingresá una cantidad mayor que cero para cada insumo seleccionado.",
                        "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Insumo insumo = fila.DataBoundItem as Insumo;
                if (insumo == null)
                {
                    MessageBox.Show("No se pudo recuperar uno de los insumos.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                detalles.Add(new DetalleReposicion(insumo, cantidad));
            }

            if (detalles.Count == 0)
            {
                MessageBox.Show("Seleccioná al menos un insumo.");
                return;
            }
            StringBuilder cuerpo = new StringBuilder();
            cuerpo.AppendLine("PEDIDO DE REPOSICIÓN DE INSUMOS");
            cuerpo.AppendLine();
            cuerpo.AppendLine("Solicitamos la siguiente mercadería:");
            cuerpo.AppendLine();
            foreach (DetalleReposicion detalle in detalles)
            {
                cuerpo.AppendLine($"- {detalle.InsumoReStock.Nombre}: {detalle.CantidadSolicitada} unidades");
            }
            cuerpo.AppendLine();
            cuerpo.AppendLine("Muchas gracias.");
            cuerpo.AppendLine("Belleza Total");

            string email;
            string cuerpoFinal;
            using (UI_Mail dialogo = new UI_Mail(cuerpo.ToString()))
            {
                if (dialogo.ShowDialog() != DialogResult.OK) return;
                email = dialogo.EmailDestinatario;
                cuerpoFinal = dialogo.EmailCuerpo;
            }

            DialogResult confirmacion = MessageBox.Show(
                $"Se enviará un pedido con {detalles.Count} insumos a {email}. ¿Continuar?",
                "Confirmar envío", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion != DialogResult.Yes) return;

            try
            {
                btnMandarMail.Enabled = false;

                EmailBLL correo = new EmailBLL();
                await correo.EnviarAsync(email, "Pedido de reposición de insumos", cuerpoFinal);

                MessageBox.Show("El correo se envió correctamente.", "Envío exitoso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo enviar el correo: " + ex.Message, "Error de envío",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnMandarMail.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UI_Proveedores formulario = new UI_Proveedores())
            {
                formulario.ShowDialog();
            }
        }
    }
}

