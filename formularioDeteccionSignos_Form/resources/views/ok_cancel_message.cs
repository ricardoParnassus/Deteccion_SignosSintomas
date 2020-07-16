using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formularioDeteccionSignos_Form.resources.views
{
    public partial class ok_cancel_message : MaterialForm
    {
        public string mensaje = string.Empty;
        public ok_cancel_message(string mensaje)
        {
            InitializeComponent();
            this.mensaje = mensaje;
        }

        private void ok_cancel_message_Shown(object sender, EventArgs e)
        {
            this.lbl_mensaje.Text = mensaje;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            cuadroMensaje mensaje = new cuadroMensaje();
            mensaje.fnCargarMensaje("SE HA GUARDADO EL REGISTRO DE LA TRANSACCIÓN!!!");
            mensaje.ShowDialog();

            Thread.Sleep(1500);
            this.Hide();
        }
    }
}
