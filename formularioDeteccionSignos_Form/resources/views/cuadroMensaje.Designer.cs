namespace formularioDeteccionSignos_Form.resources.views
{
    partial class cuadroMensaje
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
            this.lbl_mensaje = new MaterialSkin.Controls.MaterialLabel();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // lbl_mensaje
            // 
            this.lbl_mensaje.AutoSize = true;
            this.lbl_mensaje.Depth = 0;
            this.lbl_mensaje.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_mensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_mensaje.Location = new System.Drawing.Point(168, 113);
            this.lbl_mensaje.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_mensaje.Name = "lbl_mensaje";
            this.lbl_mensaje.Size = new System.Drawing.Size(108, 19);
            this.lbl_mensaje.TabIndex = 0;
            this.lbl_mensaje.Text = "materialLabel1";
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(250, 163);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(152, 45);
            this.materialRaisedButton1.TabIndex = 1;
            this.materialRaisedButton1.Text = "OK";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // cuadroMensaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 244);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.lbl_mensaje);
            this.Name = "cuadroMensaje";
            this.Text = "MENSAJE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lbl_mensaje;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
    }
}