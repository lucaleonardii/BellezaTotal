namespace BellezaTotal_UI
{
    partial class UI_Bitacora
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.datetFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.datetFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.datagvBitacora = new System.Windows.Forms.DataGridView();
            this.btnBuscarBitacora = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxSeveridad = new System.Windows.Forms.ComboBox();
            this.cboxUsuarios = new System.Windows.Forms.ComboBox();
            this.lSeveridad = new System.Windows.Forms.Label();
            this.lblAviso = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagvBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 102);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.label1.Location = new System.Drawing.Point(418, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 42);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bitácora";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BellezaTotal_UI.Properties.Resources.fotoAgenda;
            this.pictureBox1.Location = new System.Drawing.Point(945, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.label4.Location = new System.Drawing.Point(82, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 26);
            this.label4.TabIndex = 12;
            this.label4.Text = "Fecha desde";
            // 
            // datetFechaDesde
            // 
            this.datetFechaDesde.Location = new System.Drawing.Point(87, 145);
            this.datetFechaDesde.Name = "datetFechaDesde";
            this.datetFechaDesde.Size = new System.Drawing.Size(257, 22);
            this.datetFechaDesde.TabIndex = 13;
            this.datetFechaDesde.ValueChanged += new System.EventHandler(this.datetFechaDesde_ValueChanged);
            // 
            // datetFechaHasta
            // 
            this.datetFechaHasta.Location = new System.Drawing.Point(666, 145);
            this.datetFechaHasta.Name = "datetFechaHasta";
            this.datetFechaHasta.Size = new System.Drawing.Size(257, 22);
            this.datetFechaHasta.TabIndex = 15;
            this.datetFechaHasta.ValueChanged += new System.EventHandler(this.datetFechaHasta_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.label2.Location = new System.Drawing.Point(661, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 26);
            this.label2.TabIndex = 14;
            this.label2.Text = "Fecha hasta";
            // 
            // datagvBitacora
            // 
            this.datagvBitacora.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.datagvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvBitacora.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.datagvBitacora.Location = new System.Drawing.Point(87, 283);
            this.datagvBitacora.Name = "datagvBitacora";
            this.datagvBitacora.RowHeadersWidth = 51;
            this.datagvBitacora.RowTemplate.Height = 24;
            this.datagvBitacora.Size = new System.Drawing.Size(836, 391);
            this.datagvBitacora.TabIndex = 16;
            // 
            // btnBuscarBitacora
            // 
            this.btnBuscarBitacora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnBuscarBitacora.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscarBitacora.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarBitacora.Location = new System.Drawing.Point(87, 707);
            this.btnBuscarBitacora.Name = "btnBuscarBitacora";
            this.btnBuscarBitacora.Size = new System.Drawing.Size(364, 49);
            this.btnBuscarBitacora.TabIndex = 17;
            this.btnBuscarBitacora.Text = "Buscar";
            this.btnBuscarBitacora.UseVisualStyleBackColor = false;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExportar.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Location = new System.Drawing.Point(565, 707);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(358, 49);
            this.btnExportar.TabIndex = 18;
            this.btnExportar.Text = "Exportar pdf";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.label3.Location = new System.Drawing.Point(82, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 26);
            this.label3.TabIndex = 19;
            this.label3.Text = "Usuario asociado a la acción:";
            // 
            // cboxSeveridad
            // 
            this.cboxSeveridad.FormattingEnabled = true;
            this.cboxSeveridad.Location = new System.Drawing.Point(393, 218);
            this.cboxSeveridad.Name = "cboxSeveridad";
            this.cboxSeveridad.Size = new System.Drawing.Size(121, 24);
            this.cboxSeveridad.TabIndex = 21;
            this.cboxSeveridad.SelectedIndexChanged += new System.EventHandler(this.cboxSeveridad_SelectedIndexChanged);
            // 
            // cboxUsuarios
            // 
            this.cboxUsuarios.FormattingEnabled = true;
            this.cboxUsuarios.Location = new System.Drawing.Point(393, 188);
            this.cboxUsuarios.Name = "cboxUsuarios";
            this.cboxUsuarios.Size = new System.Drawing.Size(121, 24);
            this.cboxUsuarios.TabIndex = 22;
            this.cboxUsuarios.SelectedIndexChanged += new System.EventHandler(this.cboxUsuarios_SelectedIndexChanged);
            // 
            // lSeveridad
            // 
            this.lSeveridad.AutoSize = true;
            this.lSeveridad.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSeveridad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.lSeveridad.Location = new System.Drawing.Point(82, 214);
            this.lSeveridad.Name = "lSeveridad";
            this.lSeveridad.Size = new System.Drawing.Size(111, 26);
            this.lSeveridad.TabIndex = 23;
            this.lSeveridad.Text = "Severidad:";
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.lblAviso.Location = new System.Drawing.Point(82, 254);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(20, 26);
            this.lblAviso.TabIndex = 24;
            this.lblAviso.Text = "-";
            // 
            // UI_Bitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(199)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1036, 832);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.lSeveridad);
            this.Controls.Add(this.cboxUsuarios);
            this.Controls.Add(this.cboxSeveridad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnBuscarBitacora);
            this.Controls.Add(this.datagvBitacora);
            this.Controls.Add(this.datetFechaHasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datetFechaDesde);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Name = "UI_Bitacora";
            this.Text = "UC_Bitacora";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UI_Bitacora_FormClosed);
            this.Load += new System.EventHandler(this.UI_Bitacora_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagvBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker datetFechaDesde;
        private System.Windows.Forms.DateTimePicker datetFechaHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView datagvBitacora;
        private System.Windows.Forms.Button btnBuscarBitacora;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxSeveridad;
        private System.Windows.Forms.ComboBox cboxUsuarios;
        private System.Windows.Forms.Label lSeveridad;
        private System.Windows.Forms.Label lblAviso;
    }
}