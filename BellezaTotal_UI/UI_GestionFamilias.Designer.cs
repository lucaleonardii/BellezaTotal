namespace BellezaTotal_UI
{
    partial class UI_GestionFamilias
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
            this.LabelGestionF = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LabelFamilias = new System.Windows.Forms.Label();
            this.tvFamilias = new System.Windows.Forms.TreeView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panelEditor = new System.Windows.Forms.Panel();
            this.LabelFIncluidas = new System.Windows.Forms.Label();
            this.LabelPatentes = new System.Windows.Forms.Label();
            this.clbFamiliasHijas = new System.Windows.Forms.CheckedListBox();
            this.clbPatentes = new System.Windows.Forms.CheckedListBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblModo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.LabelGestionF);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 102);
            this.panel1.TabIndex = 11;
            // 
            // LabelGestionF
            // 
            this.LabelGestionF.AutoSize = true;
            this.LabelGestionF.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelGestionF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelGestionF.Location = new System.Drawing.Point(378, 34);
            this.LabelGestionF.Name = "LabelGestionF";
            this.LabelGestionF.Size = new System.Drawing.Size(296, 42);
            this.LabelGestionF.TabIndex = 3;
            this.LabelGestionF.Text = "Gestión de familias";
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
            // LabelFamilias
            // 
            this.LabelFamilias.AutoSize = true;
            this.LabelFamilias.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFamilias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelFamilias.Location = new System.Drawing.Point(7, 122);
            this.LabelFamilias.Name = "LabelFamilias";
            this.LabelFamilias.Size = new System.Drawing.Size(90, 26);
            this.LabelFamilias.TabIndex = 13;
            this.LabelFamilias.Text = "Familias";
            // 
            // tvFamilias
            // 
            this.tvFamilias.HideSelection = false;
            this.tvFamilias.Location = new System.Drawing.Point(12, 169);
            this.tvFamilias.Name = "tvFamilias";
            this.tvFamilias.Size = new System.Drawing.Size(359, 405);
            this.tvFamilias.TabIndex = 14;
            this.tvFamilias.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvFamilias_BeforeSelect);
            this.tvFamilias.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevo.Location = new System.Drawing.Point(13, 600);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(358, 32);
            this.btnNuevo.TabIndex = 15;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // panelEditor
            // 
            this.panelEditor.Controls.Add(this.LabelFIncluidas);
            this.panelEditor.Controls.Add(this.LabelPatentes);
            this.panelEditor.Controls.Add(this.clbFamiliasHijas);
            this.panelEditor.Controls.Add(this.clbPatentes);
            this.panelEditor.Controls.Add(this.btnEliminar);
            this.panelEditor.Controls.Add(this.btnGuardar);
            this.panelEditor.Controls.Add(this.txtNombre);
            this.panelEditor.Controls.Add(this.lblModo);
            this.panelEditor.Location = new System.Drawing.Point(385, 169);
            this.panelEditor.Name = "panelEditor";
            this.panelEditor.Size = new System.Drawing.Size(629, 463);
            this.panelEditor.TabIndex = 16;
            // 
            // LabelFIncluidas
            // 
            this.LabelFIncluidas.AutoSize = true;
            this.LabelFIncluidas.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFIncluidas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelFIncluidas.Location = new System.Drawing.Point(331, 77);
            this.LabelFIncluidas.Name = "LabelFIncluidas";
            this.LabelFIncluidas.Size = new System.Drawing.Size(179, 26);
            this.LabelFIncluidas.TabIndex = 21;
            this.LabelFIncluidas.Text = "Familias incluidas";
            // 
            // LabelPatentes
            // 
            this.LabelPatentes.AutoSize = true;
            this.LabelPatentes.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPatentes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelPatentes.Location = new System.Drawing.Point(26, 77);
            this.LabelPatentes.Name = "LabelPatentes";
            this.LabelPatentes.Size = new System.Drawing.Size(88, 26);
            this.LabelPatentes.TabIndex = 17;
            this.LabelPatentes.Text = "Patentes";
            // 
            // clbFamiliasHijas
            // 
            this.clbFamiliasHijas.CheckOnClick = true;
            this.clbFamiliasHijas.FormattingEnabled = true;
            this.clbFamiliasHijas.Location = new System.Drawing.Point(336, 106);
            this.clbFamiliasHijas.Name = "clbFamiliasHijas";
            this.clbFamiliasHijas.Size = new System.Drawing.Size(267, 242);
            this.clbFamiliasHijas.TabIndex = 20;
            this.clbFamiliasHijas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbFamilias_ItemCheck);
            // 
            // clbPatentes
            // 
            this.clbPatentes.CheckOnClick = true;
            this.clbPatentes.FormattingEnabled = true;
            this.clbPatentes.Location = new System.Drawing.Point(31, 106);
            this.clbPatentes.Name = "clbPatentes";
            this.clbPatentes.Size = new System.Drawing.Size(267, 242);
            this.clbPatentes.TabIndex = 19;
            this.clbPatentes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbPatentes_ItemCheck);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Location = new System.Drawing.Point(336, 367);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(267, 32);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Location = new System.Drawing.Point(31, 367);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(267, 32);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(31, 43);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(572, 22);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // lblModo
            // 
            this.lblModo.AutoSize = true;
            this.lblModo.Location = new System.Drawing.Point(28, 12);
            this.lblModo.Name = "lblModo";
            this.lblModo.Size = new System.Drawing.Size(52, 16);
            this.lblModo.TabIndex = 0;
            this.lblModo.Text = "Modo: -";
            // 
            // UI_GestionFamilias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(199)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1037, 681);
            this.Controls.Add(this.panelEditor);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.tvFamilias);
            this.Controls.Add(this.LabelFamilias);
            this.Controls.Add(this.panel1);
            this.Name = "UI_GestionFamilias";
            this.Text = "Gestión de familias";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_GestionFamilias_FormClosing);
            this.Load += new System.EventHandler(this.UI_GestionFamilias_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelEditor.ResumeLayout(false);
            this.panelEditor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelGestionF;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LabelFamilias;
        private System.Windows.Forms.TreeView tvFamilias;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Panel panelEditor;
        private System.Windows.Forms.CheckedListBox clbFamiliasHijas;
        private System.Windows.Forms.CheckedListBox clbPatentes;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblModo;
        private System.Windows.Forms.Label LabelFIncluidas;
        private System.Windows.Forms.Label LabelPatentes;
    }
}