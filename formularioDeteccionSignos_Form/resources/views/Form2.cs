using formularioDeteccionSignos_Form.resources.views;
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

namespace formularioDeteccionSignos_Form
{
    public partial class Form2 : MaterialForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //tos estornudos           
            lbl_tos_estornudos.Visible = false;
            panel_estornudos.Visible = false; materialRadioButton3.Visible = false; materialRadioButton4.Visible = false;

            //malestar general
            lbl_malestar_gen.Visible = false;
            panel_malestar.Visible = false; materialRadioButton5.Visible = false; materialRadioButton6.Visible = false;

            //dificultad respiratoria
            lbl_dificultad_respirar.Visible = false;
            panel_dificultad.Visible = false; materialRadioButton9.Visible = false; materialRadioButton10.Visible = false;

            //dolor de cabeza
            lbl_dolor_cabeza.Visible = false;
            panel_dolor.Visible = false; materialRadioButton7.Visible = false; materialRadioButton8.Visible = false;

            //fiebre
            lbl_fiebre.Visible = true;
            panel_fiebre.Visible = true; materialRadioButton1.Checked = false; materialRadioButton2.Checked = false;
        }

        #region FIEBRE
        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //materialRadioButton1.Checked = false;
            if (materialRadioButton1.Checked)
            {
                //radio button de si a la fiebre
                //this.panel_fiebre.Visible = false;
                //this.panel_estornudos.Visible = true;
            }
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //radio button de no a la fiebre
            panel_fiebre.Visible = false; materialRadioButton1.Visible = false; materialRadioButton2.Visible = false; lbl_fiebre.Visible = false;
            panel_estornudos.Visible = true; materialRadioButton3.Visible = true; materialRadioButton4.Visible = true; lbl_tos_estornudos.Visible = true;
            panel_estornudos.BringToFront();
        }
        #endregion

        #region TOS O ESTORNUDOS
        private void materialRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //radiobutton de si a tos y estornudos
            panel_estornudos.Visible = false; materialRadioButton3.Visible = false; materialRadioButton4.Visible = false; lbl_tos_estornudos.Visible = false;
            panel_malestar.Visible = true; materialRadioButton5.Visible = true; materialRadioButton6.Visible = true; lbl_malestar_gen.Visible = true;
            panel_malestar.BringToFront();
        }

        private void materialRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //radiobutton de no a tos y estornudos
            panel_estornudos.Visible = false; materialRadioButton3.Visible = false; materialRadioButton4.Visible = false; lbl_tos_estornudos.Visible = false;
            panel_malestar.Visible = true; materialRadioButton5.Visible = true; materialRadioButton6.Visible = true; lbl_malestar_gen.Visible = true;
            panel_malestar.BringToFront();
        }
        #endregion

        #region MALESTAR GENERAL
        private void materialRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            //radiobutton de si a malestar general
            panel_malestar.Visible = false; materialRadioButton5.Visible = false; materialRadioButton6.Visible = false; lbl_malestar_gen.Visible = false;
            panel_malestar.Hide();
            
            panel_dolor.Visible = true; materialRadioButton7.Visible = true; materialRadioButton8.Visible = true; lbl_dolor_cabeza.Visible = true;
            panel_dolor.BringToFront(); materialRadioButton7.BringToFront(); materialRadioButton8.BringToFront(); lbl_dolor_cabeza.BringToFront(); 
        }

        private void materialRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            //radiobutton de no a malestar general
            panel_malestar.Visible = false; materialRadioButton5.Visible = false; materialRadioButton6.Visible = false; lbl_malestar_gen.Visible = false;
            panel_malestar.Hide();
            panel_dolor.Visible = true; materialRadioButton7.Visible = true; materialRadioButton8.Visible = true; lbl_dolor_cabeza.Visible = true;
            panel_dolor.BringToFront(); materialRadioButton7.BringToFront(); materialRadioButton8.BringToFront(); lbl_dolor_cabeza.BringToFront();

        }

        #endregion

        #region DOLOR DE CABEZA
        private void materialRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            //radiobutton de si al dolor de cabeza
            panel_dolor.Visible = false; materialRadioButton7.Visible = false; materialRadioButton8.Visible = false; lbl_dolor_cabeza.Visible = false;
            panel_dificultad.Visible = true; materialRadioButton9.Visible = true; materialRadioButton10.Visible = true; lbl_dificultad_respirar.Visible = true;
            panel_dificultad.BringToFront();
        }

        private void materialRadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            //radiobutton de si al dolor de cabeza
            panel_dolor.Visible = false; materialRadioButton7.Visible = false; materialRadioButton8.Visible = false; lbl_dolor_cabeza.Visible = false;
            panel_dificultad.Visible = true; materialRadioButton9.Visible = true; materialRadioButton10.Visible = true; lbl_dificultad_respirar.Visible = true;
            panel_dificultad.BringToFront();
        }
        #endregion

        #region DIFICULTAD RESPIRATORIA
        private void materialRadioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialRadioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            ComprobanteVisor visor = new ComprobanteVisor();
            visor.Show();

            this.Hide();
        }
    }
}
