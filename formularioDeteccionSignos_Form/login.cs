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
    public partial class login : MaterialForm
    {
        public string usuario = string.Empty;
        public string contrasenia = string.Empty;
        public string id_usuario = string.Empty;
        public login()
        {
            InitializeComponent();
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            fnIniciar();
        }

        private void txt_contrasenia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                fnIniciar();
            }
        }

        public void fnIniciar()
        {
            this.usuario = txt_usuario.Text;
            this.contrasenia = txt_contrasenia.Text;
            if (string.IsNullOrEmpty(this.usuario) || string.IsNullOrWhiteSpace(this.usuario)
                && string.IsNullOrEmpty(this.contrasenia) || string.IsNullOrWhiteSpace(this.contrasenia))
            {
                cuadroMensaje message = new cuadroMensaje();
                message.fnCargarMensaje("Debes de ingresar un usuario y una contraseña");
                message.Show();
            }
            else
            {
                usuarioClass busqueda = new usuarioClass();
                if (busqueda.fnLogeoSistema(this.usuario, this.contrasenia))
                {
                    Form1 form1 = new Form1();
                    form1.Show();
                    form1.id_entrevistador = busqueda.id_actual;
                    this.Hide();
                }
                else
                {
                    cuadroMensaje message = new cuadroMensaje();
                    message.fnCargarMensaje("Usuario o Contraseña invalidos");
                    message.Show();
                }
            }
        }
    }
}
