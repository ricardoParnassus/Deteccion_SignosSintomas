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
        public gridHistoricoComprobantes()
        {
            InitializeComponent();
            //this.id_empleado = id_empleado;
        }

        private void gridHistoricoComprobantes_Shown(object sender, EventArgs e)
        {
            DataTable dtbl_datos = new DataTable();
            try
            {
                //cargar el historico del empleado
                //transacciones historico = new transacciones();
                //dtbl_datos = historico.fnConsultaTransaccionesEmpleado(this.id_empleado);
                //if (dtbl_datos.Rows.Count > 0)
                //{
                //    dgv_historico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //    dgv_historico.DataSource = dtbl_datos;
                //}
                //else
                //{
                //    return;
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
        }

        private void dgv_historico_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id_recuperado = dgv_historico.CurrentRow.Cells[0].Value.ToString();
            ComprobanteVisor visor_comprobante = new ComprobanteVisor(0, Int32.Parse(id_recuperado));
            this.Hide();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            fnFiltroPorEmpleado(txt_num_empleado.Text);
        }

        public void fnFiltroPorEmpleado(string id)
        {
            string entrada = id;
            DataTable dtbl_datos = new DataTable();
            try
            {
                //cargar los datos del empleado
                string aux = string.Empty;
                usuarioClass busqueda = new usuarioClass();
                dtbl_datos = busqueda.fnSeleccionaUsuario(entrada);
                if (dtbl_datos.Rows.Count > 0)
                {
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

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            string id_recuperado = dgv_historico.CurrentRow.Cells[0].Value.ToString();
            ComprobanteVisor visor_comprobante = new ComprobanteVisor(1, Int32.Parse(id_recuperado));
            visor_comprobante.Show();
            visorScreenShot screenshot = new visorScreenShot(id_recuperado);
            //screenshot.id_transaccion = id_recuperado;
            screenshot.Show();
            this.Hide();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            DateTime fecha_inicial = dateTimePicker1.Value;
            DateTime fecha_final = dateTimePicker2.Value;
            DataTable dtbl_datos = new DataTable();
            try
            {
                //cargar los datos del empleado
                string aux = string.Empty;
                conexionBD cnn = new conexionBD();
                dtbl_datos = cnn.fnConsultaSentencia("SELECT * FROM tbl_transaccionDet WHERE fecha BETWEEN '" + fecha_inicial.ToString("MM/dd/yyyy") + "' AND '" + fecha_final.ToString("MM/dd/yyyy") + "'");
                if (dtbl_datos.Rows.Count > 0)
                {
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
    }
}
