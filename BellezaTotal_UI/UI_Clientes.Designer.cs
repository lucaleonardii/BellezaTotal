namespace BellezaTotal_UI
{
    partial class UI_Clientes
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
            this.datagvClientes = new System.Windows.Forms.DataGridView();
            this.btnModificarCliente = new System.Windows.Forms.Button();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.LabelListaClientes = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LabelCLientesA = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.datagridAlergias = new System.Windows.Forms.DataGridView();
            this.LabelFichaT = new System.Windows.Forms.Label();
            this.LabelAlergias = new System.Windows.Forms.Label();
            this.LabelContraI = new System.Windows.Forms.Label();
            this.datagridContraindicaciones = new System.Windows.Forms.DataGridView();
            this.LabelAfecciones = new System.Windows.Forms.Label();
            this.datagridAfecciones = new System.Windows.Forms.DataGridView();
            this.btnGuardarFichas = new System.Windows.Forms.Button();
            this.btnExportarXml = new System.Windows.Forms.Button();
            this.btnImportarXml = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagvClientes)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridAlergias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridContraindicaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridAfecciones)).BeginInit();
            this.SuspendLayout();
            // 
            // datagvClientes
            // 
            this.datagvClientes.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.datagvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvClientes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.datagvClientes.Location = new System.Drawing.Point(17, 188);
            this.datagvClientes.Name = "datagvClientes";
            this.datagvClientes.RowHeadersWidth = 51;
            this.datagvClientes.RowTemplate.Height = 24;
            this.datagvClientes.Size = new System.Drawing.Size(703, 418);
            this.datagvClientes.TabIndex = 4;
            this.datagvClientes.SelectionChanged += new System.EventHandler(this.datagvClientes_SelectionChanged);
            // 
            // btnModificarCliente
            // 
            this.btnModificarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnModificarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificarCliente.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarCliente.Location = new System.Drawing.Point(449, 612);
            this.btnModificarCliente.Name = "btnModificarCliente";
            this.btnModificarCliente.Size = new System.Drawing.Size(271, 36);
            this.btnModificarCliente.TabIndex = 5;
            this.btnModificarCliente.Text = "Modificar datos";
            this.btnModificarCliente.UseVisualStyleBackColor = false;
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnAgregarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregarCliente.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCliente.Location = new System.Drawing.Point(17, 612);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(237, 36);
            this.btnAgregarCliente.TabIndex = 6;
            this.btnAgregarCliente.Text = "Agregar cliente";
            this.btnAgregarCliente.UseVisualStyleBackColor = false;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // LabelListaClientes
            // 
            this.LabelListaClientes.AutoSize = true;
            this.LabelListaClientes.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelListaClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelListaClientes.Location = new System.Drawing.Point(11, 152);
            this.LabelListaClientes.Name = "LabelListaClientes";
            this.LabelListaClientes.Size = new System.Drawing.Size(344, 33);
            this.LabelListaClientes.TabIndex = 4;
            this.LabelListaClientes.Text = "Lista de clientes en el sistema";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.LabelCLientesA);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 102);
            this.panel1.TabIndex = 8;
            // 
            // LabelCLientesA
            // 
            this.LabelCLientesA.AutoSize = true;
            this.LabelCLientesA.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCLientesA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelCLientesA.Location = new System.Drawing.Point(389, 33);
            this.LabelCLientesA.Name = "LabelCLientesA";
            this.LabelCLientesA.Size = new System.Drawing.Size(284, 42);
            this.LabelCLientesA.TabIndex = 3;
            this.LabelCLientesA.Text = "Clientes asociados";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BellezaTotal_UI.Properties.Resources.fotoUser;
            this.pictureBox1.Location = new System.Drawing.Point(904, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // datagridAlergias
            // 
            this.datagridAlergias.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.datagridAlergias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridAlergias.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.datagridAlergias.Location = new System.Drawing.Point(12, 766);
            this.datagridAlergias.Name = "datagridAlergias";
            this.datagridAlergias.RowHeadersWidth = 51;
            this.datagridAlergias.RowTemplate.Height = 24;
            this.datagridAlergias.Size = new System.Drawing.Size(220, 333);
            this.datagridAlergias.TabIndex = 9;
            // 
            // LabelFichaT
            // 
            this.LabelFichaT.AutoSize = true;
            this.LabelFichaT.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFichaT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelFichaT.Location = new System.Drawing.Point(413, 685);
            this.LabelFichaT.Name = "LabelFichaT";
            this.LabelFichaT.Size = new System.Drawing.Size(284, 33);
            this.LabelFichaT.TabIndex = 10;
            this.LabelFichaT.Text = "Ficha tecnica del cliente";
            // 
            // LabelAlergias
            // 
            this.LabelAlergias.AutoSize = true;
            this.LabelAlergias.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAlergias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelAlergias.Location = new System.Drawing.Point(12, 737);
            this.LabelAlergias.Name = "LabelAlergias";
            this.LabelAlergias.Size = new System.Drawing.Size(88, 26);
            this.LabelAlergias.TabIndex = 11;
            this.LabelAlergias.Text = "Alergias";
            // 
            // LabelContraI
            // 
            this.LabelContraI.AutoSize = true;
            this.LabelContraI.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelContraI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelContraI.Location = new System.Drawing.Point(248, 737);
            this.LabelContraI.Name = "LabelContraI";
            this.LabelContraI.Size = new System.Drawing.Size(190, 26);
            this.LabelContraI.TabIndex = 13;
            this.LabelContraI.Text = "Contraindicaciones";
            // 
            // datagridContraindicaciones
            // 
            this.datagridContraindicaciones.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.datagridContraindicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridContraindicaciones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.datagridContraindicaciones.Location = new System.Drawing.Point(253, 766);
            this.datagridContraindicaciones.Name = "datagridContraindicaciones";
            this.datagridContraindicaciones.RowHeadersWidth = 51;
            this.datagridContraindicaciones.RowTemplate.Height = 24;
            this.datagridContraindicaciones.Size = new System.Drawing.Size(220, 333);
            this.datagridContraindicaciones.TabIndex = 12;
            // 
            // LabelAfecciones
            // 
            this.LabelAfecciones.AutoSize = true;
            this.LabelAfecciones.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAfecciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelAfecciones.Location = new System.Drawing.Point(511, 737);
            this.LabelAfecciones.Name = "LabelAfecciones";
            this.LabelAfecciones.Size = new System.Drawing.Size(115, 26);
            this.LabelAfecciones.TabIndex = 15;
            this.LabelAfecciones.Text = "Afecciones";
            // 
            // datagridAfecciones
            // 
            this.datagridAfecciones.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.datagridAfecciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridAfecciones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.datagridAfecciones.Location = new System.Drawing.Point(516, 766);
            this.datagridAfecciones.Name = "datagridAfecciones";
            this.datagridAfecciones.RowHeadersWidth = 51;
            this.datagridAfecciones.RowTemplate.Height = 24;
            this.datagridAfecciones.Size = new System.Drawing.Size(220, 333);
            this.datagridAfecciones.TabIndex = 14;
            // 
            // btnGuardarFichas
            // 
            this.btnGuardarFichas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnGuardarFichas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarFichas.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarFichas.Location = new System.Drawing.Point(770, 766);
            this.btnGuardarFichas.Name = "btnGuardarFichas";
            this.btnGuardarFichas.Size = new System.Drawing.Size(208, 36);
            this.btnGuardarFichas.TabIndex = 16;
            this.btnGuardarFichas.Text = "Guardar fichas";
            this.btnGuardarFichas.UseVisualStyleBackColor = false;
            this.btnGuardarFichas.Click += new System.EventHandler(this.btnGuardarFichas_Click);
            // 
            // btnExportarXml
            // 
            this.btnExportarXml.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnExportarXml.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExportarXml.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarXml.Location = new System.Drawing.Point(734, 188);
            this.btnExportarXml.Name = "btnExportarXml";
            this.btnExportarXml.Size = new System.Drawing.Size(263, 36);
            this.btnExportarXml.TabIndex = 7;
            this.btnExportarXml.Text = "Exportar clientes";
            this.btnExportarXml.UseVisualStyleBackColor = false;
            this.btnExportarXml.Click += new System.EventHandler(this.btnExportarClientes_Click);
            // 
            // btnImportarXml
            // 
            this.btnImportarXml.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnImportarXml.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImportarXml.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportarXml.Location = new System.Drawing.Point(731, 244);
            this.btnImportarXml.Name = "btnImportarXml";
            this.btnImportarXml.Size = new System.Drawing.Size(263, 36);
            this.btnImportarXml.TabIndex = 17;
            this.btnImportarXml.Text = "Importar clientes";
            this.btnImportarXml.UseVisualStyleBackColor = false;
            this.btnImportarXml.Click += new System.EventHandler(this.btnImportarClientes_Click);
            // 
            // UI_Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(199)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1023, 1055);
            this.Controls.Add(this.btnImportarXml);
            this.Controls.Add(this.btnGuardarFichas);
            this.Controls.Add(this.LabelAfecciones);
            this.Controls.Add(this.datagridAfecciones);
            this.Controls.Add(this.LabelContraI);
            this.Controls.Add(this.datagridContraindicaciones);
            this.Controls.Add(this.LabelAlergias);
            this.Controls.Add(this.LabelFichaT);
            this.Controls.Add(this.datagridAlergias);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LabelListaClientes);
            this.Controls.Add(this.btnExportarXml);
            this.Controls.Add(this.btnAgregarCliente);
            this.Controls.Add(this.btnModificarCliente);
            this.Controls.Add(this.datagvClientes);
            this.Name = "UI_Clientes";
            this.Text = "UI_Clientes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_Clientes_FormClosing);
            this.Load += new System.EventHandler(this.UI_Clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagvClientes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridAlergias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridContraindicaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridAfecciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView datagvClientes;
        private System.Windows.Forms.Button btnModificarCliente;
        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.Label LabelListaClientes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelCLientesA;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView datagridAlergias;
        private System.Windows.Forms.Label LabelFichaT;
        private System.Windows.Forms.Label LabelAlergias;
        private System.Windows.Forms.Label LabelContraI;
        private System.Windows.Forms.DataGridView datagridContraindicaciones;
        private System.Windows.Forms.Label LabelAfecciones;
        private System.Windows.Forms.DataGridView datagridAfecciones;
        private System.Windows.Forms.Button btnGuardarFichas;
        private System.Windows.Forms.Button btnExportarXml;
        private System.Windows.Forms.Button btnImportarXml;
    }
}