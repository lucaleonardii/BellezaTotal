namespace BellezaTotal_UI
{
    partial class UI_GestionUsuarios
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
            this.LabelUsuarios = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LabelListaU = new System.Windows.Forms.Label();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.btnRegistrarUser = new System.Windows.Forms.Button();
            this.btnModificarUsuario = new System.Windows.Forms.Button();
            this.datagvUsuariosSistem = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagvUsuariosSistem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.LabelUsuarios);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 102);
            this.panel1.TabIndex = 9;
            // 
            // LabelUsuarios
            // 
            this.LabelUsuarios.AutoSize = true;
            this.LabelUsuarios.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelUsuarios.Location = new System.Drawing.Point(429, 30);
            this.LabelUsuarios.Name = "LabelUsuarios";
            this.LabelUsuarios.Size = new System.Drawing.Size(147, 42);
            this.LabelUsuarios.TabIndex = 3;
            this.LabelUsuarios.Text = "Usuarios";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BellezaTotal_UI.Properties.Resources.fotoUser;
            this.pictureBox1.Location = new System.Drawing.Point(925, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LabelListaU
            // 
            this.LabelListaU.AutoSize = true;
            this.LabelListaU.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelListaU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelListaU.Location = new System.Drawing.Point(139, 117);
            this.LabelListaU.Name = "LabelListaU";
            this.LabelListaU.Size = new System.Drawing.Size(333, 33);
            this.LabelListaU.TabIndex = 10;
            this.LabelListaU.Text = "Lista de usuarios del sistema";
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnEliminarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminarUsuario.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarUsuario.Location = new System.Drawing.Point(665, 577);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(208, 36);
            this.btnEliminarUsuario.TabIndex = 14;
            this.btnEliminarUsuario.Text = "Eliminar usuario";
            this.btnEliminarUsuario.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarUser
            // 
            this.btnRegistrarUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnRegistrarUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistrarUser.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarUser.Location = new System.Drawing.Point(145, 577);
            this.btnRegistrarUser.Name = "btnRegistrarUser";
            this.btnRegistrarUser.Size = new System.Drawing.Size(237, 36);
            this.btnRegistrarUser.TabIndex = 13;
            this.btnRegistrarUser.Text = "Registrar nuevo user";
            this.btnRegistrarUser.UseVisualStyleBackColor = false;
            this.btnRegistrarUser.Click += new System.EventHandler(this.btnRegistrarUser_Click);
            // 
            // btnModificarUsuario
            // 
            this.btnModificarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnModificarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificarUsuario.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarUsuario.Location = new System.Drawing.Point(388, 577);
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.Size = new System.Drawing.Size(271, 36);
            this.btnModificarUsuario.TabIndex = 12;
            this.btnModificarUsuario.Text = "Modificar datos ";
            this.btnModificarUsuario.UseVisualStyleBackColor = false;
            // 
            // datagvUsuariosSistem
            // 
            this.datagvUsuariosSistem.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.datagvUsuariosSistem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvUsuariosSistem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.datagvUsuariosSistem.Location = new System.Drawing.Point(145, 153);
            this.datagvUsuariosSistem.Name = "datagvUsuariosSistem";
            this.datagvUsuariosSistem.RowHeadersWidth = 51;
            this.datagvUsuariosSistem.RowTemplate.Height = 24;
            this.datagvUsuariosSistem.Size = new System.Drawing.Size(728, 418);
            this.datagvUsuariosSistem.TabIndex = 11;
            this.datagvUsuariosSistem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagvUsuariosSistem_CellContentClick);
            this.datagvUsuariosSistem.SelectionChanged += new System.EventHandler(this.datagvUsuariosSistem_SelectionChanged);
            // 
            // UI_GestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(199)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1012, 731);
            this.Controls.Add(this.LabelListaU);
            this.Controls.Add(this.btnEliminarUsuario);
            this.Controls.Add(this.btnRegistrarUser);
            this.Controls.Add(this.btnModificarUsuario);
            this.Controls.Add(this.datagvUsuariosSistem);
            this.Controls.Add(this.panel1);
            this.Name = "UI_GestionUsuarios";
            this.Text = "UI_GestionUsuarios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_GestionUsuarios_FormClosing);
            this.Load += new System.EventHandler(this.UI_GestionUsuarios_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagvUsuariosSistem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelUsuarios;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LabelListaU;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.Button btnRegistrarUser;
        private System.Windows.Forms.Button btnModificarUsuario;
        private System.Windows.Forms.DataGridView datagvUsuariosSistem;
    }
}