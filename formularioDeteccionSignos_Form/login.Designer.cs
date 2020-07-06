namespace formularioDeteccionSignos_Form.resources.views
{
    partial class login
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.txt_contrasenia = new System.Windows.Forms.TextBox();
            this.btn_iniciar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(111, 108);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(71, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "USUARIO";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(91, 208);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(107, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "CONTRASEÑA";
            // 
            // txt_usuario
            // 
            this.txt_usuario.Location = new System.Drawing.Point(91, 142);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(121, 20);
            this.txt_usuario.TabIndex = 2;
            // 
            // txt_contrasenia
            // 
            this.txt_contrasenia.Location = new System.Drawing.Point(91, 240);
            this.txt_contrasenia.Name = "txt_contrasenia";
            this.txt_contrasenia.PasswordChar = '*';
            this.txt_contrasenia.Size = new System.Drawing.Size(121, 20);
            this.txt_contrasenia.TabIndex = 3;
            this.txt_contrasenia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_contrasenia_KeyPress);
            // 
            // btn_iniciar
            // 
            this.btn_iniciar.Depth = 0;
            this.btn_iniciar.Location = new System.Drawing.Point(69, 315);
            this.btn_iniciar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_iniciar.Name = "btn_iniciar";
            this.btn_iniciar.Primary = true;
            this.btn_iniciar.Size = new System.Drawing.Size(178, 68);
            this.btn_iniciar.TabIndex = 4;
            this.btn_iniciar.Text = "INICIAR";
            this.btn_iniciar.UseVisualStyleBackColor = true;
            this.btn_iniciar.Click += new System.EventHandler(this.btn_iniciar_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 450);
            this.Controls.Add(this.btn_iniciar);
            this.Controls.Add(this.txt_contrasenia);
            this.Controls.Add(this.txt_usuario);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Name = "login";
            this.Text = "LOGIN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.TextBox txt_contrasenia;
        private MaterialSkin.Controls.MaterialRaisedButton btn_iniciar;
    }
}