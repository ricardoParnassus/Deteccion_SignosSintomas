namespace formularioDeteccionSignos_Form
{
    partial class Form2
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
            this.lbl_fiebre = new MaterialSkin.Controls.MaterialLabel();
            this.materialRadioButton1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.panel_fiebre = new System.Windows.Forms.Panel();
            this.panel_estornudos = new System.Windows.Forms.Panel();
            this.materialRadioButton4 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton3 = new MaterialSkin.Controls.MaterialRadioButton();
            this.lbl_tos_estornudos = new MaterialSkin.Controls.MaterialLabel();
            this.panel_malestar = new System.Windows.Forms.Panel();
            this.materialRadioButton6 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton5 = new MaterialSkin.Controls.MaterialRadioButton();
            this.lbl_malestar_gen = new MaterialSkin.Controls.MaterialLabel();
            this.panel_dolor = new System.Windows.Forms.Panel();
            this.materialRadioButton8 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton7 = new MaterialSkin.Controls.MaterialRadioButton();
            this.lbl_dolor_cabeza = new MaterialSkin.Controls.MaterialLabel();
            this.panel_dificultad = new System.Windows.Forms.Panel();
            this.materialRadioButton10 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton9 = new MaterialSkin.Controls.MaterialRadioButton();
            this.lbl_dificultad_respirar = new MaterialSkin.Controls.MaterialLabel();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel_fiebre.SuspendLayout();
            this.panel_estornudos.SuspendLayout();
            this.panel_malestar.SuspendLayout();
            this.panel_dolor.SuspendLayout();
            this.panel_dificultad.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_fiebre
            // 
            this.lbl_fiebre.AutoSize = true;
            this.lbl_fiebre.Depth = 0;
            this.lbl_fiebre.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_fiebre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_fiebre.Location = new System.Drawing.Point(45, 19);
            this.lbl_fiebre.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_fiebre.Name = "lbl_fiebre";
            this.lbl_fiebre.Size = new System.Drawing.Size(352, 19);
            this.lbl_fiebre.TabIndex = 0;
            this.lbl_fiebre.Text = "HA PRESENTADO FIEBRE EN LOS ULTIMOS 7 DIAS\r\n";
            // 
            // materialRadioButton1
            // 
            this.materialRadioButton1.AutoSize = true;
            this.materialRadioButton1.Depth = 0;
            this.materialRadioButton1.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton1.Location = new System.Drawing.Point(128, 45);
            this.materialRadioButton1.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton1.Name = "materialRadioButton1";
            this.materialRadioButton1.Ripple = true;
            this.materialRadioButton1.Size = new System.Drawing.Size(41, 30);
            this.materialRadioButton1.TabIndex = 1;
            this.materialRadioButton1.TabStop = true;
            this.materialRadioButton1.Text = "SI";
            this.materialRadioButton1.UseVisualStyleBackColor = true;
            this.materialRadioButton1.CheckedChanged += new System.EventHandler(this.materialRadioButton1_CheckedChanged);
            // 
            // materialRadioButton2
            // 
            this.materialRadioButton2.AutoSize = true;
            this.materialRadioButton2.Depth = 0;
            this.materialRadioButton2.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton2.Location = new System.Drawing.Point(263, 45);
            this.materialRadioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton2.Name = "materialRadioButton2";
            this.materialRadioButton2.Ripple = true;
            this.materialRadioButton2.Size = new System.Drawing.Size(48, 30);
            this.materialRadioButton2.TabIndex = 2;
            this.materialRadioButton2.TabStop = true;
            this.materialRadioButton2.Text = "NO";
            this.materialRadioButton2.UseVisualStyleBackColor = true;
            this.materialRadioButton2.CheckedChanged += new System.EventHandler(this.materialRadioButton2_CheckedChanged);
            // 
            // panel_fiebre
            // 
            this.panel_fiebre.Controls.Add(this.lbl_fiebre);
            this.panel_fiebre.Controls.Add(this.materialRadioButton2);
            this.panel_fiebre.Controls.Add(this.materialRadioButton1);
            this.panel_fiebre.Location = new System.Drawing.Point(28, 89);
            this.panel_fiebre.Name = "panel_fiebre";
            this.panel_fiebre.Size = new System.Drawing.Size(478, 93);
            this.panel_fiebre.TabIndex = 3;
            this.panel_fiebre.Visible = false;
            // 
            // panel_estornudos
            // 
            this.panel_estornudos.Controls.Add(this.materialRadioButton4);
            this.panel_estornudos.Controls.Add(this.materialRadioButton3);
            this.panel_estornudos.Controls.Add(this.lbl_tos_estornudos);
            this.panel_estornudos.Location = new System.Drawing.Point(28, 199);
            this.panel_estornudos.Name = "panel_estornudos";
            this.panel_estornudos.Size = new System.Drawing.Size(479, 103);
            this.panel_estornudos.TabIndex = 4;
            this.panel_estornudos.Visible = false;
            // 
            // materialRadioButton4
            // 
            this.materialRadioButton4.AutoSize = true;
            this.materialRadioButton4.Depth = 0;
            this.materialRadioButton4.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton4.Location = new System.Drawing.Point(263, 63);
            this.materialRadioButton4.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton4.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton4.Name = "materialRadioButton4";
            this.materialRadioButton4.Ripple = true;
            this.materialRadioButton4.Size = new System.Drawing.Size(48, 30);
            this.materialRadioButton4.TabIndex = 2;
            this.materialRadioButton4.TabStop = true;
            this.materialRadioButton4.Text = "NO";
            this.materialRadioButton4.UseVisualStyleBackColor = true;
            this.materialRadioButton4.CheckedChanged += new System.EventHandler(this.materialRadioButton4_CheckedChanged);
            // 
            // materialRadioButton3
            // 
            this.materialRadioButton3.AutoSize = true;
            this.materialRadioButton3.Depth = 0;
            this.materialRadioButton3.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton3.Location = new System.Drawing.Point(128, 63);
            this.materialRadioButton3.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton3.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton3.Name = "materialRadioButton3";
            this.materialRadioButton3.Ripple = true;
            this.materialRadioButton3.Size = new System.Drawing.Size(41, 30);
            this.materialRadioButton3.TabIndex = 1;
            this.materialRadioButton3.TabStop = true;
            this.materialRadioButton3.Text = "SI";
            this.materialRadioButton3.UseVisualStyleBackColor = true;
            this.materialRadioButton3.CheckedChanged += new System.EventHandler(this.materialRadioButton3_CheckedChanged);
            // 
            // lbl_tos_estornudos
            // 
            this.lbl_tos_estornudos.AutoSize = true;
            this.lbl_tos_estornudos.Depth = 0;
            this.lbl_tos_estornudos.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_tos_estornudos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_tos_estornudos.Location = new System.Drawing.Point(12, 16);
            this.lbl_tos_estornudos.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_tos_estornudos.Name = "lbl_tos_estornudos";
            this.lbl_tos_estornudos.Size = new System.Drawing.Size(418, 38);
            this.lbl_tos_estornudos.TabIndex = 0;
            this.lbl_tos_estornudos.Text = "HA TENIDO ESTORNUDOS FRECUENTES, TOS O MALESTAR \r\nEN LA GARGANTA EN LOS ULTIMOS 7" +
    " DÍAS\r\n";
            // 
            // panel_malestar
            // 
            this.panel_malestar.Controls.Add(this.materialRadioButton6);
            this.panel_malestar.Controls.Add(this.materialRadioButton5);
            this.panel_malestar.Controls.Add(this.lbl_malestar_gen);
            this.panel_malestar.Location = new System.Drawing.Point(28, 322);
            this.panel_malestar.Name = "panel_malestar";
            this.panel_malestar.Size = new System.Drawing.Size(477, 100);
            this.panel_malestar.TabIndex = 5;
            this.panel_malestar.Visible = false;
            // 
            // materialRadioButton6
            // 
            this.materialRadioButton6.AutoSize = true;
            this.materialRadioButton6.Depth = 0;
            this.materialRadioButton6.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton6.Location = new System.Drawing.Point(263, 51);
            this.materialRadioButton6.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton6.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton6.Name = "materialRadioButton6";
            this.materialRadioButton6.Ripple = true;
            this.materialRadioButton6.Size = new System.Drawing.Size(48, 30);
            this.materialRadioButton6.TabIndex = 2;
            this.materialRadioButton6.TabStop = true;
            this.materialRadioButton6.Text = "NO";
            this.materialRadioButton6.UseVisualStyleBackColor = true;
            this.materialRadioButton6.CheckedChanged += new System.EventHandler(this.materialRadioButton6_CheckedChanged);
            // 
            // materialRadioButton5
            // 
            this.materialRadioButton5.AutoSize = true;
            this.materialRadioButton5.Depth = 0;
            this.materialRadioButton5.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton5.Location = new System.Drawing.Point(127, 51);
            this.materialRadioButton5.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton5.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton5.Name = "materialRadioButton5";
            this.materialRadioButton5.Ripple = true;
            this.materialRadioButton5.Size = new System.Drawing.Size(41, 30);
            this.materialRadioButton5.TabIndex = 1;
            this.materialRadioButton5.TabStop = true;
            this.materialRadioButton5.Text = "SI";
            this.materialRadioButton5.UseVisualStyleBackColor = true;
            this.materialRadioButton5.CheckedChanged += new System.EventHandler(this.materialRadioButton5_CheckedChanged);
            // 
            // lbl_malestar_gen
            // 
            this.lbl_malestar_gen.AutoSize = true;
            this.lbl_malestar_gen.Depth = 0;
            this.lbl_malestar_gen.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_malestar_gen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_malestar_gen.Location = new System.Drawing.Point(38, 16);
            this.lbl_malestar_gen.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_malestar_gen.Name = "lbl_malestar_gen";
            this.lbl_malestar_gen.Size = new System.Drawing.Size(387, 19);
            this.lbl_malestar_gen.TabIndex = 0;
            this.lbl_malestar_gen.Text = "HA TENIDO DOLOR DE CUERPO O MALESTAR GENERAL";
            // 
            // panel_dolor
            // 
            this.panel_dolor.Controls.Add(this.materialRadioButton8);
            this.panel_dolor.Controls.Add(this.materialRadioButton7);
            this.panel_dolor.Controls.Add(this.lbl_dolor_cabeza);
            this.panel_dolor.Location = new System.Drawing.Point(27, 440);
            this.panel_dolor.Name = "panel_dolor";
            this.panel_dolor.Size = new System.Drawing.Size(479, 95);
            this.panel_dolor.TabIndex = 6;
            this.panel_dolor.Visible = false;
            // 
            // materialRadioButton8
            // 
            this.materialRadioButton8.AutoSize = true;
            this.materialRadioButton8.Depth = 0;
            this.materialRadioButton8.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton8.Location = new System.Drawing.Point(263, 44);
            this.materialRadioButton8.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton8.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton8.Name = "materialRadioButton8";
            this.materialRadioButton8.Ripple = true;
            this.materialRadioButton8.Size = new System.Drawing.Size(48, 30);
            this.materialRadioButton8.TabIndex = 2;
            this.materialRadioButton8.TabStop = true;
            this.materialRadioButton8.Text = "NO";
            this.materialRadioButton8.UseVisualStyleBackColor = true;
            this.materialRadioButton8.CheckedChanged += new System.EventHandler(this.materialRadioButton8_CheckedChanged);
            // 
            // materialRadioButton7
            // 
            this.materialRadioButton7.AutoSize = true;
            this.materialRadioButton7.Depth = 0;
            this.materialRadioButton7.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton7.Location = new System.Drawing.Point(128, 44);
            this.materialRadioButton7.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton7.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton7.Name = "materialRadioButton7";
            this.materialRadioButton7.Ripple = true;
            this.materialRadioButton7.Size = new System.Drawing.Size(41, 30);
            this.materialRadioButton7.TabIndex = 1;
            this.materialRadioButton7.TabStop = true;
            this.materialRadioButton7.Text = "SI";
            this.materialRadioButton7.UseVisualStyleBackColor = true;
            this.materialRadioButton7.CheckedChanged += new System.EventHandler(this.materialRadioButton7_CheckedChanged);
            // 
            // lbl_dolor_cabeza
            // 
            this.lbl_dolor_cabeza.AutoSize = true;
            this.lbl_dolor_cabeza.Depth = 0;
            this.lbl_dolor_cabeza.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_dolor_cabeza.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_dolor_cabeza.Location = new System.Drawing.Point(12, 12);
            this.lbl_dolor_cabeza.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_dolor_cabeza.Name = "lbl_dolor_cabeza";
            this.lbl_dolor_cabeza.Size = new System.Drawing.Size(423, 19);
            this.lbl_dolor_cabeza.TabIndex = 0;
            this.lbl_dolor_cabeza.Text = "HA PRESENTADO DOLOR DE CABEZA EN LOS ULTIMOS DIAS";
            // 
            // panel_dificultad
            // 
            this.panel_dificultad.Controls.Add(this.materialRadioButton10);
            this.panel_dificultad.Controls.Add(this.materialRadioButton9);
            this.panel_dificultad.Controls.Add(this.lbl_dificultad_respirar);
            this.panel_dificultad.Location = new System.Drawing.Point(28, 554);
            this.panel_dificultad.Name = "panel_dificultad";
            this.panel_dificultad.Size = new System.Drawing.Size(478, 96);
            this.panel_dificultad.TabIndex = 7;
            this.panel_dificultad.Visible = false;
            // 
            // materialRadioButton10
            // 
            this.materialRadioButton10.AutoSize = true;
            this.materialRadioButton10.Depth = 0;
            this.materialRadioButton10.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton10.Location = new System.Drawing.Point(263, 56);
            this.materialRadioButton10.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton10.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton10.Name = "materialRadioButton10";
            this.materialRadioButton10.Ripple = true;
            this.materialRadioButton10.Size = new System.Drawing.Size(48, 30);
            this.materialRadioButton10.TabIndex = 2;
            this.materialRadioButton10.TabStop = true;
            this.materialRadioButton10.Text = "NO";
            this.materialRadioButton10.UseVisualStyleBackColor = true;
            this.materialRadioButton10.CheckedChanged += new System.EventHandler(this.materialRadioButton10_CheckedChanged);
            // 
            // materialRadioButton9
            // 
            this.materialRadioButton9.AutoSize = true;
            this.materialRadioButton9.Depth = 0;
            this.materialRadioButton9.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton9.Location = new System.Drawing.Point(128, 56);
            this.materialRadioButton9.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton9.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton9.Name = "materialRadioButton9";
            this.materialRadioButton9.Ripple = true;
            this.materialRadioButton9.Size = new System.Drawing.Size(41, 30);
            this.materialRadioButton9.TabIndex = 1;
            this.materialRadioButton9.TabStop = true;
            this.materialRadioButton9.Text = "SI";
            this.materialRadioButton9.UseVisualStyleBackColor = true;
            this.materialRadioButton9.CheckedChanged += new System.EventHandler(this.materialRadioButton9_CheckedChanged);
            // 
            // lbl_dificultad_respirar
            // 
            this.lbl_dificultad_respirar.AutoSize = true;
            this.lbl_dificultad_respirar.Depth = 0;
            this.lbl_dificultad_respirar.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_dificultad_respirar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_dificultad_respirar.Location = new System.Drawing.Point(98, 10);
            this.lbl_dificultad_respirar.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_dificultad_respirar.Name = "lbl_dificultad_respirar";
            this.lbl_dificultad_respirar.Size = new System.Drawing.Size(259, 38);
            this.lbl_dificultad_respirar.TabIndex = 0;
            this.lbl_dificultad_respirar.Text = "HAS SENTIDO ALGUNA DIFICULTAD \r\nPARA RESPIRAR RECIENTEMENTE";
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(135, 666);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(233, 63);
            this.materialRaisedButton1.TabIndex = 8;
            this.materialRaisedButton1.Text = "CONTINUAR";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 750);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.panel_dificultad);
            this.Controls.Add(this.panel_dolor);
            this.Controls.Add(this.panel_malestar);
            this.Controls.Add(this.panel_estornudos);
            this.Controls.Add(this.panel_fiebre);
            this.Name = "Form2";
            this.Text = "        CUESTIONARIO DE DETECCION DE SIGNOS Y SÍNTOMAS";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel_fiebre.ResumeLayout(false);
            this.panel_fiebre.PerformLayout();
            this.panel_estornudos.ResumeLayout(false);
            this.panel_estornudos.PerformLayout();
            this.panel_malestar.ResumeLayout(false);
            this.panel_malestar.PerformLayout();
            this.panel_dolor.ResumeLayout(false);
            this.panel_dolor.PerformLayout();
            this.panel_dificultad.ResumeLayout(false);
            this.panel_dificultad.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lbl_fiebre;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton1;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton2;
        private System.Windows.Forms.Panel panel_fiebre;
        private System.Windows.Forms.Panel panel_estornudos;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton4;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton3;
        private MaterialSkin.Controls.MaterialLabel lbl_tos_estornudos;
        private System.Windows.Forms.Panel panel_malestar;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton6;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton5;
        private MaterialSkin.Controls.MaterialLabel lbl_malestar_gen;
        private System.Windows.Forms.Panel panel_dolor;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton8;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton7;
        private MaterialSkin.Controls.MaterialLabel lbl_dolor_cabeza;
        private System.Windows.Forms.Panel panel_dificultad;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton10;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton9;
        private MaterialSkin.Controls.MaterialLabel lbl_dificultad_respirar;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
    }
}