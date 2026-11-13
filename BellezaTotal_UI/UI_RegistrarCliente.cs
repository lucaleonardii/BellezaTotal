using BellezaTotal_BE.Excepciones;
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

namespace BellezaTotal_UI
{
    public partial class UI_RegistrarCliente : Form, IObserverIdioma
    {
        public UI_RegistrarCliente()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private ClientesBLL bll = new ClientesBLL();

        private void UI_RegistrarCliente_Load(object sender, EventArgs e)
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
        private void UI_RegistrarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = tboxNombre.Text;
            string apellido = tboxApellido.Text;
            string dni = tboxDni.Text;
            string email = tboxEmail.Text;
            string telefono = tboxTelefono.Text;

            try
            {
                Cliente cliente = new Cliente();

                cliente.Nombre = nombre;
                cliente.Apellido = apellido;
                cliente.DNI = Convert.ToInt32(dni);
                cliente.Email = email;
                cliente.Telefono = telefono;
                cliente.Activo = true;

                bll.Alta(cliente);
                this.Close();

                DialogResult = DialogResult.OK;
            }
            catch (ExcepcionNegocio ex)
            {
                MessageBox.Show(TraductorDeControles.ObtenerTexto(ex.Codigo, ex.Codigo));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
