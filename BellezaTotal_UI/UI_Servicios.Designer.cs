namespace BellezaTotal_UI
{
    partial class UI_Servicios
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
            this.LabelServicios = new System.Windows.Forms.Label();
            this.LabelCatalogoS = new System.Windows.Forms.Label();
            this.datagvServicios = new System.Windows.Forms.DataGridView();
            this.btnAgregarServicio = new System.Windows.Forms.Button();
            this.btnModificarServicio = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.LabelServicios);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 102);
            this.panel1.TabIndex = 4;
            // 
            // LabelServicios
            // 
            this.LabelServicios.AutoSize = true;
            this.LabelServicios.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelServicios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelServicios.Location = new System.Drawing.Point(360, 32);
            this.LabelServicios.Name = "LabelServicios";
            this.LabelServicios.Size = new System.Drawing.Size(321, 42);
            this.LabelServicios.TabIndex = 4;
            this.LabelServicios.Text = "Servicios disponibles";
            // 
            // LabelCatalogoS
            // 
            this.LabelCatalogoS.AutoSize = true;
            this.LabelCatalogoS.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCatalogoS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelCatalogoS.Location = new System.Drawing.Point(164, 121);
            this.LabelCatalogoS.Name = "LabelCatalogoS";
            this.LabelCatalogoS.Size = new System.Drawing.Size(94, 26);
            this.LabelCatalogoS.TabIndex = 18;
            this.LabelCatalogoS.Text = "Catálogo";
            // 
            // datagvServicios
            // 
            this.datagvServicios.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.datagvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvServicios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.datagvServicios.Location = new System.Drawing.Point(169, 150);
            this.datagvServicios.Name = "datagvServicios";
            this.datagvServicios.RowHeadersWidth = 51;
            this.datagvServicios.RowTemplate.Height = 24;
            this.datagvServicios.Size = new System.Drawing.Size(711, 334);
            this.datagvServicios.TabIndex = 17;
            // 
            // btnAgregarServicio
            // 
            this.btnAgregarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnAgregarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregarServicio.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarServicio.Location = new System.Drawing.Point(169, 507);
            this.btnAgregarServicio.Name = "btnAgregarServicio";
            this.btnAgregarServicio.Size = new System.Drawing.Size(176, 52);
            this.btnAgregarServicio.TabIndex = 20;
            this.btnAgregarServicio.Text = "Agregar servicio";
            this.btnAgregarServicio.UseVisualStyleBackColor = false;
            this.btnAgregarServicio.Click += new System.EventHandler(this.btnAgregarServicio_Click);
            // 
            // btnModificarServicio
            // 
            this.btnModificarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnModificarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificarServicio.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarServicio.Location = new System.Drawing.Point(704, 507);
            this.btnModificarServicio.Name = "btnModificarServicio";
            this.btnModificarServicio.Size = new System.Drawing.Size(176, 52);
            this.btnModificarServicio.TabIndex = 19;
            this.btnModificarServicio.Text = "Modificar servicio";
            this.btnModificarServicio.UseVisualStyleBackColor = false;
            this.btnModificarServicio.Click += new System.EventHandler(this.btnModificarServicio_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BellezaTotal_UI.Properties.Resources.fotoAgenda;
            this.pictureBox1.Location = new System.Drawing.Point(933, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UI_Servicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(199)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1020, 998);
            this.Controls.Add(this.btnAgregarServicio);
            this.Controls.Add(this.btnModificarServicio);
            this.Controls.Add(this.LabelCatalogoS);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.datagvServicios);
            this.Name = "UI_Servicios";
            this.Text = "UI_Servicios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_Servicios_FormClosing);
            this.Load += new System.EventHandler(this.UI_Servicios_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelServicios;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LabelCatalogoS;
        private System.Windows.Forms.DataGridView datagvServicios;
        private System.Windows.Forms.Button btnAgregarServicio;
        private System.Windows.Forms.Button btnModificarServicio;
    }
}