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
    public partial class InputName : MaterialForm
    {
        public string userName;
        public string userPaterno;
        public string userMaterno;
        public string userGenero;
        public string userEdad;
        public string userRol;
        public string userPuesto;
        public string userCorreo;
        
        public InputName()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            userName = textBox1.Text;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputName_Shown(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Masculino");
            comboBox1.Items.Add("Femenino");
        }
    }
}
