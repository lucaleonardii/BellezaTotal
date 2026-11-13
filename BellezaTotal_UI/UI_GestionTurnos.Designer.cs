namespace BellezaTotal_UI
{
    partial class UI_GestionTurnos
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
            this.lTurno = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.datagvTurnos = new System.Windows.Forms.DataGridView();
            this.btnAgregarTurno = new System.Windows.Forms.Button();
            this.btnModificarTurno = new System.Windows.Forms.Button();
            this.btnCancelarTurno = new System.Windows.Forms.Button();
            this.btnAtenderTurno = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvTurnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lTurno);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 102);
            this.panel1.TabIndex = 2;
            // 
            // lTurno
            // 
            this.lTurno.AutoSize = true;
            this.lTurno.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTurno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.lTurno.Location = new System.Drawing.Point(378, 34);
            this.lTurno.Name = "lTurno";
            this.lTurno.Size = new System.Drawing.Size(259, 42);
            this.lTurno.TabIndex = 3;
            this.lTurno.Text = "Turnos del salón";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(154, 129);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(54, 19);
            this.lblFecha.TabIndex = 11;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(236, 125);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(180, 27);
            this.dtpFecha.TabIndex = 12;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // datagvTurnos
            // 
            this.datagvTurnos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.datagvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvTurnos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.datagvTurnos.Location = new System.Drawing.Point(154, 165);
            this.datagvTurnos.Name = "datagvTurnos";
            this.datagvTurnos.RowHeadersWidth = 51;
            this.datagvTurnos.RowTemplate.Height = 24;
            this.datagvTurnos.Size = new System.Drawing.Size(728, 380);
            this.datagvTurnos.TabIndex = 3;
            this.datagvTurnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagvTurnos_CellContentClick);
            // 
            // btnAgregarTurno
            // 
            this.btnAgregarTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnAgregarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregarTurno.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTurno.Location = new System.Drawing.Point(154, 551);
            this.btnAgregarTurno.Name = "btnAgregarTurno";
            this.btnAgregarTurno.Size = new System.Drawing.Size(176, 52);
            this.btnAgregarTurno.TabIndex = 9;
            this.btnAgregarTurno.Text = "Agregar turno";
            this.btnAgregarTurno.UseVisualStyleBackColor = false;
            this.btnAgregarTurno.Click += new System.EventHandler(this.btnAgregarTurno_Click);
            // 
            // btnModificarTurno
            // 
            this.btnModificarTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnModificarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificarTurno.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarTurno.Location = new System.Drawing.Point(338, 551);
            this.btnModificarTurno.Name = "btnModificarTurno";
            this.btnModificarTurno.Size = new System.Drawing.Size(176, 52);
            this.btnModificarTurno.TabIndex = 8;
            this.btnModificarTurno.Text = "Modificar datos";
            this.btnModificarTurno.UseVisualStyleBackColor = false;
            this.btnModificarTurno.Click += new System.EventHandler(this.btnModificarTurno_Click);
            // 
            // btnCancelarTurno
            // 
            this.btnCancelarTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnCancelarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelarTurno.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarTurno.Location = new System.Drawing.Point(522, 551);
            this.btnCancelarTurno.Name = "btnCancelarTurno";
            this.btnCancelarTurno.Size = new System.Drawing.Size(176, 52);
            this.btnCancelarTurno.TabIndex = 13;
            this.btnCancelarTurno.Text = "Cancelar turno";
            this.btnCancelarTurno.UseVisualStyleBackColor = false;
            this.btnCancelarTurno.Click += new System.EventHandler(this.btnCancelarTurno_Click);
            // 
            // btnAtenderTurno
            // 
            this.btnAtenderTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnAtenderTurno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAtenderTurno.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtenderTurno.Location = new System.Drawing.Point(706, 551);
            this.btnAtenderTurno.Name = "btnAtenderTurno";
            this.btnAtenderTurno.Size = new System.Drawing.Size(176, 52);
            this.btnAtenderTurno.TabIndex = 10;
            this.btnAtenderTurno.Text = "Atender turno";
            this.btnAtenderTurno.UseVisualStyleBackColor = false;
            this.btnAtenderTurno.Click += new System.EventHandler(this.btnAtenderTurno_Click);
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
            // UI_GestionTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(199)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1037, 735);
            this.Controls.Add(this.btnAtenderTurno);
            this.Controls.Add(this.btnCancelarTurno);
            this.Controls.Add(this.btnAgregarTurno);
            this.Controls.Add(this.btnModificarTurno);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.datagvTurnos);
            this.Controls.Add(this.panel1);
            this.Name = "UI_GestionTurnos";
            this.Text = "UI_GestionTurnos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_GestionTurnos_FormClosing);
            this.Load += new System.EventHandler(this.UI_GestionTurnos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagvTurnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lTurno;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DataGridView datagvTurnos;
        private System.Windows.Forms.Button btnAgregarTurno;
        private System.Windows.Forms.Button btnModificarTurno;
        private System.Windows.Forms.Button btnCancelarTurno;
        private System.Windows.Forms.Button btnAtenderTurno;
    }
}
