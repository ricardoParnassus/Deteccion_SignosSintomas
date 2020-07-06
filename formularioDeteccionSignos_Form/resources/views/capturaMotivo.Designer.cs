namespace formularioDeteccionSignos_Form.resources.views
{
    partial class capturaMotivo
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(35, 83);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(528, 119);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(184, 229);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(225, 51);
            this.materialRaisedButton1.TabIndex = 1;
            this.materialRaisedButton1.Text = "GUARDAR";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            // 
            // capturaMotivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 304);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "capturaMotivo";
            this.Text = "INGRESA EL MOTIVO";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
    }
}