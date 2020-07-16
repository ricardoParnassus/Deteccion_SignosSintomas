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
    public partial class ComprobanteVisor : MaterialForm
    {
        string id_transaccion = string.Empty;
        string id_empleado = string.Empty;
        public string numero_entrevistador = string.Empty;
        public string path_archivo = string.Empty;
        string codigo_actual = string.Empty;
        int flag = 0;
        public int fiebre = 0;
        public int tos = 0;
        public int malestar = 0;
        public int dolor = 0;
        public int dificultad = 0;
        /*
         0 -- nuevo archivo
         1 -- cargar un archivo historico
         2 -- aun no hay 
             */
        public ComprobanteVisor(int flag, int id)
        {
            InitializeComponent();

            this.flag = flag;
            if (flag == 0) this.id_empleado = id.ToString();
            else this.id_transaccion = id.ToString();
            this.codigo_actual = fnGeneraCodigoArchivo(this.id_empleado);
            this.path_archivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ArchivoPrueba\" + codigo_actual + ".pdf";
        }

        private void ComprobanteVisor_Load(object sender, EventArgs e)
        {
            if (flag == 0) fnCargaNuevoArchivo();
            else fnCargaArchivoHistorico();
        }

        public void fnCargaNuevoArchivo()
        {
            usuarioClass user_dat = new usuarioClass();
            DataTable usuario_dat = user_dat.fnSeleccionaUsuario(id_empleado);
            string nombre_completo = string.Empty;
            DateTime dateTime = DateTime.Now;
            string fecha_actual = dateTime.ToString("MM/dd/yyyy");
            object[] obj;
            foreach (DataRow item in usuario_dat.Rows)
            {
                obj = item.ItemArray;
                nombre_completo = obj[2].ToString() + " " + obj[3].ToString() + " " + obj[4].ToString();
            }
            CrearComprobantePDF pdf = new CrearComprobantePDF(nombre_completo, fecha_actual, this.codigo_actual, this.numero_entrevistador, this.fiebre, this.tos, this.malestar, this.dolor, this.dificultad);
            pdf.fnCrearArchivo();
            pdf.fnConstruirCuerpoArchivo();
            
            web_browser_files.Navigate(this.path_archivo);
        }

        public void fnCargaNuevoArchivo(int fiebre, int tos, int malestar, int dolor, int dificultad)
        {
            usuarioClass user_dat = new usuarioClass();
            DataTable usuario_dat = user_dat.fnSeleccionaUsuario(id_empleado);
            string nombre_completo = string.Empty;
            DateTime dateTime = DateTime.Now;
            string fecha_actual = dateTime.ToString("MM/dd/yyyy");
            object[] obj;
            foreach (DataRow item in usuario_dat.Rows)
            {
                obj = item.ItemArray;
                nombre_completo = obj[2].ToString() + " " + obj[3].ToString() + " " + obj[4].ToString();
            }
            CrearComprobantePDF pdf = new CrearComprobantePDF(nombre_completo, fecha_actual, this.codigo_actual, this.numero_entrevistador, fiebre, tos, malestar, dolor, dificultad);
            pdf.fnCrearArchivo();
            pdf.fnConstruirCuerpoArchivo();

            web_browser_files.Navigate(this.path_archivo);
        }

        public void fnCargaArchivoHistorico()
        {
            transacciones transaccion = new transacciones();
            DataTable dtbl_transaccion = transaccion.fnConsultaDatosTransaccion(this.id_transaccion);
            object[] obj;
            string ruta_archivo = string.Empty;
            foreach (DataRow item in dtbl_transaccion.Rows)
            {
                obj = item.ItemArray;
                ruta_archivo = obj[9].ToString();
            }
            web_browser_files.Navigate(ruta_archivo);
        }

        public string fnGeneraCodigoArchivo(string num_empleado)
        {
            //numero de empleado, fecha, random de 4 digitos
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            string codigo = _rdm.Next(_min, _max).ToString();
            codigo = (codigo.Length < 4) ? codigo.PadLeft(4, '0') : codigo;
            DateTime fecha = DateTime.Now;
            return "_" + num_empleado + "_" + fecha.ToString("MM/dd/yyyy").Replace("/", "") + codigo;
        }
    }
}
