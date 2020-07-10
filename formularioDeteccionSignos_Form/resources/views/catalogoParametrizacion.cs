using formularioDeteccionSignos_Form.classes;
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
            //TERMINAL PUNTO DE ACCESO O SALIDA
            this.cmbbx_tipo_terminal.Items.Add("Entrada");
            this.cmbbx_tipo_terminal.Items.Add("Salida");
            this.cmbbx_tipo_terminal.Items.Add("Ambos");
            //COMBO DE CAMARAS IP
            this.cmbbx_marca_camara.Items.Add("DAHUA");
            this.cmbbx_marca_camara.Items.Add("HIKVISION");
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            cuadroMensaje mensaje = new cuadroMensaje();
            parameters parametros = new parameters();
            if(parametros.fnIngresaDatosCamara(this.cmbbx_marca_camara.Text, this.txt_ip_camara.Text, this.txt_puerto_camara.Text, this.txt_usuario_cam.Text, this.txt_password_cam.Text, this.cmbbx_tipo_terminal.Text))
            {
                mensaje.fnCargarMensaje("SE REGISTRARON LOS DATOS CORRECTAMENTE");
                mensaje.Show();
            }
            else
            {
                mensaje.fnCargarMensaje("ERROR: NO SE GUARDARON LOS DATOS...");
                mensaje.Show();
            }
        }
    }
}
