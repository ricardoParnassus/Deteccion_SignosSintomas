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
            int VisibleTime = 1000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.txt_temperatura, "Ingrese aquí la temperatura máxima fijada");
            //tt.Show("Ingrese aquí la temperatura máxima fijada", this.txt_temperatura, 0, 0, VisibleTime);
        }
    }
}
