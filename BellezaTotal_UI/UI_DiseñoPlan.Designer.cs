namespace BellezaTotal_UI
{
    partial class UI_DiseñoPlan
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
            this.LabelDiseña = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.LabelDiseña);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 102);
            this.panel1.TabIndex = 10;
            // 
            // LabelDiseña
            // 
            this.LabelDiseña.AutoSize = true;
            this.LabelDiseña.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDiseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(97)))), ((int)(((byte)(146)))));
            this.LabelDiseña.Location = new System.Drawing.Point(330, 31);
            this.LabelDiseña.Name = "LabelDiseña";
            this.LabelDiseña.Size = new System.Drawing.Size(355, 42);
            this.LabelDiseña.TabIndex = 3;
            this.LabelDiseña.Text = "Diseña el próximo plan";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BellezaTotal_UI.Properties.Resources.fotoAgenda;
            this.pictureBox1.Location = new System.Drawing.Point(925, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UI_DiseñoPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(199)))), ((int)(((byte)(226)))));
            this.ClientSize = new System.Drawing.Size(1017, 1019);
            this.Controls.Add(this.panel1);
            this.Name = "UI_DiseñoPlan";
            this.Text = "UI_DiseñoPlan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_DiseñoPlan_FormClosing);
            this.Load += new System.EventHandler(this.UI_DiseñoPlan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelDiseña;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}