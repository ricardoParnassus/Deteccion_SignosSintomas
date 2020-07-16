using formularioDeteccionSignos_Form.classes;
using formularioDeteccionSignos_Form.resources.views;
using formularioDeteccionSignos_Form.resources.views.sintomasViews;
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

namespace formularioDeteccionSignos_Form
{
    public partial class Form2 : MaterialForm
    {
        string id_empleado = string.Empty;
        string id_entrevistador = string.Empty;
        public int fiebre = 0;
        public int tos_estornudos = 0;
        public int malestar = 0;
        public int dolor_cabeza = 0;
        public int dificultad_resp = 0;
        public int flag = 0;
        public string id_transaccion = string.Empty;
        int contador = 0;
        /*
          0 - fiebre
          1 - tos
          2 - malestar
          3 - dolor
          4 - dificultad
             */
        public Form2(string id_empleado, string id_entrevistador)
        {
            InitializeComponent();
            this.id_empleado = id_empleado;
            this.id_entrevistador = id_entrevistador;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //SE CARGA LA CAMARA EN UN FORM QUE SE CARGA E EL PANEL
            fiebreView fiebre = new fiebreView();
            if (this.panel_carga_visor.Controls.Count > 0)
                this.panel_carga_visor.Controls.RemoveAt(0);
            Form fh = fiebre as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel_carga_visor.Controls.Add(fh);
            this.panel_carga_visor.Tag = fh;
            fh.Show();
            this.flag = 0;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            //SACAMOS UN SCREEN SHOT
            //fnScreenShot("");
            //Thread.Sleep(1500);
            switch (flag)
            {
                //formulario de fiebre
                case 0:
                    //fiebreView fiebre = new fiebreView();
                    //if (this.panel_carga_visor.Controls.Count > 0)
                    //    this.panel_carga_visor.Controls.RemoveAt(0);
                    //Form fh_fiebre = fiebre as Form;
                    //fh_fiebre.TopLevel = false;
                    //fh_fiebre.Dock = DockStyle.Fill;
                    //this.panel_carga_visor.Controls.Add(fh_fiebre);
                    //this.panel_carga_visor.Tag = fh_fiebre;
                    //fh_fiebre.Show();

                    tosEstornudosView tos = new tosEstornudosView();
                    if (this.panel_carga_visor.Controls.Count > 0)
                        this.panel_carga_visor.Controls.RemoveAt(0);
                    Form fh_tos = tos as Form;
                    fh_tos.TopLevel = false;
                    fh_tos.Dock = DockStyle.Fill;
                    this.panel_carga_visor.Controls.Add(fh_tos);
                    this.panel_carga_visor.Tag = fh_tos;
                    fh_tos.Show();
                    contador++;
                    this.flag = 1;
                    this.fiebre = 1;
                    return;
                //formulario de tos o estornudos
                case 1:

                    malestarView malestar = new malestarView();
                    if (this.panel_carga_visor.Controls.Count > 0)
                        this.panel_carga_visor.Controls.RemoveAt(0);
                    Form fh_malestar = malestar as Form;
                    fh_malestar.TopLevel = false;
                    fh_malestar.Dock = DockStyle.Fill;
                    this.panel_carga_visor.Controls.Add(fh_malestar);
                    this.panel_carga_visor.Tag = fh_malestar;
                    fh_malestar.Show();
                    contador++;
                    this.flag = 2;
                    this.tos_estornudos = 1;
                    return;
                //formulario de malestar general
                case 2:

                    dolorCabezaView cabeza = new dolorCabezaView();
                    if (this.panel_carga_visor.Controls.Count > 0)
                        this.panel_carga_visor.Controls.RemoveAt(0);
                    Form fh_cabeza = cabeza as Form;
                    fh_cabeza.TopLevel = false;
                    fh_cabeza.Dock = DockStyle.Fill;
                    this.panel_carga_visor.Controls.Add(fh_cabeza);
                    this.panel_carga_visor.Tag = fh_cabeza;
                    fh_cabeza.Show();
                    contador++;
                    this.flag = 3;
                    this.malestar = 1;
                    return;
                //formulario de dolor de cabeza
                case 3:

                    dificultadView dificultad = new dificultadView();
                    if (this.panel_carga_visor.Controls.Count > 0)
                        this.panel_carga_visor.Controls.RemoveAt(0);
                    Form fh_dificultad = dificultad as Form;
                    fh_dificultad.TopLevel = false;
                    fh_dificultad.Dock = DockStyle.Fill;
                    this.panel_carga_visor.Controls.Add(fh_dificultad);
                    this.panel_carga_visor.Tag = fh_dificultad;
                    fh_dificultad.Show();
                    contador++;
                    this.flag = 4;
                    this.dolor_cabeza = 1;
                    return;
                //formulario de dificultad respiratoria
                case 4:
                    contador++;
                    this.flag = 5;
                    this.dificultad_resp = 1;
                    break;
                default:
                    break;
            }

            if (contador > 1)
            {
                message mensaje_ = new message();
                mensaje_.Show();
            }
            
            
            DateTime fecha = DateTime.Now;
            ok_cancel_message mensaje = new ok_cancel_message("DESEA IMPRIMIR EL FORMATO?");
            transacciones transaccion = new transacciones();
            if (DialogResult.OK == mensaje.ShowDialog())
            {
                //CARGAMOS EL COMPROBANTE DEL CUESTIONARIO
                ComprobanteVisor visor = new ComprobanteVisor(0, Int32.Parse(this.id_empleado));
                visor.fiebre = this.fiebre;
                visor.tos = this.tos_estornudos;
                visor.malestar = this.malestar;
                visor.dolor = this.dolor_cabeza;
                visor.dificultad = this.dificultad_resp;
                visor.numero_entrevistador = this.id_entrevistador;
                visor.ShowDialog();
                //GUARDAMOS LA TRANSACCION EN LA BASE DE DATOS
                //transaccion.fnInsertaDatosTransaccion(this.id_empleado, this.id_entrevistador, fecha.ToString("MM/dd/yyyy"), this.fiebre.ToString(), this.tos_estornudos.ToString(), this.malestar.ToString(), this.dolor_cabeza.ToString(), this.dificultad_resp.ToString(), visor.path_archivo);
                transaccion.fnActualizaDatosTransaccion(this.id_transaccion, this.fiebre.ToString(), this.tos_estornudos.ToString(), this.malestar.ToString(), this.dolor_cabeza.ToString(), this.dificultad_resp.ToString(), visor.path_archivo);
                this.Hide();
            }
            else
            {
                //CARGAMOS EL COMPROBANTE DEL CUESTIONARIO
                ComprobanteVisor visor = new ComprobanteVisor(0, Int32.Parse(this.id_empleado));
                visor.fiebre = this.fiebre;
                visor.tos = this.tos_estornudos;
                visor.malestar = this.malestar;
                visor.dolor = this.dolor_cabeza;
                visor.dificultad = this.dificultad_resp;
                visor.numero_entrevistador = this.id_entrevistador;
                visor.fnCargaNuevoArchivo();
                //GUARDAMOS LA TRANSACCION EN LA BASE DE DATOS
                transaccion.fnActualizaDatosTransaccion(this.id_transaccion, this.fiebre.ToString(), this.tos_estornudos.ToString(), this.malestar.ToString(), this.dolor_cabeza.ToString(), this.dificultad_resp.ToString(), visor.path_archivo);
                //transaccion.fnInsertaDatosTransaccion(this.id_empleado, this.id_entrevistador, fecha.ToString("MM/dd/yyyy"), this.fiebre.ToString(), this.tos_estornudos.ToString(), this.malestar.ToString(), this.dolor_cabeza.ToString(), this.dificultad_resp.ToString(), visor.path_archivo);
                this.Hide();
            }
        }

        private void fnScreenShot(String rutaGuardar)
        {
            string path_documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string aux = (string.IsNullOrEmpty(rutaGuardar) || string.IsNullOrWhiteSpace(rutaGuardar))
                            ? path_documents + @"ArchivoPrueba\capturasPantalla\screenshot_prueba.jpg"
                            : rutaGuardar;
            try
            {
                Screen screen = Screen.AllScreens[0]; /// Screen.PrimaryScreen;
                                                      /// Tamaño de la imagen
                int Width = screen.Bounds.Width;
                int Height = screen.Bounds.Height;
                System.Drawing.Rectangle captureRectangle = screen.Bounds;
                Bitmap captureBitmap = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                /// Capturando
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                int dedondeX = captureRectangle.Left;
                int dedondeY = captureRectangle.Top;
                int hastadondeX = 0;
                int hastadondeY = 0;
                captureGraphics.CopyFromScreen(dedondeX, dedondeY, hastadondeX, hastadondeY, captureRectangle.Size);
                captureBitmap.Save((string.IsNullOrEmpty(rutaGuardar) || string.IsNullOrWhiteSpace(rutaGuardar)) ? aux : rutaGuardar, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {

            }
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            switch (flag)
            {
                //formulario de fiebre
                case 0:
                    //fiebreView fiebre = new fiebreView();
                    //if (this.panel_carga_visor.Controls.Count > 0)
                    //    this.panel_carga_visor.Controls.RemoveAt(0);
                    //Form fh_fiebre = fiebre as Form;
                    //fh_fiebre.TopLevel = false;
                    //fh_fiebre.Dock = DockStyle.Fill;
                    //this.panel_carga_visor.Controls.Add(fh_fiebre);
                    //this.panel_carga_visor.Tag = fh_fiebre;
                    //fh_fiebre.Show();

                    tosEstornudosView tos = new tosEstornudosView();
                    if (this.panel_carga_visor.Controls.Count > 0)
                        this.panel_carga_visor.Controls.RemoveAt(0);
                    Form fh_tos = tos as Form;
                    fh_tos.TopLevel = false;
                    fh_tos.Dock = DockStyle.Fill;
                    this.panel_carga_visor.Controls.Add(fh_tos);
                    this.panel_carga_visor.Tag = fh_tos;
                    fh_tos.Show();

                    this.flag = 1;
                    this.fiebre = 0;
                    return;
                //formulario de tos o estornudos
                case 1:

                    malestarView malestar = new malestarView();
                    if (this.panel_carga_visor.Controls.Count > 0)
                        this.panel_carga_visor.Controls.RemoveAt(0);
                    Form fh_malestar = malestar as Form;
                    fh_malestar.TopLevel = false;
                    fh_malestar.Dock = DockStyle.Fill;
                    this.panel_carga_visor.Controls.Add(fh_malestar);
                    this.panel_carga_visor.Tag = fh_malestar;
                    fh_malestar.Show();

                    this.flag = 2;
                    this.tos_estornudos = 0;
                    return;
                //formulario de malestar general
                case 2:

                    dolorCabezaView cabeza = new dolorCabezaView();
                    if (this.panel_carga_visor.Controls.Count > 0)
                        this.panel_carga_visor.Controls.RemoveAt(0);
                    Form fh_cabeza = cabeza as Form;
                    fh_cabeza.TopLevel = false;
                    fh_cabeza.Dock = DockStyle.Fill;
                    this.panel_carga_visor.Controls.Add(fh_cabeza);
                    this.panel_carga_visor.Tag = fh_cabeza;
                    fh_cabeza.Show();

                    this.flag = 3;
                    this.malestar = 0;
                    return;
                //formulario de dolor de cabeza
                case 3:

                    dificultadView dificultad = new dificultadView();
                    if (this.panel_carga_visor.Controls.Count > 0)
                        this.panel_carga_visor.Controls.RemoveAt(0);
                    Form fh_dificultad = dificultad as Form;
                    fh_dificultad.TopLevel = false;
                    fh_dificultad.Dock = DockStyle.Fill;
                    this.panel_carga_visor.Controls.Add(fh_dificultad);
                    this.panel_carga_visor.Tag = fh_dificultad;
                    fh_dificultad.Show();

                    this.flag = 4;
                    this.dolor_cabeza = 0;
                    return;
                //formulario de dificultad respiratoria
                case 4:

                    this.flag = 5;
                    this.dificultad_resp = 0;
                    break;
                default:
                    break;
            }

            DateTime fecha = DateTime.Now;
            ok_cancel_message mensaje = new ok_cancel_message("DESEA IMPRIMIR EL FORMATO?");
            transacciones transaccion = new transacciones();
            if (DialogResult.OK == mensaje.ShowDialog())
            {
                //CARGAMOS EL COMPROBANTE DEL CUESTIONARIO
                ComprobanteVisor visor = new ComprobanteVisor(0, Int32.Parse(this.id_empleado));
                visor.fiebre = this.fiebre;
                visor.tos = this.tos_estornudos;
                visor.malestar = this.malestar;
                visor.dolor = this.dolor_cabeza;
                visor.dificultad = this.dificultad_resp;
                visor.ShowDialog();
                //GUARDAMOS LA TRANSACCION EN LA BASE DE DATOS
                transaccion.fnInsertaDatosTransaccion(this.id_empleado, this.id_entrevistador, fecha.ToString("MM/dd/yyyy"), this.fiebre.ToString(), this.tos_estornudos.ToString(), this.malestar.ToString(), this.dolor_cabeza.ToString(), this.dificultad_resp.ToString(), visor.path_archivo);
                this.Hide();
            }
            else
            {
                //CARGAMOS EL COMPROBANTE DEL CUESTIONARIO
                ComprobanteVisor visor = new ComprobanteVisor(0, Int32.Parse(this.id_empleado));
                visor.fiebre = this.fiebre;
                visor.tos = this.tos_estornudos;
                visor.malestar = this.malestar;
                visor.dolor = this.dolor_cabeza;
                visor.dificultad = this.dificultad_resp;
                visor.fnCargaNuevoArchivo();
                //GUARDAMOS LA TRANSACCION EN LA BASE DE DATOS
                transaccion.fnInsertaDatosTransaccion(this.id_empleado, this.id_entrevistador, fecha.ToString("MM/dd/yyyy"), this.fiebre.ToString(), this.tos_estornudos.ToString(), this.malestar.ToString(), this.dolor_cabeza.ToString(), this.dificultad_resp.ToString(), visor.path_archivo);
                this.Hide();
            }
        }
    }
}
