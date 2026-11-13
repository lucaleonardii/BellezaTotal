using BellezaTotal_BE.Idiomas;
using BellezaTotal_BE.Personas;
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

using BellezaTotal_BE.Excepciones;
using BellezaTotal_BLL.Clases.xml;

namespace BellezaTotal_UI
{
    public partial class UI_Clientes : Form, IObserverIdioma
    {


        private ClientesBLL bll = new ClientesBLL();
        private ClientesXmlBLL xmlBll = new ClientesXmlBLL();
        private Cliente clienteSeleccionado = null;

        public UI_Clientes()
        {
            InitializeComponent();
        }

        private void UI_Clientes_Load(object sender, EventArgs e)
        {
            AdministradorDeSesion administradorDeSesion = AdministradorDeSesion.Instancia;

            if (!administradorDeSesion.HaySesionActiva)
            {
                Close();
                return;
            }

            ConfigurarGrillaFicha(datagridAlergias, "Alergia", "Alergia");

            ConfigurarGrillaFicha(datagridAfecciones, "Afeccion", "Afección");

            ConfigurarGrillaFicha(datagridContraindicaciones, "Contraindicacion", "Contraindicación");

            CargarClientes();

            TraductorDeControles.Traducir(this);
            IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
        }

        public void ActualizarIdioma()
        {
            TraductorDeControles.Traducir(this);
        }

        private void UI_Clientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
        }

        private void CargarClientes()
        {
            if (datagvClientes.Rows.Count > 0)
            {
                datagvClientes.Rows[0].Selected = true;
            }

            datagvClientes.DataSource = null;
            datagvClientes.DataSource = bll.Listar();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            DialogResult resultado;

            using (var form = new UI_RegistrarCliente())
            {
                resultado = form.ShowDialog();
            }

            if (resultado == DialogResult.OK) CargarClientes();
        }

        private void ConfigurarGrillaFicha(DataGridView dgv, string nombreColumna, string encabezado)
        {
            dgv.Columns.Clear();

            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = true;
            dgv.AllowUserToDeleteRows = true;
            dgv.ReadOnly = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.RowHeadersVisible = false;

            DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();

            columna.Name = nombreColumna;
            columna.HeaderText = encabezado;
            columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns.Add(columna);
        }

        private void datagvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (datagvClientes.CurrentRow == null) return;

            clienteSeleccionado = datagvClientes.CurrentRow.DataBoundItem as Cliente;

            if (clienteSeleccionado == null) return;

            CargarFichaTecnica(clienteSeleccionado);
        }

        private void CargarFichaTecnica(Cliente cliente)
        {
            LimpiarGrillasFicha();

            // Cargar alergias
            foreach (string alergia in cliente.FichaTecnicaAlergias)
            {
                datagridAlergias.Rows.Add(alergia);
            }

            // Cargar afecciones
            foreach (string afeccion in cliente.FichaTecnicaAfecciones)
            {
                datagridAfecciones.Rows.Add(afeccion);
            }

            // Cargar contraindicaciones
            foreach (string contraindicacion in
                cliente.FichaTecnicaContraindicaciones)
            {
                datagridContraindicaciones.Rows.Add(contraindicacion);
            }
        }

        private void LimpiarGrillasFicha()
        {
            datagridAlergias.Rows.Clear();
            datagridAfecciones.Rows.Clear();
            datagridContraindicaciones.Rows.Clear();
        }


        private BindingList<string> ObtenerValoresGrilla(DataGridView dgv)
        {
            BindingList<string> valores = new BindingList<string>();

            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                object valor = fila.Cells[0].Value;

                if (valor == null || string.IsNullOrWhiteSpace(valor.ToString()))
                    continue;

                valores.Add(valor.ToString().Trim());
            }

            return valores;
        }

        private void btnGuardarFichas_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado == null)
                return;

            try
            {
                
                datagridAlergias.EndEdit();
                datagridAfecciones.EndEdit();
                datagridContraindicaciones.EndEdit();

                
                clienteSeleccionado.FichaTecnicaAlergias =
                    ObtenerValoresGrilla(datagridAlergias);

                clienteSeleccionado.FichaTecnicaAfecciones =
                    ObtenerValoresGrilla(datagridAfecciones);

                clienteSeleccionado.FichaTecnicaContraindicaciones =
                    ObtenerValoresGrilla(datagridContraindicaciones);


                bll.Modificacion(
                    clienteSeleccionado,
                    clienteSeleccionado.ClienteId);

                MessageBox.Show("Ficha técnica actualizada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron guardar los cambios: " + ex.Message);
            }
        }

        private void btnExportarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog dialogo = new SaveFileDialog())
                {
                    dialogo.Title = LeyendaXml("UI_Clientes.Titulo_Exportar", "Exportar clientes a XML");
                    dialogo.Filter = "Archivos XML (*.xml)|*.xml";
                    dialogo.FileName = "Clientes_" + DateTime.Now.ToString("yyyyMMdd") + ".xml";
                    dialogo.DefaultExt = "xml";
                    dialogo.AddExtension = true;
                    dialogo.OverwritePrompt = true;

                    if (dialogo.ShowDialog() != DialogResult.OK) return;

                    int cantidad = xmlBll.Exportar(dialogo.FileName);

                    MessageBox.Show(
                        string.Format(LeyendaXml("UI_Clientes.Msg_ExportOk", "Se exportaron {0} clientes."), cantidad),
                        dialogo.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ExcepcionNegocio ex)
            {
                MessageBox.Show(LeyendaXml(ex.Codigo, ex.Codigo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "XML", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btnImportarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dialogo = new OpenFileDialog())
                {
                    dialogo.Title = LeyendaXml("UI_Clientes.Titulo_Importar", "Importar clientes desde XML");
                    dialogo.Filter = "Archivos XML (*.xml)|*.xml";
                    dialogo.Multiselect = false;
                    dialogo.CheckFileExists = true;

                    if (dialogo.ShowDialog() != DialogResult.OK) return;

                    ResultadoImportacion resultado = xmlBll.Importar(dialogo.FileName);

                    CargarClientes();
                    MostrarResultadoImportacion(resultado, dialogo.Title);
                }
            }
            catch (ExcepcionNegocio ex)
            {
                MessageBox.Show(LeyendaXml(ex.Codigo, ex.Codigo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "XML", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MostrarResultadoImportacion(ResultadoImportacion resultado, string titulo)
        {
            StringBuilder mensaje = new StringBuilder();

            mensaje.AppendLine(string.Format(
                LeyendaXml("UI_Clientes.Msg_ImportResumen", "Clientes importados: {0}. Omitidos: {1}."),
                resultado.Importados, resultado.Errores.Count));

            
            foreach (ErrorImportacion error in resultado.Errores.Take(10))
            {
                mensaje.AppendLine(string.Format(
                    LeyendaXml("UI_Clientes.Msg_ImportDetalle", "Cliente {0} (DNI {1}): {2}"),
                    error.Posicion, error.DNI, LeyendaXml(error.Motivo, error.Motivo)));
            }

            if (resultado.Errores.Count > 10)
                mensaje.AppendLine("...");

            MessageBox.Show(
                mensaje.ToString(), titulo, MessageBoxButtons.OK,
                resultado.Errores.Count == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }



        private string LeyendaXml(string clave, string valorPorDefecto)
        {
            return TraductorDeControles.ObtenerTexto(clave, valorPorDefecto);
        }

    }
}
