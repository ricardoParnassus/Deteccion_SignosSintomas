namespace formularioDeteccionSignos_Form.resources.views
{
    partial class gridHistoricoComprobantes
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
            this.dgv_historico = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_historico)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_historico
            // 
            this.dgv_historico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_historico.Location = new System.Drawing.Point(3, 67);
            this.dgv_historico.Name = "dgv_historico";
            this.dgv_historico.Size = new System.Drawing.Size(794, 380);
            this.dgv_historico.TabIndex = 0;
            this.dgv_historico.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_historico_CellContentDoubleClick);
            // 
            // gridHistoricoComprobantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_historico);
            this.Name = "gridHistoricoComprobantes";
            this.Text = "Historico de Comprobantes";
            this.Shown += new System.EventHandler(this.gridHistoricoComprobantes_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_historico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_historico;
    }
}