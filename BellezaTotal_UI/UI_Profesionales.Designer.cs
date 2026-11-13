namespace BellezaTotal_UI
{
    partial class UI_Profesionales
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
            this.LabelProfesionales = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboxEspecialidades = new System.Windows.Forms.ComboBox();
            this.LabelEspecialidades = new System.Windows.Forms.Label();
            this.datagvUsuariosNoProf = new System.Windows.Forms.DataGridView();
            this.LabelUserSinAsignar = new System.Windows.Forms.Label();
            this.btnProfesionalizar = new System.Windows.Forms.Button();
            this.btnEliminarUsuarioP = new System.Windows.Forms.Button();
            this.LabelProfsSalon = new System.Windows.Forms.Label();
            this.dtvProfesionalesSalon = new System.Windows.Forms.DataGridView();
            this.btnDarBajaP = new System.Windows.Forms.Button();
            this.btnModificarProfesional = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagvUsuariosNoProf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtvProfesionalesSalon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.LabelProfesionales);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 109);
            this.panel1.TabIndex = 9;
            // 
            // LabelProfesionales
            // 
            this.LabelProfesionales.AutoSize = true;
            this.LabelProfesionales.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelProfesionales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelProfesionales.Location = new System.Drawing.Point(352, 29);
            this.LabelProfesionales.Name = "LabelProfesionales";
            this.LabelProfesionales.Size = new System.Drawing.Size(349, 42);
            this.LabelProfesionales.TabIndex = 3;
            this.LabelProfesionales.Text = "Profesionales del salón";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BellezaTotal_UI.Properties.Resources.fotoUser;
            this.pictureBox1.Location = new System.Drawing.Point(935, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // comboxEspecialidades
            // 
            this.comboxEspecialidades.FormattingEnabled = true;
            this.comboxEspecialidades.Location = new System.Drawing.Point(10, 176);
            this.comboxEspecialidades.Name = "comboxEspecialidades";
            this.comboxEspecialidades.Size = new System.Drawing.Size(256, 24);
            this.comboxEspecialidades.TabIndex = 10;
            // 
            // LabelEspecialidades
            // 
            this.LabelEspecialidades.AutoSize = true;
            this.LabelEspecialidades.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelEspecialidades.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelEspecialidades.Location = new System.Drawing.Point(5, 147);
            this.LabelEspecialidades.Name = "LabelEspecialidades";
            this.LabelEspecialidades.Size = new System.Drawing.Size(135, 26);
            this.LabelEspecialidades.TabIndex = 12;
            this.LabelEspecialidades.Text = "Especialiades";
            // 
            // datagvUsuariosNoProf
            // 
            this.datagvUsuariosNoProf.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.datagvUsuariosNoProf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvUsuariosNoProf.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.datagvUsuariosNoProf.Location = new System.Drawing.Point(283, 176);
            this.datagvUsuariosNoProf.Name = "datagvUsuariosNoProf";
            this.datagvUsuariosNoProf.RowHeadersWidth = 51;
            this.datagvUsuariosNoProf.RowTemplate.Height = 24;
            this.datagvUsuariosNoProf.Size = new System.Drawing.Size(710, 303);
            this.datagvUsuariosNoProf.TabIndex = 13;
            // 
            // LabelUserSinAsignar
            // 
            this.LabelUserSinAsignar.AutoSize = true;
            this.LabelUserSinAsignar.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelUserSinAsignar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelUserSinAsignar.Location = new System.Drawing.Point(278, 147);
            this.LabelUserSinAsignar.Name = "LabelUserSinAsignar";
            this.LabelUserSinAsignar.Size = new System.Drawing.Size(198, 26);
            this.LabelUserSinAsignar.TabIndex = 14;
            this.LabelUserSinAsignar.Text = "Usuarios sin asignar";
            // 
            // btnProfesionalizar
            // 
            this.btnProfesionalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnProfesionalizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProfesionalizar.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfesionalizar.Location = new System.Drawing.Point(10, 378);
            this.btnProfesionalizar.Name = "btnProfesionalizar";
            this.btnProfesionalizar.Size = new System.Drawing.Size(267, 29);
            this.btnProfesionalizar.TabIndex = 15;
            this.btnProfesionalizar.Text = "Profesionalizar usuario";
            this.btnProfesionalizar.UseVisualStyleBackColor = false;
            this.btnProfesionalizar.Click += new System.EventHandler(this.btnProfesionalizar_Click);
            // 
            // btnEliminarUsuarioP
            // 
            this.btnEliminarUsuarioP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnEliminarUsuarioP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminarUsuarioP.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarUsuarioP.Location = new System.Drawing.Point(10, 412);
            this.btnEliminarUsuarioP.Name = "btnEliminarUsuarioP";
            this.btnEliminarUsuarioP.Size = new System.Drawing.Size(267, 29);
            this.btnEliminarUsuarioP.TabIndex = 16;
            this.btnEliminarUsuarioP.Text = "Eliminar usuario";
            this.btnEliminarUsuarioP.UseVisualStyleBackColor = false;
            // 
            // LabelProfsSalon
            // 
            this.LabelProfsSalon.AutoSize = true;
            this.LabelProfsSalon.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelProfsSalon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelProfsSalon.Location = new System.Drawing.Point(278, 544);
            this.LabelProfsSalon.Name = "LabelProfsSalon";
            this.LabelProfsSalon.Size = new System.Drawing.Size(226, 26);
            this.LabelProfsSalon.TabIndex = 18;
            this.LabelProfsSalon.Text = "Profesionales del salón";
            // 
            // dtvProfesionalesSalon
            // 
            this.dtvProfesionalesSalon.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtvProfesionalesSalon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtvProfesionalesSalon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.dtvProfesionalesSalon.Location = new System.Drawing.Point(283, 573);
            this.dtvProfesionalesSalon.Name = "dtvProfesionalesSalon";
            this.dtvProfesionalesSalon.RowHeadersWidth = 51;
            this.dtvProfesionalesSalon.RowTemplate.Height = 24;
            this.dtvProfesionalesSalon.Size = new System.Drawing.Size(710, 303);
            this.dtvProfesionalesSalon.TabIndex = 17;
            // 
            // btnDarBajaP
            // 
            this.btnDarBajaP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnDarBajaP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDarBajaP.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDarBajaP.Location = new System.Drawing.Point(10, 847);
            this.btnDarBajaP.Name = "btnDarBajaP";
            this.btnDarBajaP.Size = new System.Drawing.Size(267, 29);
            this.btnDarBajaP.TabIndex = 20;
            this.btnDarBajaP.Text = "Dar de baja profesional";
            this.btnDarBajaP.UseVisualStyleBackColor = false;
            this.btnDarBajaP.Click += new System.EventHandler(this.btnDarBaja_Click);
            // 
            // btnModificarProfesional
            // 
            this.btnModificarProfesional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnModificarProfesional.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificarProfesional.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarProfesional.Location = new System.Drawing.Point(12, 810);
            this.btnModificarProfesional.Name = "btnModificarProfesional";
            this.btnModificarProfesional.Size = new System.Drawing.Size(265, 31);
            this.btnModificarProfesional.TabIndex = 19;
            this.btnModificarProfesional.Text = "Modifcar profesional";
            this.btnModificarProfesional.UseVisualStyleBackColor = false;
            // 
            // UI_Profesionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(199)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1029, 1037);
            this.Controls.Add(this.btnDarBajaP);
            this.Controls.Add(this.btnModificarProfesional);
            this.Controls.Add(this.LabelProfsSalon);
            this.Controls.Add(this.dtvProfesionalesSalon);
            this.Controls.Add(this.btnEliminarUsuarioP);
            this.Controls.Add(this.btnProfesionalizar);
            this.Controls.Add(this.LabelUserSinAsignar);
            this.Controls.Add(this.datagvUsuariosNoProf);
            this.Controls.Add(this.LabelEspecialidades);
            this.Controls.Add(this.comboxEspecialidades);
            this.Controls.Add(this.panel1);
            this.Name = "UI_Profesionales";
            this.Text = "UI_Profesionales";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_Profesionales_FormClosing);
            this.Load += new System.EventHandler(this.UI_PRofesionales_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagvUsuariosNoProf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtvProfesionalesSalon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelProfesionales;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboxEspecialidades;
        private System.Windows.Forms.Label LabelEspecialidades;
        private System.Windows.Forms.DataGridView datagvUsuariosNoProf;
        private System.Windows.Forms.Label LabelUserSinAsignar;
        private System.Windows.Forms.Button btnProfesionalizar;
        private System.Windows.Forms.Button btnEliminarUsuarioP;
        private System.Windows.Forms.Label LabelProfsSalon;
        private System.Windows.Forms.DataGridView dtvProfesionalesSalon;
        private System.Windows.Forms.Button btnDarBajaP;
        private System.Windows.Forms.Button btnModificarProfesional;
    }
}