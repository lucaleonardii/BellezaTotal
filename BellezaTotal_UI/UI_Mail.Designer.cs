namespace BellezaTotal_UI
{
    partial class UI_Mail
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
            this.LabelMail = new System.Windows.Forms.Label();
            this.txtboxMailDestinatario = new System.Windows.Forms.TextBox();
            this.txtboxCuerpoMail = new System.Windows.Forms.TextBox();
            this.btnEnviarMail = new System.Windows.Forms.Button();
            this.btnCancelarEnvio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelMail
            // 
            this.LabelMail.AutoSize = true;
            this.LabelMail.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelMail.Location = new System.Drawing.Point(68, 53);
            this.LabelMail.Name = "LabelMail";
            this.LabelMail.Size = new System.Drawing.Size(166, 26);
            this.LabelMail.TabIndex = 24;
            this.LabelMail.Text = "Mail destinatario";
            // 
            // txtboxMailDestinatario
            // 
            this.txtboxMailDestinatario.Location = new System.Drawing.Point(240, 49);
            this.txtboxMailDestinatario.Multiline = true;
            this.txtboxMailDestinatario.Name = "txtboxMailDestinatario";
            this.txtboxMailDestinatario.Size = new System.Drawing.Size(359, 36);
            this.txtboxMailDestinatario.TabIndex = 23;
            // 
            // txtboxCuerpoMail
            // 
            this.txtboxCuerpoMail.Location = new System.Drawing.Point(73, 103);
            this.txtboxCuerpoMail.Multiline = true;
            this.txtboxCuerpoMail.Name = "txtboxCuerpoMail";
            this.txtboxCuerpoMail.Size = new System.Drawing.Size(526, 443);
            this.txtboxCuerpoMail.TabIndex = 25;
            // 
            // btnEnviarMail
            // 
            this.btnEnviarMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnEnviarMail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnviarMail.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarMail.Location = new System.Drawing.Point(73, 552);
            this.btnEnviarMail.Name = "btnEnviarMail";
            this.btnEnviarMail.Size = new System.Drawing.Size(254, 36);
            this.btnEnviarMail.TabIndex = 26;
            this.btnEnviarMail.Text = "Aceptar y enviar";
            this.btnEnviarMail.UseVisualStyleBackColor = false;
            this.btnEnviarMail.Click += new System.EventHandler(this.btnEnviarMail_Click);
            // 
            // btnCancelarEnvio
            // 
            this.btnCancelarEnvio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(151)))), ((int)(((byte)(189)))));
            this.btnCancelarEnvio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelarEnvio.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarEnvio.Location = new System.Drawing.Point(345, 552);
            this.btnCancelarEnvio.Name = "btnCancelarEnvio";
            this.btnCancelarEnvio.Size = new System.Drawing.Size(254, 36);
            this.btnCancelarEnvio.TabIndex = 27;
            this.btnCancelarEnvio.Text = "Cancelar envio";
            this.btnCancelarEnvio.UseVisualStyleBackColor = false;
            this.btnCancelarEnvio.Click += new System.EventHandler(this.btnCancelarEnvio_Click);
            // 
            // UI_Mail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(199)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(678, 692);
            this.Controls.Add(this.btnCancelarEnvio);
            this.Controls.Add(this.btnEnviarMail);
            this.Controls.Add(this.txtboxCuerpoMail);
            this.Controls.Add(this.LabelMail);
            this.Controls.Add(this.txtboxMailDestinatario);
            this.Name = "UI_Mail";
            this.Text = "UI_Mail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_Mail_FormClosing);
            this.Load += new System.EventHandler(this.UI_Mail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelMail;
        private System.Windows.Forms.TextBox txtboxMailDestinatario;
        private System.Windows.Forms.TextBox txtboxCuerpoMail;
        private System.Windows.Forms.Button btnEnviarMail;
        private System.Windows.Forms.Button btnCancelarEnvio;
    }
}