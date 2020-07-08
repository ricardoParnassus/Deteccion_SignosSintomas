namespace formularioDeteccionSignos_Form.resources.views
{
    partial class visorCamaraLuxand
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.INICIAR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(994, 623);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp_1);
            // 
            // INICIAR
            // 
            this.INICIAR.Location = new System.Drawing.Point(12, 12);
            this.INICIAR.Name = "INICIAR";
            this.INICIAR.Size = new System.Drawing.Size(23, 23);
            this.INICIAR.TabIndex = 1;
            this.INICIAR.Text = "x";
            this.INICIAR.UseVisualStyleBackColor = true;
            this.INICIAR.Click += new System.EventHandler(this.INICIAR_Click_1);
            // 
            // visorCamaraLuxand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 638);
            this.Controls.Add(this.INICIAR);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "visorCamaraLuxand";
            this.Text = "visorCamaraLuxand";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.visorCamaraLuxand_FormClosing);
            this.Load += new System.EventHandler(this.visorCamaraLuxand_Load);
            this.Shown += new System.EventHandler(this.visorCamaraLuxand_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button INICIAR;
    }
}