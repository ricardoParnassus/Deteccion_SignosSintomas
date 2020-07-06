namespace formularioDeteccionSignos_Form.resources.views
{
    partial class catalogoParametrizacion
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
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.btn_guardar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txt_temperatura = new System.Windows.Forms.TextBox();
            this.txt_ip_camara = new System.Windows.Forms.TextBox();
            this.txt_puerto_camara = new System.Windows.Forms.TextBox();
            this.txt_usuario_cam = new System.Windows.Forms.TextBox();
            this.txt_password_cam = new System.Windows.Forms.TextBox();
            this.txt_punto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(56, 106);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(119, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "TEMPERATURA:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(56, 148);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(92, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "IP CAMARA:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(56, 190);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(69, 19);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "PUERTO:";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(56, 232);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(112, 19);
            this.materialLabel4.TabIndex = 3;
            this.materialLabel4.Text = "USUARIO CAM:";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(56, 274);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(129, 19);
            this.materialLabel5.TabIndex = 4;
            this.materialLabel5.Text = "PASSWORD CAM:";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(56, 314);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(191, 19);
            this.materialLabel6.TabIndex = 5;
            this.materialLabel6.Text = "ENTRADA/SALIDA/AMBOS";
            // 
            // btn_guardar
            // 
            this.btn_guardar.Depth = 0;
            this.btn_guardar.Location = new System.Drawing.Point(141, 363);
            this.btn_guardar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Primary = true;
            this.btn_guardar.Size = new System.Drawing.Size(226, 46);
            this.btn_guardar.TabIndex = 6;
            this.btn_guardar.Text = "GUARDAR";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // txt_temperatura
            // 
            this.txt_temperatura.Location = new System.Drawing.Point(278, 106);
            this.txt_temperatura.Name = "txt_temperatura";
            this.txt_temperatura.Size = new System.Drawing.Size(179, 20);
            this.txt_temperatura.TabIndex = 7;
            // 
            // txt_ip_camara
            // 
            this.txt_ip_camara.Location = new System.Drawing.Point(278, 147);
            this.txt_ip_camara.Name = "txt_ip_camara";
            this.txt_ip_camara.Size = new System.Drawing.Size(179, 20);
            this.txt_ip_camara.TabIndex = 8;
            // 
            // txt_puerto_camara
            // 
            this.txt_puerto_camara.Location = new System.Drawing.Point(278, 189);
            this.txt_puerto_camara.Name = "txt_puerto_camara";
            this.txt_puerto_camara.Size = new System.Drawing.Size(179, 20);
            this.txt_puerto_camara.TabIndex = 9;
            // 
            // txt_usuario_cam
            // 
            this.txt_usuario_cam.Location = new System.Drawing.Point(278, 231);
            this.txt_usuario_cam.Name = "txt_usuario_cam";
            this.txt_usuario_cam.Size = new System.Drawing.Size(179, 20);
            this.txt_usuario_cam.TabIndex = 10;
            // 
            // txt_password_cam
            // 
            this.txt_password_cam.Location = new System.Drawing.Point(278, 273);
            this.txt_password_cam.Name = "txt_password_cam";
            this.txt_password_cam.Size = new System.Drawing.Size(179, 20);
            this.txt_password_cam.TabIndex = 11;
            // 
            // txt_punto
            // 
            this.txt_punto.Location = new System.Drawing.Point(278, 313);
            this.txt_punto.Name = "txt_punto";
            this.txt_punto.Size = new System.Drawing.Size(179, 20);
            this.txt_punto.TabIndex = 12;
            // 
            // catalogoParametrizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 436);
            this.Controls.Add(this.txt_punto);
            this.Controls.Add(this.txt_password_cam);
            this.Controls.Add(this.txt_usuario_cam);
            this.Controls.Add(this.txt_puerto_camara);
            this.Controls.Add(this.txt_ip_camara);
            this.Controls.Add(this.txt_temperatura);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Name = "catalogoParametrizacion";
            this.Text = "CATÁLOGO DE PARAMETRIZACIÓN";
            this.Load += new System.EventHandler(this.catalogoParametrizacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialRaisedButton btn_guardar;
        private System.Windows.Forms.TextBox txt_temperatura;
        private System.Windows.Forms.TextBox txt_ip_camara;
        private System.Windows.Forms.TextBox txt_puerto_camara;
        private System.Windows.Forms.TextBox txt_usuario_cam;
        private System.Windows.Forms.TextBox txt_password_cam;
        private System.Windows.Forms.TextBox txt_punto;
    }
}