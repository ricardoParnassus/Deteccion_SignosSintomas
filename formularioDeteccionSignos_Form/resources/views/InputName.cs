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
        #region datos usuario
        public string userName;
        public string userPaterno;
        public string userMaterno;
        public string userGenero;
        public string userEdad;
        public string userRol;
        public string userPuesto;
        public string userCorreo;
        public string userPathImagen;
        #endregion

        #region ORIGINAL
        public InputName()
        {
            InitializeComponent();
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
        #endregion
        /// <summary>
        /// TEXTBOX NOMBRE DE USUARIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            userName = textBox1.Text;
        }

        /// <summary>
        /// TEXTBOX APELLIDO PATERNO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            userPaterno = textBox2.Text;
        }

        /// <summary>
        /// TEXTBOX APELLIDO MATERNO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            userMaterno = textBox3.Text;
        }

        /// <summary>
        /// COMBOBOX GENERO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            userGenero = comboBox1.SelectedItem.ToString();
        }

        /// <summary>
        /// TEXTBOX EDAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            userEdad = textBox4.Text;
        }

        /// <summary>
        /// TEXTBOX ROL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            userRol = textBox5.Text;
        }

        /// <summary>
        /// TEXTBOX PUESTO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            userPuesto = textBox6.Text;
        }

        /// <summary>
        /// TEXTBOX CORREO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            userCorreo = textBox7.Text;
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Image Files",

                CheckFileExists = true,
                CheckPathExists = true,

                //DefaultExt = "txt",
                //Filter = "txt files (*.txt)|*.txt",
                //FilterIndex = 2,
                //RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = openFileDialog1.FileName;
                this.userPathImagen = textBox8.Text;
            }
        }

    }
}
