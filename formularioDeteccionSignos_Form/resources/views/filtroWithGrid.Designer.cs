﻿namespace formularioDeteccionSignos_Form.resources.views
{
    partial class filtroWithGrid
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
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.dgv_empleados = new System.Windows.Forms.DataGridView();
            this.btn_seleccionar = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_empleados)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(505, 73);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(66, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "BUSCAR";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(577, 73);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(209, 20);
            this.txtFiltro.TabIndex = 1;
            this.txtFiltro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyUp);
            // 
            // dgv_empleados
            // 
            this.dgv_empleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_empleados.Location = new System.Drawing.Point(12, 99);
            this.dgv_empleados.Name = "dgv_empleados";
            this.dgv_empleados.Size = new System.Drawing.Size(776, 308);
            this.dgv_empleados.TabIndex = 2;
            this.dgv_empleados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_empleados_CellContentClick);
            this.dgv_empleados.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_empleados_CellContentDoubleClick);
            // 
            // btn_seleccionar
            // 
            this.btn_seleccionar.Depth = 0;
            this.btn_seleccionar.Location = new System.Drawing.Point(651, 413);
            this.btn_seleccionar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_seleccionar.Name = "btn_seleccionar";
            this.btn_seleccionar.Primary = true;
            this.btn_seleccionar.Size = new System.Drawing.Size(135, 23);
            this.btn_seleccionar.TabIndex = 3;
            this.btn_seleccionar.Text = "SELECCIONAR";
            this.btn_seleccionar.UseVisualStyleBackColor = true;
            this.btn_seleccionar.Click += new System.EventHandler(this.btn_seleccionar_Click);
            // 
            // filtroWithGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 442);
            this.Controls.Add(this.btn_seleccionar);
            this.Controls.Add(this.dgv_empleados);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.materialLabel1);
            this.Name = "filtroWithGrid";
            this.Text = "filtroWithGrid";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_empleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.DataGridView dgv_empleados;
        private MaterialSkin.Controls.MaterialRaisedButton btn_seleccionar;
    }
}