using AForge.Video.DirectShow;
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
            FilterInfoCollection _FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in _FilterInfoCollection) { this.cmbbx_marca_camara.Items.Add(filterInfo.Name.ToUpper()); }
            //this.cmbbx_marca_camara.Items.Add("INTEGRATED CAMERA");
            //COMBO DEL TIPO DE VISOR
            this.cbx_tipo_visor.Items.Add("ENTREVISTADOR");
            this.cbx_tipo_visor.Items.Add("EMPLEADO");
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            cuadroMensaje mensaje = new cuadroMensaje();
            parameters parametros = new parameters();
            if(parametros.fnIngresaDatosCamara(this.cmbbx_marca_camara.Text, this.txt_ip_camara.Text, this.txt_puerto_camara.Text, this.txt_usuario_cam.Text, this.txt_password_cam.Text, this.cmbbx_tipo_terminal.Text, this.cbx_tipo_visor.Text))
            {
                mensaje.fnCargarMensaje("SE REGISTRARON LOS DATOS CORRECTAMENTE");
                mensaje.ShowDialog();
            }
            else
            {
                mensaje.fnCargarMensaje("ERROR: NO SE GUARDARON LOS DATOS...");
                mensaje.ShowDialog();
            }
            this.Hide();
        }

        private void cmbbx_marca_camara_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbx_marca_camara.SelectedItem.ToString().Equals("INTEGRATED CAMERA"))
            {
                this.txt_ip_camara.Enabled = false;
                this.txt_puerto_camara.Enabled = false;
                this.txt_usuario_cam.Enabled = false;
                this.txt_password_cam.Enabled = false;
            }
            else
            {
                this.txt_ip_camara.Enabled = true;
                this.txt_puerto_camara.Enabled = true;
                this.txt_usuario_cam.Enabled = true;
                this.txt_password_cam.Enabled = true;
            }
        }
    }
}
