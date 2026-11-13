namespace BellezaTotal_UI
{
    partial class UI_Backup
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tboxNombreArchivo = new System.Windows.Forms.TextBox();
            this.btnRespaldarBaseDeDatos = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblArchivoActual = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnRestaurarCargarBackup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tboxNombreArchivo);
            this.groupBox1.Controls.Add(this.btnRespaldarBaseDeDatos);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Respaldar base de datos";
            // 
            // tboxNombreArchivo
            // 
            this.tboxNombreArchivo.Location = new System.Drawing.Point(6, 186);
            this.tboxNombreArchivo.Name = "tboxNombreArchivo";
            this.tboxNombreArchivo.Size = new System.Drawing.Size(347, 22);
            this.tboxNombreArchivo.TabIndex = 1;
            // 
            // btnRespaldarBaseDeDatos
            // 
            this.btnRespaldarBaseDeDatos.Location = new System.Drawing.Point(6, 226);
            this.btnRespaldarBaseDeDatos.Name = "btnRespaldarBaseDeDatos";
            this.btnRespaldarBaseDeDatos.Size = new System.Drawing.Size(347, 40);
            this.btnRespaldarBaseDeDatos.TabIndex = 0;
            this.btnRespaldarBaseDeDatos.Text = "Respaldar base de datos actual";
            this.btnRespaldarBaseDeDatos.UseVisualStyleBackColor = true;
            this.btnRespaldarBaseDeDatos.Click += new System.EventHandler(this.btnRespaldarBaseDeDatos_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblArchivoActual);
            this.groupBox2.Controls.Add(this.btnConfirmar);
            this.groupBox2.Controls.Add(this.btnRestaurarCargarBackup);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(414, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 450);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Restaurar base de datos";
            // 
            // lblArchivoActual
            // 
            this.lblArchivoActual.AutoSize = true;
            this.lblArchivoActual.Location = new System.Drawing.Point(9, 292);
            this.lblArchivoActual.Name = "lblArchivoActual";
            this.lblArchivoActual.Size = new System.Drawing.Size(112, 16);
            this.lblArchivoActual.TabIndex = 3;
            this.lblArchivoActual.Text = "Archivo cargado: ";
            this.lblArchivoActual.Visible = false;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(12, 311);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(353, 40);
            this.btnConfirmar.TabIndex = 2;
            this.btnConfirmar.Text = "Confirmar restauración de base de datos";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Visible = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnRestaurarCargarBackup
            // 
            this.btnRestaurarCargarBackup.Location = new System.Drawing.Point(12, 226);
            this.btnRestaurarCargarBackup.Name = "btnRestaurarCargarBackup";
            this.btnRestaurarCargarBackup.Size = new System.Drawing.Size(353, 40);
            this.btnRestaurarCargarBackup.TabIndex = 1;
            this.btnRestaurarCargarBackup.Text = "Cargar archivo";
            this.btnRestaurarCargarBackup.UseVisualStyleBackColor = true;
            this.btnRestaurarCargarBackup.Click += new System.EventHandler(this.btnRestaurarCargarBackup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Indique nombre del archivo de respaldo:";
            this.label1.Visible = false;
            // 
            // UI_Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(199)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UI_Backup";
            this.Text = "UI_Backup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_Backup_FormClosing);
            this.Load += new System.EventHandler(this.UI_Backup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRespaldarBaseDeDatos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnRestaurarCargarBackup;
        private System.Windows.Forms.TextBox tboxNombreArchivo;
        private System.Windows.Forms.Label lblArchivoActual;
        private System.Windows.Forms.Label label1;
    }
}