using BellezaTotal_BE.Familias;
using BellezaTotal_BE.Idiomas;
using BellezaTotal_BLL.Clases;
using BellezaTotal_SEC;
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
    public partial class UI_GestionFamilias : Form, IObserverIdioma
    {
        public UI_GestionFamilias()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        //TO DO = traducir el lblModo segun el idioma seleccionado
        public void ActualizarIdioma()
        {
            TraductorDeControles.Traducir(this);
        }


        private readonly FamiliasBLL _logica = new FamiliasBLL();
        private CatalogoPermisos _catalogo;

        private Familia _familiaEnEdicion;   
        private bool _editorActivo;
        private bool _cargando;              
        private bool _hayCambios;

        private void ActualizarClboxFamilias()
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_cargando) return;

            if (e.Node.Tag is Familia familiaSeleccionada)
                PrepararEditor(familiaSeleccionada);
        }

        private void tvFamilias_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (_cargando) return;

            if (e.Node.Tag is Familia && _hayCambios && !ConfirmarDescartarCambios())
                e.Cancel = true;   
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (!_cargando) MarcarCambios();
        }

        private void clbPatentes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!_cargando) MarcarCambios();
        }

        private void clbFamilias_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!_cargando) MarcarCambios();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (_hayCambios && !ConfirmarDescartarCambios()) return;

            _cargando = true;
            tvFamilias.SelectedNode = null;
            _cargando = false;

            PrepararEditor(null);
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            List<int> idsPatentes = clbPatentes.CheckedItems.Cast<Patente>()
            .Select(patenteTildada => patenteTildada.PermisoId).ToList();

            List<int> idsFamiliasHijas = clbFamiliasHijas.CheckedItems.Cast<Familia>()
                .Select(familiaTildada => familiaTildada.PermisoId).ToList();

            try
            {
                int familiaIdGuardada;

                if (_familiaEnEdicion == null)
                {
                    familiaIdGuardada = _logica.Crear(txtNombre.Text, idsPatentes, idsFamiliasHijas);
                }
                else
                {
                    familiaIdGuardada = _familiaEnEdicion.PermisoId;
                    _logica.Modificar(familiaIdGuardada, txtNombre.Text, idsPatentes, idsFamiliasHijas);
                }

                CargarCatalogo(familiaIdGuardada);   // vuelve a leer la base y deja la familia seleccionada
                MessageBox.Show("Familia guardada. Los usuarios verán los cambios al iniciar sesión nuevamente.",
                    "Gestión de familias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Gestión de familias", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_familiaEnEdicion == null) return;

            DialogResult respuesta = MessageBox.Show(
                $"¿Eliminar la familia {_familiaEnEdicion.Nombre}?", "Gestión de familias",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes) return;

            try
            {
                _logica.Eliminar(_familiaEnEdicion.PermisoId);
                CargarCatalogo(null);
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Gestión de familias", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UI_GestionFamilias_Load(object sender, EventArgs e)
        {
            clbPatentes.DisplayMember = "Nombre";
            clbFamiliasHijas.DisplayMember = "Nombre";

            try
            {
                CargarCatalogo(null);
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Gestión de familias", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
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

        private void CargarCatalogo(int? familiaIdASeleccionar)
        {
            _cargando = true;
            try
            {
                _catalogo = _logica.ObtenerCatalogo();

                tvFamilias.Nodes.Clear();
                foreach (Familia familia in _catalogo.Familias)
                    tvFamilias.Nodes.Add(CrearNodo(familia));
                tvFamilias.ExpandAll();

                clbPatentes.Items.Clear();
                foreach (Patente patente in _catalogo.Patentes)
                    clbPatentes.Items.Add(patente);
            }
            finally
            {
                _cargando = false;
            }

            Familia familiaASeleccionar = familiaIdASeleccionar.HasValue
                ? _catalogo.Familias.FirstOrDefault(familia => familia.PermisoId == familiaIdASeleccionar.Value)
                : null;

            if (familiaASeleccionar == null)
            {
                DesactivarEditor();
                return;
            }

            _cargando = true;
            foreach (TreeNode nodoRaiz in tvFamilias.Nodes)
            {
                if (((Familia)nodoRaiz.Tag).PermisoId == familiaASeleccionar.PermisoId)
                    tvFamilias.SelectedNode = nodoRaiz;
            }
            _cargando = false;

            PrepararEditor(familiaASeleccionar);
        }

        private TreeNode CrearNodo(Permiso permiso)
        {
            TreeNode nodo = new TreeNode(permiso.Nombre) { Tag = permiso };

            if (permiso is Familia familia)
            {
                foreach (Permiso permisoHijo in familia.Hijos)
                    nodo.Nodes.Add(CrearNodo(permisoHijo));
            }
            else
            {
                nodo.ForeColor = Color.DimGray;   // las patentes se distinguen de las familias
            }

            return nodo;
        }

        private void PrepararEditor(Familia familia)
        {
            _cargando = true;
            try
            {
                _familiaEnEdicion = familia;
                _editorActivo = true;
                txtNombre.Text = familia != null ? familia.Nombre : string.Empty;

                HashSet<int> idsPatentesDirectas = familia == null
                    ? new HashSet<int>()
                    : new HashSet<int>(familia.Hijos.OfType<Patente>().Select(patente => patente.PermisoId));

                for (int indice = 0; indice < clbPatentes.Items.Count; indice++)
                {
                    Patente patente = (Patente)clbPatentes.Items[indice];
                    clbPatentes.SetItemChecked(indice, idsPatentesDirectas.Contains(patente.PermisoId));
                }

                HashSet<int> idsFamiliasHijasDirectas = familia == null
                    ? new HashSet<int>()
                    : new HashSet<int>(familia.Hijos.OfType<Familia>().Select(familiaHija => familiaHija.PermisoId));

                clbFamiliasHijas.Items.Clear();
                foreach (Familia candidata in _catalogo.Familias)
                {
                    bool esLaMisma = familia != null && candidata.PermisoId == familia.PermisoId;
                    bool cerrariaUnCiclo = familia != null && candidata.ContieneFamilia(familia);

                    if (esLaMisma || cerrariaUnCiclo) continue;

                    clbFamiliasHijas.Items.Add(candidata, idsFamiliasHijasDirectas.Contains(candidata.PermisoId));
                }

                _hayCambios = false;
            }
            finally
            {
                _cargando = false;
            }

            ActualizarEstadoControles();
        }

        private void DesactivarEditor()
        {
            _cargando = true;
            try
            {
                _familiaEnEdicion = null;
                _editorActivo = false;
                _hayCambios = false;
                txtNombre.Clear();

                for (int indice = 0; indice < clbPatentes.Items.Count; indice++)
                    clbPatentes.SetItemChecked(indice, false);
                clbFamiliasHijas.Items.Clear();
            }
            finally
            {
                _cargando = false;
            }

            ActualizarEstadoControles();
        }
        private void MarcarCambios()
        {
            _hayCambios = true;
            ActualizarEstadoControles();
        }

        private bool ConfirmarDescartarCambios()
        {
            DialogResult respuesta = MessageBox.Show(
                "Hay cambios sin guardar. ¿Desea descartarlos?", "Gestión de familias",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return respuesta == DialogResult.Yes;
        }

        private void ActualizarEstadoControles()
        {
            panelEditor.Enabled = _editorActivo;
            btnGuardar.Enabled = _editorActivo && _hayCambios;
            btnEliminar.Enabled = _editorActivo && _familiaEnEdicion != null;

            if (!_editorActivo)
                lblModo.Text = "Seleccione una familia o presione Nuevo";
            else if (_familiaEnEdicion == null)
                lblModo.Text = "Nueva familia";
            else
                lblModo.Text = $"Editando {_familiaEnEdicion.Nombre}";
        }

        private void UI_GestionFamilias_FormClosing(object sender, FormClosingEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
            if (_hayCambios && !ConfirmarDescartarCambios())
                e.Cancel = true;
        }
    }
}

