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
using System.Xml.XPath;

namespace BellezaTotal_UI
{
    public partial class UI_GestionUsuarios : Form, IObserverIdioma
    {

        private UsuariosBLL bll = new UsuariosBLL();
        private Usuario usuarioSeleccionado = null;

        public UI_GestionUsuarios()
        {
            InitializeComponent();
            datagvUsuariosSistem.CurrentCellDirtyStateChanged += datagvUsuariosSistem_CurrentCellDirtyStateChanged;
            //datagvUsuariosSistem.CellValueChanged += datagvUsuariosSistem_CellValueChanged;
        }

        private void datagvUsuariosSistem_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (datagvUsuariosSistem.IsCurrentCellDirty)
            {
                datagvUsuariosSistem.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void UI_GestionUsuarios_Load(object sender, EventArgs e)
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

            ActualizarDGVClientes();
        }

        public void ActualizarIdioma()
        {
            TraductorDeControles.Traducir(this);
        }

        private void UI_GestionUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
        }


        private void btnRegistrarUser_Click(object sender, EventArgs e)
        {
            AbrirFormRegistro();
        }

        private void AbrirFormRegistro()
        {
            DialogResult resultado;

            using (var form = new UI_Registrar())
            {
                resultado = form.ShowDialog();
            }
            if (resultado == DialogResult.OK) { ActualizarDGVClientes(); }
        }

        private void ActualizarDGVClientes()
        {
            datagvUsuariosSistem.DataSource = null;
            datagvUsuariosSistem.DataSource = bll.ListarParaDGV();
        }

        private void datagvUsuariosSistem_SelectionChanged(object sender, EventArgs e)
        {
            if (datagvUsuariosSistem.CurrentRow == null) return;

            usuarioSeleccionado = datagvUsuariosSistem.CurrentRow.DataBoundItem as Usuario;
        }

        private void datagvUsuariosSistem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataRowView fila = datagvUsuariosSistem.Rows[e.RowIndex].DataBoundItem as DataRowView;

            if (fila == null) return;

            usuarioSeleccionado = new Usuario();

            usuarioSeleccionado.UsuarioId = Convert.ToInt32(fila["UsuarioId"]);
            usuarioSeleccionado.NombreUsuario = fila["NombreUsuario"].ToString();
            usuarioSeleccionado.Email = fila["Email"].ToString();
            usuarioSeleccionado.IdiomaPreferido = fila["IdiomaPreferido"].ToString();
            usuarioSeleccionado.IntentosFallidos = Convert.ToInt32(fila["IntentosFallidos"]);
            usuarioSeleccionado.Estado = Convert.ToBoolean(fila["Estado"]);

            bool estado = Convert.ToBoolean(fila["Estado"]);
            //MessageBox.Show($"{estado}");

            if (estado)
            {
                bll.HabilitarUsuario(usuarioSeleccionado.UsuarioId);
                MessageBox.Show(TraductorDeControles.ObtenerTexto("MSG_UsuarioHabilitado", "MSG_UsuarioHabilitado"));
            }

            else if (!estado)
            {
                bll.DeshabilitarUsuario(usuarioSeleccionado.UsuarioId);
                MessageBox.Show(TraductorDeControles.ObtenerTexto("MSG_UsuarioDeshabilitado", "MSG_UsuarioDeshabilitado"));

            }


            //MessageBox.Show($"Usuario seleccionado: {usuarioSeleccionado.UsuarioId}");
        }
    }
}
