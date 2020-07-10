namespace formularioDeteccionSignos_Form.resources.views
{
    partial class ComprobanteVisor
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
            this.web_browser_files = new System.Windows.Forms.WebBrowser();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.web_browser_files);
            this.panel1.Location = new System.Drawing.Point(20, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 431);
            this.panel1.TabIndex = 0;
            // 
            // web_browser_files
            // 
            this.web_browser_files.Location = new System.Drawing.Point(-17, -19);
            this.web_browser_files.MinimumSize = new System.Drawing.Size(20, 20);
            this.web_browser_files.Name = "web_browser_files";
            this.web_browser_files.Size = new System.Drawing.Size(883, 521);
            this.web_browser_files.TabIndex = 0;
            // 
            // ComprobanteVisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 594);
            this.Controls.Add(this.panel1);
            this.Name = "ComprobanteVisor";
            this.Text = "ComprobanteVisor";
            this.Load += new System.EventHandler(this.ComprobanteVisor_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser web_browser_files;
    }
}