using BellezaTotal_BE.Excepciones;
using BellezaTotal_BE.Idiomas;
using BellezaTotal_BLL.Clases;
using BellezaTotal_SEC.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BellezaTotal_UI
{
    public partial class UI_Backup : Form, IObserverIdioma
    {
        public UI_Backup()
        {
            InitializeComponent();
        }

        private void UI_Backup_Load(object sender, EventArgs e)
        {
            AdministradorDeSesion administradorDeSesion = AdministradorDeSesion.Instancia;
            if (!administradorDeSesion.HaySesionActiva)
            {
                Close();
                return;
            }


            lblArchivoActual.Visible = false;
            btnConfirmar.Visible = false;


            TraductorDeControles.Traducir(this);
            IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
        }

        public void ActualizarIdioma()
        {
            TraductorDeControles.Traducir(this);
        }
        private void UI_Backup_FormClosing(object sender, FormClosingEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
        }


        private readonly BDBLL bll = new BDBLL();
        private string rutaBackupSeleccionado;

        private void btnRespaldarBaseDeDatos_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog dialogo = new SaveFileDialog())
                {
                    dialogo.Title = "Guardar copia de seguridad";
                    dialogo.Filter = "Archivos de backup (*.bak)|*.bak";
                    dialogo.FileName = tboxNombreArchivo.Text + ".bak";
                    dialogo.DefaultExt = "bak";
                    dialogo.AddExtension = true;
                    dialogo.OverwritePrompt = true;

                    if (dialogo.ShowDialog() != DialogResult.OK) return;

                    bll.CrearBackup(tboxNombreArchivo.Text, dialogo.FileName);

                    MessageBox.Show("Backup realizado correctamente.",
                    "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (ExcepcionNegocio ex)
            {
                MessageBox.Show(TraductorDeControles.ObtenerTexto(ex.Codigo, ex.Codigo));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el backup: " + ex.Message,
                    "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestaurarCargarBackup_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Title = "Seleccionar copia de seguridad";
                dialogo.Filter = "Archivos de backup (*.bak)|*.bak";
                dialogo.Multiselect = false;
                dialogo.CheckFileExists = true;

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    rutaBackupSeleccionado = dialogo.FileName;

                    lblArchivoActual.Text = $"Archivo seleccionado: {Path.GetFileName(rutaBackupSeleccionado)}";

                    lblArchivoActual.Visible = true;
                    btnConfirmar.Visible = true;
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rutaBackupSeleccionado))
            {
                MessageBox.Show("Primero tenés que seleccionar un archivo de backup.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro de que querés restaurar este backup?\n\n" +
                "Los datos actuales de la base de datos serán reemplazados.",
                "Confirmar restauración",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    BDBLL bll = new BDBLL();

                    bll.RestaurarBackup(rutaBackupSeleccionado);

                    MessageBox.Show(
                        "La base de datos se restauró correctamente.",
                        "Restauración",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                        
                    rutaBackupSeleccionado = null;
                    lblArchivoActual.Text = "";
                    lblArchivoActual.Visible = false;
                    btnConfirmar.Visible = false;
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(
                        "Error al restaurar el backup: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}
