namespace BellezaTotal_UI
{
    partial class UI_Analiticas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.datetFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.datetFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.chartServicios = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCabinas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.lblSinDatos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCabinas)).BeginInit();
            this.SuspendLayout();
            // 
            // datetFechaHasta
            // 
            this.datetFechaHasta.Location = new System.Drawing.Point(25, 126);
            this.datetFechaHasta.Name = "datetFechaHasta";
            this.datetFechaHasta.Size = new System.Drawing.Size(257, 22);
            this.datetFechaHasta.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.label2.Location = new System.Drawing.Point(20, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 26);
            this.label2.TabIndex = 18;
            this.label2.Text = "Fecha hasta";
            // 
            // datetFechaDesde
            // 
            this.datetFechaDesde.Location = new System.Drawing.Point(25, 63);
            this.datetFechaDesde.Name = "datetFechaDesde";
            this.datetFechaDesde.Size = new System.Drawing.Size(257, 22);
            this.datetFechaDesde.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.label4.Location = new System.Drawing.Point(20, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 26);
            this.label4.TabIndex = 16;
            this.label4.Text = "Fecha desde";
            // 
            // chartServicios
            // 
            chartArea1.Name = "ChartArea1";
            this.chartServicios.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartServicios.Legends.Add(legend1);
            this.chartServicios.Location = new System.Drawing.Point(12, 236);
            this.chartServicios.Name = "chartServicios";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartServicios.Series.Add(series1);
            this.chartServicios.Size = new System.Drawing.Size(469, 552);
            this.chartServicios.TabIndex = 20;
            // 
            // chartCabinas
            // 
            chartArea2.Name = "ChartArea1";
            this.chartCabinas.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartCabinas.Legends.Add(legend2);
            this.chartCabinas.Location = new System.Drawing.Point(487, 236);
            this.chartCabinas.Name = "chartCabinas";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartCabinas.Series.Add(series2);
            this.chartCabinas.Size = new System.Drawing.Size(420, 552);
            this.chartCabinas.TabIndex = 21;
            this.chartCabinas.Text = "chartCabinas";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(13, 161);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(468, 69);
            this.btnConsultar.TabIndex = 22;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            // 
            // lblSinDatos
            // 
            this.lblSinDatos.AutoSize = true;
            this.lblSinDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSinDatos.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinDatos.ForeColor = System.Drawing.Color.Red;
            this.lblSinDatos.Location = new System.Drawing.Point(599, 59);
            this.lblSinDatos.Name = "lblSinDatos";
            this.lblSinDatos.Size = new System.Drawing.Size(272, 28);
            this.lblSinDatos.TabIndex = 23;
            this.lblSinDatos.Text = "No se han encontrado datos";
            this.lblSinDatos.Visible = false;
            // 
            // UI_Analiticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(199)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1151, 800);
            this.Controls.Add(this.lblSinDatos);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.chartCabinas);
            this.Controls.Add(this.chartServicios);
            this.Controls.Add(this.datetFechaHasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datetFechaDesde);
            this.Controls.Add(this.label4);
            this.Name = "UI_Analiticas";
            this.Text = "UI_Analiticas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_Analiticas_FormClosing);
            this.Load += new System.EventHandler(this.UI_Analiticas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCabinas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datetFechaHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datetFechaDesde;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartServicios;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCabinas;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label lblSinDatos;
    }
}