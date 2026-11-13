namespace BellezaTotal_UI
{
    partial class UI_AltaServicio
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
            this.components = new System.ComponentModel.Container();
            this.btnCancelarServicio = new System.Windows.Forms.Button();
            this.btnRegistrarServicio = new System.Windows.Forms.Button();
            this.tboxDuracionServicio = new System.Windows.Forms.TextBox();
            this.lblDuracionServicio = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.cboxEspecialidad = new System.Windows.Forms.ComboBox();
            this.especialidadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bellezaTotalDataSet = new BellezaTotal_UI.BellezaTotalDataSet();
            this.lblCabina = new System.Windows.Forms.Label();
            this.lblDescServicio = new System.Windows.Forms.Label();
            this.lblNombreServicio = new System.Windows.Forms.Label();
            this.cboxTipo = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.lTituloServicio = new System.Windows.Forms.Label();
            this.tboxNombreServicio = new System.Windows.Forms.TextBox();
            this.tboxDescServicio = new System.Windows.Forms.TextBox();
            this.tboxPrecio = new System.Windows.Forms.TextBox();
            this.especialidadTableAdapter = new BellezaTotal_UI.BellezaTotalDataSetTableAdapters.EspecialidadTableAdapter();
            this.bellezaTotalDataSet1 = new BellezaTotal_UI.BellezaTotalDataSet1();
            this.especialidadBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.especialidadTableAdapter1 = new BellezaTotal_UI.BellezaTotalDataSet1TableAdapters.EspecialidadTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bellezaTotalDataSet)).BeginInit();
            this.panelEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bellezaTotalDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelarServicio
            // 
            this.btnCancelarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnCancelarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelarServicio.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarServicio.Location = new System.Drawing.Point(285, 545);
            this.btnCancelarServicio.Name = "btnCancelarServicio";
            this.btnCancelarServicio.Size = new System.Drawing.Size(235, 45);
            this.btnCancelarServicio.TabIndex = 31;
            this.btnCancelarServicio.Text = "Cancelar";
            this.btnCancelarServicio.UseVisualStyleBackColor = false;
            this.btnCancelarServicio.Click += new System.EventHandler(this.btnCancelarServicio_Click);
            // 
            // btnRegistrarServicio
            // 
            this.btnRegistrarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnRegistrarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistrarServicio.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarServicio.Location = new System.Drawing.Point(40, 545);
            this.btnRegistrarServicio.Name = "btnRegistrarServicio";
            this.btnRegistrarServicio.Size = new System.Drawing.Size(235, 45);
            this.btnRegistrarServicio.TabIndex = 30;
            this.btnRegistrarServicio.Text = "Guardar";
            this.btnRegistrarServicio.UseVisualStyleBackColor = false;
            this.btnRegistrarServicio.Click += new System.EventHandler(this.btnRegistrarServicio_Click);
            // 
            // tboxDuracionServicio
            // 
            this.tboxDuracionServicio.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxDuracionServicio.Location = new System.Drawing.Point(40, 450);
            this.tboxDuracionServicio.MaxLength = 200;
            this.tboxDuracionServicio.Name = "tboxDuracionServicio";
            this.tboxDuracionServicio.Size = new System.Drawing.Size(480, 27);
            this.tboxDuracionServicio.TabIndex = 29;
            // 
            // lblDuracionServicio
            // 
            this.lblDuracionServicio.AutoSize = true;
            this.lblDuracionServicio.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuracionServicio.Location = new System.Drawing.Point(40, 426);
            this.lblDuracionServicio.Name = "lblDuracionServicio";
            this.lblDuracionServicio.Size = new System.Drawing.Size(72, 19);
            this.lblDuracionServicio.TabIndex = 28;
            this.lblDuracionServicio.Text = "Duración";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(40, 366);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(55, 19);
            this.lblPrecio.TabIndex = 25;
            this.lblPrecio.Text = "Precio";
            // 
            // cboxEspecialidad
            // 
            this.cboxEspecialidad.DataSource = this.especialidadBindingSource;
            this.cboxEspecialidad.DisplayMember = "Nombre";
            this.cboxEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxEspecialidad.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxEspecialidad.FormattingEnabled = true;
            this.cboxEspecialidad.Location = new System.Drawing.Point(40, 326);
            this.cboxEspecialidad.Name = "cboxEspecialidad";
            this.cboxEspecialidad.Size = new System.Drawing.Size(480, 27);
            this.cboxEspecialidad.TabIndex = 24;
            this.cboxEspecialidad.ValueMember = "Nombre";
            // 
            // especialidadBindingSource
            // 
            this.especialidadBindingSource.DataMember = "Especialidad";
            this.especialidadBindingSource.DataSource = this.bellezaTotalDataSet;
            // 
            // bellezaTotalDataSet
            // 
            this.bellezaTotalDataSet.DataSetName = "BellezaTotalDataSet";
            this.bellezaTotalDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblCabina
            // 
            this.lblCabina.AutoSize = true;
            this.lblCabina.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabina.Location = new System.Drawing.Point(40, 302);
            this.lblCabina.Name = "lblCabina";
            this.lblCabina.Size = new System.Drawing.Size(95, 19);
            this.lblCabina.TabIndex = 23;
            this.lblCabina.Text = "Especialidad";
            // 
            // lblDescServicio
            // 
            this.lblDescServicio.AutoSize = true;
            this.lblDescServicio.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescServicio.Location = new System.Drawing.Point(40, 238);
            this.lblDescServicio.Name = "lblDescServicio";
            this.lblDescServicio.Size = new System.Drawing.Size(93, 19);
            this.lblDescServicio.TabIndex = 21;
            this.lblDescServicio.Text = "Descripción";
            // 
            // lblNombreServicio
            // 
            this.lblNombreServicio.AutoSize = true;
            this.lblNombreServicio.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreServicio.Location = new System.Drawing.Point(40, 174);
            this.lblNombreServicio.Name = "lblNombreServicio";
            this.lblNombreServicio.Size = new System.Drawing.Size(65, 19);
            this.lblNombreServicio.TabIndex = 19;
            this.lblNombreServicio.Text = "Nombre";
            // 
            // cboxTipo
            // 
            this.cboxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTipo.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxTipo.FormattingEnabled = true;
            this.cboxTipo.Items.AddRange(new object[] {
            "SERVICIO",
            "CORPORAL",
            "FACIAL"});
            this.cboxTipo.Location = new System.Drawing.Point(40, 134);
            this.cboxTipo.Name = "cboxTipo";
            this.cboxTipo.Size = new System.Drawing.Size(480, 27);
            this.cboxTipo.TabIndex = 18;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(40, 110);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 19);
            this.lblCliente.TabIndex = 17;
            this.lblCliente.Text = "Tipo";
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.BackColor = System.Drawing.Color.White;
            this.panelEncabezado.Controls.Add(this.lTituloServicio);
            this.panelEncabezado.Location = new System.Drawing.Point(0, 10);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.Size = new System.Drawing.Size(560, 80);
            this.panelEncabezado.TabIndex = 16;
            // 
            // lTituloServicio
            // 
            this.lTituloServicio.AutoSize = true;
            this.lTituloServicio.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTituloServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.lTituloServicio.Location = new System.Drawing.Point(40, 18);
            this.lTituloServicio.Name = "lTituloServicio";
            this.lTituloServicio.Size = new System.Drawing.Size(271, 42);
            this.lTituloServicio.TabIndex = 0;
            this.lTituloServicio.Text = "Registrar servicio";
            // 
            // tboxNombreServicio
            // 
            this.tboxNombreServicio.Location = new System.Drawing.Point(40, 196);
            this.tboxNombreServicio.Name = "tboxNombreServicio";
            this.tboxNombreServicio.Size = new System.Drawing.Size(480, 22);
            this.tboxNombreServicio.TabIndex = 32;
            // 
            // tboxDescServicio
            // 
            this.tboxDescServicio.Location = new System.Drawing.Point(40, 260);
            this.tboxDescServicio.Name = "tboxDescServicio";
            this.tboxDescServicio.Size = new System.Drawing.Size(480, 22);
            this.tboxDescServicio.TabIndex = 33;
            // 
            // tboxPrecio
            // 
            this.tboxPrecio.Location = new System.Drawing.Point(40, 388);
            this.tboxPrecio.Name = "tboxPrecio";
            this.tboxPrecio.Size = new System.Drawing.Size(480, 22);
            this.tboxPrecio.TabIndex = 34;
            // 
            // especialidadTableAdapter
            // 
            this.especialidadTableAdapter.ClearBeforeFill = true;
            // 
            // bellezaTotalDataSet1
            // 
            this.bellezaTotalDataSet1.DataSetName = "BellezaTotalDataSet1";
            this.bellezaTotalDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // especialidadBindingSource1
            // 
            this.especialidadBindingSource1.DataMember = "Especialidad";
            this.especialidadBindingSource1.DataSource = this.bellezaTotalDataSet1;
            // 
            // especialidadTableAdapter1
            // 
            this.especialidadTableAdapter1.ClearBeforeFill = true;
            // 
            // UI_AltaServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(199)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(560, 600);
            this.Controls.Add(this.tboxPrecio);
            this.Controls.Add(this.tboxDescServicio);
            this.Controls.Add(this.tboxNombreServicio);
            this.Controls.Add(this.btnCancelarServicio);
            this.Controls.Add(this.btnRegistrarServicio);
            this.Controls.Add(this.tboxDuracionServicio);
            this.Controls.Add(this.lblDuracionServicio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.cboxEspecialidad);
            this.Controls.Add(this.lblCabina);
            this.Controls.Add(this.lblDescServicio);
            this.Controls.Add(this.lblNombreServicio);
            this.Controls.Add(this.cboxTipo);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.panelEncabezado);
            this.Name = "UI_AltaServicio";
            this.Text = "UI_AltaServicio";
            this.Load += new System.EventHandler(this.UI_AltaServicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.especialidadBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bellezaTotalDataSet)).EndInit();
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bellezaTotalDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelarServicio;
        private System.Windows.Forms.Button btnRegistrarServicio;
        private System.Windows.Forms.TextBox tboxDuracionServicio;
        private System.Windows.Forms.Label lblDuracionServicio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.ComboBox cboxEspecialidad;
        private System.Windows.Forms.Label lblCabina;
        private System.Windows.Forms.Label lblDescServicio;
        private System.Windows.Forms.Label lblNombreServicio;
        private System.Windows.Forms.ComboBox cboxTipo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label lTituloServicio;
        private System.Windows.Forms.TextBox tboxNombreServicio;
        private System.Windows.Forms.TextBox tboxDescServicio;
        private System.Windows.Forms.TextBox tboxPrecio;
        private BellezaTotalDataSet bellezaTotalDataSet;
        private System.Windows.Forms.BindingSource especialidadBindingSource;
        private BellezaTotalDataSetTableAdapters.EspecialidadTableAdapter especialidadTableAdapter;
        private BellezaTotalDataSet1 bellezaTotalDataSet1;
        private System.Windows.Forms.BindingSource especialidadBindingSource1;
        private BellezaTotalDataSet1TableAdapters.EspecialidadTableAdapter especialidadTableAdapter1;
    }
}