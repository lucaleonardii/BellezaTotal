namespace BellezaTotal_UI
{
    partial class UI_WaitLine
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
            this.LabelSalaE = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.datagvSalaEspera = new System.Windows.Forms.DataGridView();
            this.LabelInfoT = new System.Windows.Forms.Label();
            this.ListBoxInformacion = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagvSalaEspera)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.LabelSalaE);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 104);
            this.panel1.TabIndex = 4;
            // 
            // LabelSalaE
            // 
            this.LabelSalaE.AutoSize = true;
            this.LabelSalaE.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSalaE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelSalaE.Location = new System.Drawing.Point(408, 35);
            this.LabelSalaE.Name = "LabelSalaE";
            this.LabelSalaE.Size = new System.Drawing.Size(223, 42);
            this.LabelSalaE.TabIndex = 3;
            this.LabelSalaE.Text = "Sala de espera";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BellezaTotal_UI.Properties.Resources.fotoEspera;
            this.pictureBox1.Location = new System.Drawing.Point(913, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // datagvSalaEspera
            // 
            this.datagvSalaEspera.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.datagvSalaEspera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagvSalaEspera.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.datagvSalaEspera.Location = new System.Drawing.Point(12, 143);
            this.datagvSalaEspera.Name = "datagvSalaEspera";
            this.datagvSalaEspera.RowHeadersWidth = 51;
            this.datagvSalaEspera.RowTemplate.Height = 24;
            this.datagvSalaEspera.Size = new System.Drawing.Size(965, 327);
            this.datagvSalaEspera.TabIndex = 8;
            // 
            // LabelInfoT
            // 
            this.LabelInfoT.AutoSize = true;
            this.LabelInfoT.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInfoT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelInfoT.Location = new System.Drawing.Point(12, 487);
            this.LabelInfoT.Name = "LabelInfoT";
            this.LabelInfoT.Size = new System.Drawing.Size(218, 26);
            this.LabelInfoT.TabIndex = 9;
            this.LabelInfoT.Text = "Información del turno";
            // 
            // ListBoxInformacion
            // 
            this.ListBoxInformacion.FormattingEnabled = true;
            this.ListBoxInformacion.ItemHeight = 16;
            this.ListBoxInformacion.Location = new System.Drawing.Point(17, 516);
            this.ListBoxInformacion.Name = "ListBoxInformacion";
            this.ListBoxInformacion.Size = new System.Drawing.Size(900, 244);
            this.ListBoxInformacion.TabIndex = 10;
            // 
            // UI_WaitLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(199)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1006, 802);
            this.Controls.Add(this.ListBoxInformacion);
            this.Controls.Add(this.LabelInfoT);
            this.Controls.Add(this.datagvSalaEspera);
            this.Controls.Add(this.panel1);
            this.Name = "UI_WaitLine";
            this.Text = "UI_WaitLine";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_WaitLine_FormClosing);
            this.Load += new System.EventHandler(this.UI_WaitLine_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagvSalaEspera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelSalaE;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView datagvSalaEspera;
        private System.Windows.Forms.Label LabelInfoT;
        private System.Windows.Forms.ListBox ListBoxInformacion;
    }
}