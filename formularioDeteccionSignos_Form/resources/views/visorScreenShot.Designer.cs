namespace formularioDeteccionSignos_Form.resources.views
{
    partial class visorScreenShot
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
            this.picture_screen_shot = new System.Windows.Forms.PictureBox();
            this.picture_termografica = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture_screen_shot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_termografica)).BeginInit();
            this.SuspendLayout();
            // 
            // picture_screen_shot
            // 
            this.picture_screen_shot.Location = new System.Drawing.Point(5, 68);
            this.picture_screen_shot.Name = "picture_screen_shot";
            this.picture_screen_shot.Size = new System.Drawing.Size(506, 362);
            this.picture_screen_shot.TabIndex = 0;
            this.picture_screen_shot.TabStop = false;
            // 
            // picture_termografica
            // 
            this.picture_termografica.Location = new System.Drawing.Point(517, 68);
            this.picture_termografica.Name = "picture_termografica";
            this.picture_termografica.Size = new System.Drawing.Size(531, 362);
            this.picture_termografica.TabIndex = 1;
            this.picture_termografica.TabStop = false;
            // 
            // visorScreenShot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 438);
            this.Controls.Add(this.picture_termografica);
            this.Controls.Add(this.picture_screen_shot);
            this.Name = "visorScreenShot";
            this.Text = "VISOR DE CAPTURAS DE PANTALLA";
            this.Load += new System.EventHandler(this.visorScreenShot_Load);
            this.Shown += new System.EventHandler(this.visorScreenShot_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picture_screen_shot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_termografica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picture_screen_shot;
        private System.Windows.Forms.PictureBox picture_termografica;
    }
}