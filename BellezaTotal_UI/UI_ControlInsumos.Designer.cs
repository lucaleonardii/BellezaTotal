namespace BellezaTotal_UI
{
    partial class UI_ControlInsumos
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
            this.LabelInsumos = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LabelInsumosStock = new System.Windows.Forms.Label();
            this.datagvInsumosDisp = new System.Windows.Forms.DataGridView();
            this.ColumnaRestock = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnaCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMandarMail = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagvInsumosDisp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.LabelInsumos);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 102);
            this.panel1.TabIndex = 4;
            // 
            // LabelInsumos
            // 
            this.LabelInsumos.AutoSize = true;
            this.LabelInsumos.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInsumos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelInsumos.Location = new System.Drawing.Point(439, 31);
            this.LabelInsumos.Name = "LabelInsumos";
            this.LabelInsumos.Size = new System.Drawing.Size(142, 42);
            this.LabelInsumos.TabIndex = 4;
            this.LabelInsumos.Text = "Insumos";
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
            // LabelInsumosStock
            // 
            this.LabelInsumosStock.AutoSize = true;
            this.LabelInsumosStock.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInsumosStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelInsumosStock.Location = new System.Drawing.Point(143, 123);
            this.LabelInsumosStock.Name = "LabelInsumosStock";
            this.LabelInsumosStock.Size = new System.Drawing.Size(175, 26);
            this.LabelInsumosStock.TabIndex = 13;
            this.LabelInsumosStock.Text = "Insumos en stock";
            // 
            // datagvInsumosDisp
            // 
            this.datagvInsumosDisp.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.datagvInsumosDisp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvInsumosDisp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaRestock,
            this.ColumnaCantidad});
            this.datagvInsumosDisp.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.datagvInsumosDisp.Location = new System.Drawing.Point(148, 152);
            this.datagvInsumosDisp.Name = "datagvInsumosDisp";
            this.datagvInsumosDisp.RowHeadersWidth = 51;
            this.datagvInsumosDisp.RowTemplate.Height = 24;
            this.datagvInsumosDisp.Size = new System.Drawing.Size(728, 333);
            this.datagvInsumosDisp.TabIndex = 12;
            // 
            // ColumnaRestock
            // 
            this.ColumnaRestock.HeaderText = "Restockear";
            this.ColumnaRestock.MinimumWidth = 6;
            this.ColumnaRestock.Name = "ColumnaRestock";
            this.ColumnaRestock.Width = 125;
            // 
            // ColumnaCantidad
            // 
            this.ColumnaCantidad.HeaderText = "Cantidad a pedir";
            this.ColumnaCantidad.MinimumWidth = 6;
            this.ColumnaCantidad.Name = "ColumnaCantidad";
            this.ColumnaCantidad.Width = 125;
            // 
            // btnMandarMail
            // 
            this.btnMandarMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnMandarMail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMandarMail.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMandarMail.Location = new System.Drawing.Point(148, 491);
            this.btnMandarMail.Name = "btnMandarMail";
            this.btnMandarMail.Size = new System.Drawing.Size(266, 46);
            this.btnMandarMail.TabIndex = 21;
            this.btnMandarMail.Text = "Mandar mail a proveedor";
            this.btnMandarMail.UseVisualStyleBackColor = false;
            this.btnMandarMail.Click += new System.EventHandler(this.btnMandarMail_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(610, 491);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(266, 46);
            this.button1.TabIndex = 22;
            this.button1.Text = "Proveedores";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UI_ControlInsumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(199)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1036, 876);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMandarMail);
            this.Controls.Add(this.LabelInsumosStock);
            this.Controls.Add(this.datagvInsumosDisp);
            this.Controls.Add(this.panel1);
            this.Name = "UI_ControlInsumos";
            this.Text = "UI_ControlInsumos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_ControlInsumos_FormClosing);
            this.Load += new System.EventHandler(this.UI_ControlInsumos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagvInsumosDisp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelInsumos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LabelInsumosStock;
        private System.Windows.Forms.DataGridView datagvInsumosDisp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnaRestock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaCantidad;
        private System.Windows.Forms.Button btnMandarMail;
        private System.Windows.Forms.Button button1;
    }
}