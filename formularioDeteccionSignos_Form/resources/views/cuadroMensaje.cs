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
    public partial class cuadroMensaje : MaterialForm
    {
        public cuadroMensaje()
        {
            InitializeComponent();
        }

        public void fnCargarMensaje(string mensaje)
        {
            this.lbl_mensaje.Text = mensaje;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
