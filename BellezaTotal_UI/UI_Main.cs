using BellezaTotal_BE;
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
    public partial class UI_Main : Form, IObserverIdioma
    {
        public UI_Main()
        {
            InitializeComponent();
            TraductorDeControles.Traducir(this);
        }

        private void UI_Main_Load(object sender, EventArgs e)
        {
            AdministradorDeSesion administradorDeSesion = AdministradorDeSesion.Instancia;

            //if (!administradorDeSesion.HaySesionActiva)
            //{
            //    Close();
            //    return;
            //}

            this.StartPosition = FormStartPosition.CenterScreen;
            
            TraductorDeControles.Traducir(this);

            IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
            VerificarPatentes();
        }

        private bool TieneAlgunaPatente(UsuarioSesion sesion, string patentesSeparadasPorBarra)
        {
            foreach (string nombrePatente in patentesSeparadasPorBarra.Split('|'))
            {
                if (sesion.TienePermiso(nombrePatente.Trim()))
                    return true;
            }

            return false;
        }

        public void ActualizarIdioma()
        {
            TraductorDeControles.Traducir(this);
        }
        private void UI_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdministradorDeSesion.Instancia.CerrarSesion();
        }


        private void AbrirForm(Form formulario)
        {
            foreach (Form formAbierto in this.MdiChildren)
            {
                formAbierto.Close();
            }
            formulario.MdiParent = this;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.Show();
        }

        private void VerificarPatentes()
        {
            var usuario = AdministradorDeSesion.Instancia.UsuarioActual;

            var controlesPermisos = new Dictionary<Control, string>
            {
                { uC_BotonMenu1,  "pat_GestionarTurnos" },
                { uC_BotonMenu2,  "pat_VerSalaEspera" },
                { uC_BotonMenu3,  "pat_GestionarClientes" },
                { uC_BotonMenu4,  "pat_GestionarProfesionales" },
                { uC_BotonMenu5,  "pat_GestionarServicios" },
                { uC_BotonMenu6,  "pat_GestionarPlanes" },
                { uC_BotonMenu7,  "pat_GestionarInsumos" },
                { uC_BotonMenu8,  "pat_VerConsumoHardware" },
                { uC_BotonMenu9,  "pat_GestionarUsuarios" },
                { uC_BotonMenu10, "pat_GestionarFamilias" },
                { uC_BotonMenu11, "pat_VerBitacora" },
                { uC_BotonMenu12, "pat_CerrarSesion" },
                { uC_BotonMenu13, "pat_GenerarBackup" },
            };

            foreach (var par in controlesPermisos)
            {
                if (!usuario.TienePermiso(par.Value))
                {
                    par.Key.Hide();
                }
            }
        }

        private void uC_BotonMenu1_MenuClickeado(object sender, EventArgs e) => AbrirForm(new UI_GestionTurnos());
        private void uC_BotonMenu2_MenuClickeado(object sender, EventArgs e) => AbrirForm(new UI_WaitLine());
        private void uC_BotonMenu3_MenuClickeado(object sender, EventArgs e) => AbrirForm(new UI_Clientes());
        private void uC_BotonMenu4_MenuClickeado(object sender, EventArgs e) => AbrirForm(new UI_Profesionales());
        private void uC_BotonMenu5_MenuClickeado(object sender, EventArgs e) => AbrirForm(new UI_Servicios());
        private void uC_BotonMenu6_MenuClickeado(object sender, EventArgs e) => AbrirForm(new UI_DiseñoPlan());
        private void uC_BotonMenu7_MenuClickeado(object sender, EventArgs e) => AbrirForm(new UI_ControlInsumos());
        private void uC_BotonMenu8_MenuClickeado(object sender, EventArgs e) => AbrirForm(new UI_Analiticas());
        private void uC_BotonMenu9_MenuClickeado(object sender, EventArgs e) => AbrirForm(new UI_GestionUsuarios());
        private void uC_BotonMenu10_MenuClickeado(object sender, EventArgs e) => AbrirForm(new UI_GestionFamilias());
        private void uC_BotonMenu11_MenuClickeado(object sender, EventArgs e) => AbrirForm(new UI_Bitacora());
        private void uC_BotonMenu13_MenuClickeado(object sender, EventArgs e) => AbrirForm(new UI_Backup());

        private void uC_BotonMenu12_MenuClickeado(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show(
                TraductorDeControles.ObtenerTexto(
                "UI_Main.Msg_CerrarSesion",
                "¿Desea cerrar la sesión?"
            ),
                TraductorDeControles.ObtenerTexto(
                    "UI_Main.Titulo_CerrarSesion",
                    "Cerrar sesión"
            ),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes) this.Close();
        }

        private void UI_Main_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
            AdministradorDeSesion.Instancia.CerrarSesion();
        }

        
    }
}
