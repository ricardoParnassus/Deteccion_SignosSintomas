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
    public partial class filtroWithGrid : MaterialForm
    {
        public string id_recuperado = string.Empty;
        public filtroWithGrid()
        {
            InitializeComponent();
        }

        private void txtFiltro_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFiltro.Text) || string.IsNullOrWhiteSpace(txtFiltro.Text))
            {
                DataTable dt = (DataTable)dgv_empleados.DataSource;
                dt.Clear();
            }
            DataTable dtbl_datos = new DataTable();
            try
            {
                //carcgar los datos del empleado
                string entrada = txtFiltro.Text;
                string aux = string.Empty;
                usuarioClass busqueda = new usuarioClass();
                dtbl_datos = busqueda.fnSeleccionaUsuarioNombre(entrada);
                if (dtbl_datos.Rows.Count > 0)
                {
                    dgv_empleados.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                    dgv_empleados.DataSource = dtbl_datos;
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
        }

        private void dgv_empleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.id_recuperado = dgv_empleados.CurrentRow.Cells[0].Value.ToString();
            Thread.Sleep(2000);
            this.Hide();
        }
    }
}
