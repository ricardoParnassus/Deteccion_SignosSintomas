using formularioDeteccionSignos_Form.classes;
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
    public partial class visorScreenShot : MaterialForm
    {
        public string id_transaccion = string.Empty;
        public visorScreenShot(string id)
        {
            InitializeComponent();
            this.id_transaccion = id;
        }

        private void visorScreenShot_Load(object sender, EventArgs e)
        {

        }

        private void visorScreenShot_Shown(object sender, EventArgs e)
        {
            try
            {
                Image[] imagenes = new Image[2]; int cont = 0;
                conexionBD bd = new conexionBD();
                DataTable tbl = bd.fnConsultaSentencia("select id from tbl_screenshot where id_trans = " + this.id_transaccion);
                foreach (DataRow item in tbl.Rows)
                {
                    imagenes[cont] = bd.ObtenerBitmapBDD(item.Field<int>("id"), "tbl_screenshot", "id=@id");
                    cont++;
                }
                picture_screen_shot.Image = imagenes[0];
                picture_screen_shot.SizeMode = PictureBoxSizeMode.StretchImage;
                Thread.Sleep(500);
                picture_termografica.Image = imagenes[1];
                picture_termografica.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
