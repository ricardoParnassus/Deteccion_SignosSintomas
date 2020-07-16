namespace formularioDeteccionSignos_Form.resources.views
{
    partial class ok_cancel_message
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
            this.btn_ok = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_cancel = new MaterialSkin.Controls.MaterialRaisedButton();
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
            // btn_ok
            // 
            this.btn_ok.Depth = 0;
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Location = new System.Drawing.Point(341, 169);
            this.btn_ok.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Primary = true;
            this.btn_ok.Size = new System.Drawing.Size(152, 45);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "SI";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Depth = 0;
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(133, 169);
            this.btn_cancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Primary = true;
            this.btn_cancel.Size = new System.Drawing.Size(152, 45);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "NO";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // ok_cancel_message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 244);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbl_mensaje);
            this.Name = "ok_cancel_message";
            this.Text = "ALERTA!";
            this.Shown += new System.EventHandler(this.ok_cancel_message_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lbl_mensaje;
        private MaterialSkin.Controls.MaterialRaisedButton btn_ok;
        private MaterialSkin.Controls.MaterialRaisedButton btn_cancel;
    }
}