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
    public partial class gridHistoricoComprobantes : MaterialForm
    {
        string id_empleado = string.Empty;
        public gridHistoricoComprobantes(string id_empleado)
        {
            InitializeComponent();
            this.id_empleado = id_empleado;
        }

        private void gridHistoricoComprobantes_Shown(object sender, EventArgs e)
        {
            DataTable dtbl_datos = new DataTable();
            try
            {
                //cargar el historico del empleado
                transacciones historico = new transacciones();
                dtbl_datos = historico.fnConsultaTransaccionesEmpleado(this.id_empleado);
                if (dtbl_datos.Rows.Count > 0)
                {
                    dgv_historico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_historico.DataSource = dtbl_datos;
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

        private void dgv_historico_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id_recuperado = dgv_historico.CurrentRow.Cells[0].Value.ToString();

            ComprobanteVisor visor_comprobante = new ComprobanteVisor();
            this.Hide();
        }
    }
}
