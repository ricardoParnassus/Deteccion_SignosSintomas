using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formularioDeteccionSignos_Form.resources.views
{
    public partial class catalogoParametrizacion : MaterialForm
    {
        public catalogoParametrizacion()
        {
            InitializeComponent();
        }

        private void catalogoParametrizacion_Load(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.txt_temperatura, "Ingrese aquí la temperatura máxima fijada");
            //tt.Show("Ingrese aquí la temperatura máxima fijada", this.txt_temperatura, 0, 0, VisibleTime);

            this.cmbbx_tipo_terminal.Items.Add("Entrada");
            this.cmbbx_tipo_terminal.Items.Add("Salida");
            this.cmbbx_tipo_terminal.Items.Add("Ambos");

            this.cmbbx_marca_camara.Items.Add("DAHUA");
            this.cmbbx_tipo_terminal.Items.Add("HIKVISION");
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

        }
    }
}
