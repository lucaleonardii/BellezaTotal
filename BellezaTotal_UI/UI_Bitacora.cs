using BellezaTotal_BE.Auditoria;
using BellezaTotal_BLL.Clases;
using BellezaTotal_SEC;
using BellezaTotal_BE.Idiomas;

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
    

    public partial class UI_Bitacora : Form, IObserverIdioma
    {
        
        private readonly BitacoraBLL _logica = new BitacoraBLL();
        private List<string> _nombresUsuarios = new List<string>();
        private string _claveAviso;   
        private bool _cargando;       

        public UI_Bitacora()
        {
            InitializeComponent();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            var listaDatos = (datagvBitacora.DataSource as IEnumerable<Bitacora>)?.ToList();

            if (listaDatos == null || listaDatos.Count == 0)
            {
                MessageBox.Show("No hay datos en la grilla para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog dialogGuardar = new SaveFileDialog())
            {
                dialogGuardar.Filter = "Archivos PDF (*.pdf)|*.pdf";
                dialogGuardar.Title = "Guardar reporte como PDF";
                dialogGuardar.FileName = $"Bitacora_BellezaTotal_{DateTime.Now:ddMMyyyy}.pdf";

                if (dialogGuardar.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        PDF_BLL exportador = new PDF_BLL();
                        exportador.ExportarBitacora(listaDatos, dialogGuardar.FileName);

                        MessageBox.Show("El PDF se generó y guardó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public class OpcionFiltro<T>
        {
            public string Texto { get; set; }
            public T Valor { get; set; }
        }


        public void ActualizarIdioma()
        {
            _cargando = true;
            try
            {
                
                string usuarioSeleccionado = ObtenerUsuarioFiltro();
                SeveridadBitacora? severidadSeleccionada = ObtenerSeveridadFiltro();

                TraductorDeControles.Traducir(this);

                CargarOpcionesUsuarios();
                CargarOpcionesSeveridad();
                SeleccionarOpcion(cboxUsuarios, usuarioSeleccionado);
                SeleccionarOpcion(cboxSeveridad, severidadSeleccionada);

                ActualizarAviso();
            }
            finally
            {
                _cargando = false;
            }
        }

        private void Buscar()
        {
            if (_cargando) return;

            _claveAviso = null;

            if (datetFechaDesde.Value.Date > datetFechaHasta.Value.Date)
            {
                datagvBitacora.DataSource = null;
                _claveAviso = "FormBitacora.fechasInvalidas";
                ActualizarAviso();
                return;
            }

            FiltroBitacora filtro = new FiltroBitacora
            {
                FechaDesde = datetFechaDesde.Value.Date,
                FechaHasta = datetFechaHasta.Value.Date,
                NombreUsuario = ObtenerUsuarioFiltro(),
                Severidad = ObtenerSeveridadFiltro()
            };

            try
            {
                List<Bitacora> registros = _logica.Consultar(filtro);
                datagvBitacora.DataSource = registros;

       
                if (registros.Count == 0)
                    _claveAviso = "FormBitacora.sinResultados";
            }
            catch (Exception excepcion)
            {
                datagvBitacora.DataSource = null;
                MessageBox.Show(excepcion.Message, "Bitácora", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ActualizarAviso();
        }



        private string ObtenerUsuarioFiltro()
        {
            OpcionFiltro<string> opcionElegida = cboxUsuarios.SelectedItem as OpcionFiltro<string>;
            return opcionElegida?.Valor;   
        }

        private SeveridadBitacora? ObtenerSeveridadFiltro()
        {
            OpcionFiltro<SeveridadBitacora?> opcionElegida = cboxSeveridad.SelectedItem as OpcionFiltro<SeveridadBitacora?>;
            return opcionElegida?.Valor;
        }

        private void CargarOpcionesUsuarios()
        {
            List<OpcionFiltro<string>> opciones = new List<OpcionFiltro<string>>
        {
            new OpcionFiltro<string> { Texto = IdiomaManager.Instancia.Traducir("Comun.Cualquiera"), Valor = null }
        };

            opciones.AddRange(_nombresUsuarios.Select(nombreUsuario =>
                new OpcionFiltro<string> { Texto = nombreUsuario, Valor = nombreUsuario }));

            cboxUsuarios.DataSource = opciones;
        }

        private void CargarOpcionesSeveridad()
        {
            IdiomaManager idiomas = IdiomaManager.Instancia;

            cboxSeveridad.DataSource = new List<OpcionFiltro<SeveridadBitacora?>>
        {
            new OpcionFiltro<SeveridadBitacora?> { Texto = idiomas.Traducir("Comun.Cualquiera"), Valor = null },
            new OpcionFiltro<SeveridadBitacora?> { Texto = idiomas.Traducir("Severidad.Info"), Valor = SeveridadBitacora.Info },
            new OpcionFiltro<SeveridadBitacora?> { Texto = idiomas.Traducir("Severidad.Warning"), Valor = SeveridadBitacora.Warning },
            new OpcionFiltro<SeveridadBitacora?> { Texto = idiomas.Traducir("Severidad.Error"), Valor = SeveridadBitacora.Error }
        };
        }

        private void SeleccionarOpcion<T>(ComboBox combo, T valorASeleccionar)
        {
            for (int indice = 0; indice < combo.Items.Count; indice++)
            {
                OpcionFiltro<T> opcion = (OpcionFiltro<T>)combo.Items[indice];

                if (EqualityComparer<T>.Default.Equals(opcion.Valor, valorASeleccionar))
                {
                    combo.SelectedIndex = indice;
                    return;
                }
            }

            combo.SelectedIndex = 0;   
        }

        private void ConfigurarColumnas()
        {
            datagvBitacora.AutoGenerateColumns = false;
            datagvBitacora.AllowUserToAddRows = false;
            datagvBitacora.AllowUserToDeleteRows = false;
            datagvBitacora.ReadOnly = true;
            datagvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            datagvBitacora.Columns.Clear();
            AgregarColumna("colFechaHora", "FechaHora", "Fecha y hora", 150, "dd/MM/yyyy HH:mm:ss");
            AgregarColumna("colUsuario", "NombreUsuario", "Usuario", 110, null);
            AgregarColumna("colSeveridad", "Severidad", "Severidad", 90, null);
            AgregarColumna("colAccion", "Accion", "Acción", 160, null);

            DataGridViewTextBoxColumn columnaDescripcion = AgregarColumna("colDescripcion", "Descripcion", "Descripción", 100, null);
            columnaDescripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private DataGridViewTextBoxColumn AgregarColumna(string nombreColumna, string propiedad,
                                                         string encabezado, int ancho, string formato)
        {
            DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn
            {
                Name = nombreColumna,            
                DataPropertyName = propiedad,
                HeaderText = encabezado,         
                Width = ancho
            };

            if (formato != null)
                columna.DefaultCellStyle.Format = formato;

            datagvBitacora.Columns.Add(columna);
            return columna;
        }

        private void ActualizarAviso()
        {
            lblAviso.ForeColor = Color.Red;
            lblAviso.Text = _claveAviso == null
                ? string.Empty
                : IdiomaManager.Instancia.Traducir(_claveAviso);
        }

        private void UI_Bitacora_Load(object sender, EventArgs e)
        {
            CargarDGV();
        }

        private void CargarDGV()
        {
            datagvBitacora.DataSource = _logica.ObtenerTodas();
            IdiomaManager.Instancia.Suscribir(this);

            _cargando = true;
            try
            {
                
                _nombresUsuarios = _logica.ObtenerNombresUsuarios();

                cboxUsuarios.DropDownStyle = ComboBoxStyle.DropDownList;
                cboxSeveridad.DropDownStyle = ComboBoxStyle.DropDownList;
                cboxUsuarios.DisplayMember = "Texto";
                cboxSeveridad.DisplayMember = "Texto";


                datetFechaHasta.Value = DateTime.Today;
                datetFechaDesde.Value = DateTime.Today.AddDays(-7);

                ConfigurarColumnas();
                CargarOpcionesUsuarios();
                CargarOpcionesSeveridad();
                TraductorDeControles.Traducir(this);
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message, "Bitácora", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }
            finally
            {
                _cargando = false;
            }

            Buscar();
        }

        private void UI_Bitacora_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
        }

        private void datetFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void datetFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void cboxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        private void cboxSeveridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
