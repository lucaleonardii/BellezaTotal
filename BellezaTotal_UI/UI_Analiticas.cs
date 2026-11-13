using BellezaTotal_BE.Excepciones;
using BellezaTotal_BE.Idiomas;
using BellezaTotal_BLL.Clases;
using BellezaTotal_SEC.Clases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BellezaTotal_UI
{
    public partial class UI_Analiticas : Form, IObserverIdioma
    {
        private readonly EstadisticasBLL bll = new EstadisticasBLL();

        private List<KeyValuePair<string, int>> servicios = new List<KeyValuePair<string, int>>();
        private List<KeyValuePair<int, double>> cabinas = new List<KeyValuePair<int, double>>();

        private static readonly Color Lila = Color.FromArgb(175, 151, 189);
        private static readonly Color LilaOscuro = Color.FromArgb(129, 97, 146);

        public UI_Analiticas()
        {
            InitializeComponent();

            Load -= UI_Analiticas_Load;
            Load += UI_Analiticas_Load;

            FormClosing -= UI_Analiticas_FormClosing;
            FormClosing += UI_Analiticas_FormClosing;

            btnConsultar.Click -= btnConsultar_Click;
            btnConsultar.Click += btnConsultar_Click;
        }

        private void UI_Analiticas_Load(object sender, EventArgs e)
        {
            if (!AdministradorDeSesion.Instancia.HaySesionActiva)
            {
                Close();
                return;
            }

            ConfigurarChartBarras(chartServicios);
            ConfigurarChartTorta(chartCabinas);

            datetFechaHasta.Value = DateTime.Today;
            datetFechaDesde.Value = DateTime.Today.AddDays(-30);

            Consultar();

            IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
        }

        private void UI_Analiticas_FormClosing(object sender, FormClosingEventArgs e)
        {
            IdiomaManager.Instancia.Desuscribir(this);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        public void ActualizarIdioma()
        {
            TraductorDeControles.Traducir(this);

            btnConsultar.Text = Texto("UI_Analiticas.btnConsultar", "Consultar");
            Graficar();
        }

        private void ConfigurarChartBarras(Chart chart)
        {
            EstiloBase(chart);

            ChartArea area = chart.ChartAreas.Add("Area");
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.Interval = 1;
            area.AxisX.IsReversed = true;               
            area.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            area.AxisY.LabelStyle.Format = "0";
            area.AxisY.Minimum = 0;

            Series serie = chart.Series.Add("Servicios");
            serie.ChartType = SeriesChartType.Bar;
            serie.Color = LilaOscuro;
            serie.IsValueShownAsLabel = true;
        }

        private void ConfigurarChartTorta(Chart chart)
        {
            EstiloBase(chart);

            chart.ChartAreas.Add("Area");
            chart.PaletteCustomColors = new Color[]
            {
                Color.FromArgb(129, 97, 146), Color.FromArgb(175, 151, 189),
                Color.FromArgb(206, 178, 221), Color.FromArgb(104, 77, 119)
            };
            chart.Palette = ChartColorPalette.None;

            Legend leyenda = new Legend("Leyenda");
            leyenda.Docking = Docking.Right;
            chart.Legends.Add(leyenda);

            Series serie = chart.Series.Add("Cabinas");
            serie.ChartType = SeriesChartType.Pie;
            serie.Legend = "Leyenda";
            serie.LegendText = "#AXISLABEL";
            serie.Label = "#PERCENT{P1}";
            serie["PieLabelStyle"] = "Outside";
        }

        private void EstiloBase(Chart chart)
        {
            chart.BackColor = Color.White;
            chart.BorderlineColor = Lila;
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BorderlineWidth = 1;
            chart.AntiAliasing = AntiAliasingStyles.All;
            chart.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            chart.ChartAreas.Clear();
            chart.Series.Clear();
            chart.Legends.Clear();
        }

        private void Consultar()
        {
            try
            {
                servicios = bll.ServiciosMasSolicitados(datetFechaDesde.Value, datetFechaHasta.Value);
                cabinas = bll.UsoDeCabinas(datetFechaDesde.Value, datetFechaHasta.Value);

                Graficar();
            }
            catch (ExcepcionNegocio ex)
            {
                MessageBox.Show(Texto(ex.Codigo, ex.Codigo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void Graficar()
        {
            Series barras = chartServicios.Series["Servicios"];
            Series torta = chartCabinas.Series["Cabinas"];

            barras.Points.Clear();
            torta.Points.Clear();

            foreach (KeyValuePair<string, int> par in servicios)
                barras.Points.AddXY(par.Key, par.Value);

            string textoCabina = Texto("UI_Analiticas.Cabina", "Cabina");

            foreach (KeyValuePair<int, double> par in cabinas)
                torta.Points.AddXY(textoCabina + " " + par.Key, par.Value);

            chartServicios.Titles.Clear();
            chartServicios.Titles.Add(new Title(Texto("UI_Analiticas.Titulo_Servicios", "Servicios y planes más solicitados")));
            chartServicios.ChartAreas["Area"].AxisY.Title = Texto("UI_Analiticas.Eje_Turnos", "Cantidad de turnos");

            chartCabinas.Titles.Clear();
            chartCabinas.Titles.Add(new Title(Texto("UI_Analiticas.Titulo_Cabinas", "Uso de cabinas")));

            bool hayDatos = servicios.Count > 0 || cabinas.Count > 0;

            lblSinDatos.Text = Texto("UI_Analiticas.SinDatos", "No se encontraron turnos para las fechas indicadas");
            lblSinDatos.Visible = !hayDatos;
        }

        private string Texto(string clave, string valorPorDefecto)
        {
            return TraductorDeControles.ObtenerTexto(clave, valorPorDefecto);
        }
    }
}