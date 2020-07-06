using formularioDeteccionSignos_Form.classes;
using formularioDeteccionSignos_Form.resources.views;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using formularioDeteccionSignos_Form.classes;
using formularioDeteccionSignos_Form.resources.camera.Respuesta;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Globalization;
using System.Drawing.Imaging;

namespace formularioDeteccionSignos_Form
{
    public partial class Form1 : MaterialForm
    {
        List<ORealPlay> _Devices;
        ORespuesta _Respuesta;
        OWebcam _Webcam;
        int _Camaras;
        int _XLocation;
        int _YLocation;
        int _XLocation_pnlWebCam;
        int _YLocation_pnlWebCam;
        FilterInfoCollection _FilterInfoCollection;
        public string id_entrevistador = string.Empty;
        string id_filtro = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //se carga el formulario winform
            fnInicializaCamaraHikVision();
            fnShowCameraHikVison();
            fnConectarWebCam();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //validar si estan todos los datos completos 
                if (string.IsNullOrEmpty(this.txtCuestionado.Text) || string.IsNullOrWhiteSpace(this.txtCuestionado.Text))
                {
                    MessageBox.Show("Debes Ingresar los datos Solicitados");
                    return;
                }
                else
                {
                    incidenciaDeteccionClass incidencia = new incidenciaDeteccionClass(); 
                }
            }
            catch (Exception ex)
            {
                //ESCRIBIR EN LOG 
            }
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
                    foreach (DataRow item in dtbl_datos.Rows)
                    {
                        object[] array_usuario = item.ItemArray;
                        txtCuestionado.Text = array_usuario[2].ToString() + " " +
                                              array_usuario[3].ToString() + " " +
                                              array_usuario[4].ToString();
                        txt_num_empleado.Text = array_usuario[0].ToString();
                        txtGenero.Text = array_usuario[5].ToString();
                        txtEdad.Text = array_usuario[6].ToString();
                        txtPuesto.Text = /*array_usuario[8].ToString();*/ "Supervisor";
                        txt_correo.Text = array_usuario[9].ToString();
                    }
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
            Form2 form2 = new Form2();
            form2.Show();

            fnValidaTemperatura();
        }

        public void fnValidaTemperatura()
        {
            float temp = float.Parse(this.txt_temperatura.Text, CultureInfo.InvariantCulture.NumberFormat);
            string temp_BDConfig = "37.5";
            float aux1 = float.Parse(temp_BDConfig, CultureInfo.InvariantCulture.NumberFormat);
            if (temp >= aux1)
            {
                message msg = new message();
                msg.Show();
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            filtroWithGrid filtro = new filtroWithGrid();
            filtro.ShowDialog();

            //FormCollection fc = Application.OpenForms;
            //foreach (Form frm in fc)
            //{
            //    //if (frm.Name == "filtroWithGrid")
                    
            //}

            id_filtro = filtro.id_recuperado;
            fnFiltroPorEmpleado(id_filtro);
        }
        public byte[] ImageToByteArray(System.Drawing.Image imagen)
        {
            MemoryStream ms = new MemoryStream();
            imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public void fnInicializaCamaraHikVision()
        {
            try
            {
                //INICIALIZAMOS LAS VARIABLES
                _Devices = new List<ORealPlay>();
                _Respuesta = new ORespuesta();
                _Camaras = 0;
                _XLocation = 0;
                _YLocation = 0;
                //LOGEO DE CAMARAS
                ORealPlay _Data = new ORealPlay();
                //DATOS CAMARA HIKVISION
                _Data.IP = "192.168.1.64";
                _Data.Puerto = ushort.Parse("8000");
                _Data.Usuario = "admin";
                _Data.Password = "JORBEE2020";

                _Respuesta = _Data.LoginHikvision();
                if (!_Respuesta.Exitoso)
                {
                    //MessageBox.Show(_Respuesta.Mensaje);
                    return;
                }
                //MessageBox.Show("Login Exitoso!!!");
                _Data.Nombre = "Hikvision " + _Data.IP;
                _Devices.Add(_Data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
        }

        public void fnShowCameraHikVison()
        {
            try
            {
                ORealPlay _Device = _Devices[0];
                _Device.Canal = 1;

                var picture = new PictureBox
                {
                    Name = "canal" + _Camaras.ToString(),
                    Size = new Size(500, 320),
                    Location = new Point(_XLocation, _YLocation),
                };
                _XLocation += 500;
                if (_XLocation > 1500)
                {
                    _XLocation = 0;
                    _YLocation += 320;
                }
                panel_camaraExt.Controls.Add(picture);
                _Device.Window = picture.Handle;
                _Respuesta = _Device.StartRealPlayHikvision();
                if (!_Respuesta.Exitoso)
                {
                    MessageBox.Show(_Respuesta.Mensaje);
                    return;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void fnConectarWebCam()
        {
            _FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            _Webcam = new OWebcam();
            _XLocation_pnlWebCam = 0;
            _YLocation_pnlWebCam = 0;
            var picture = new PictureBox
            {
                Name = "canal" + _Camaras.ToString(),
                Size = new Size(800, 500),
                Location = new Point(_XLocation_pnlWebCam, _YLocation_pnlWebCam),
            };
            _XLocation_pnlWebCam += 800;
            if (_XLocation_pnlWebCam > 1500)
            {
                _XLocation_pnlWebCam = 0;
                _YLocation_pnlWebCam += 500;
            }
            panel_webcam.Controls.Add(picture);
            _Webcam.Image = picture;
            _Webcam.Device = new VideoCaptureDevice(_FilterInfoCollection[0].MonikerString);
            _Webcam.Device.NewFrame += VideoCaptureDevice_NewFrame;
            _Webcam.Device.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            _Webcam.Image.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void txt_num_empleado_KeyUp(object sender, KeyEventArgs e)
        {
            fnFiltroPorEmpleado(txt_num_empleado.Text);
        }

        public void fnCargaDatosEntrevistador()
        {
            string entrada = this.id_entrevistador;
            DataTable dtbl_datos = new DataTable();
            try
            {
                //cargar los datos del empleado
                string aux = string.Empty;
                usuarioClass busqueda = new usuarioClass();
                dtbl_datos = busqueda.fnSeleccionaUsuario(entrada);
                if (dtbl_datos.Rows.Count > 0)
                {
                    foreach (DataRow item in dtbl_datos.Rows)
                    {
                        object[] array_usuario = item.ItemArray;
                        txtCuestionado.Text = array_usuario[2].ToString() + " " +
                                              array_usuario[3].ToString() + " " +
                                              array_usuario[4].ToString();
                        txt_num_empleado.Text = array_usuario[0].ToString();
                        txtGenero.Text = array_usuario[5].ToString();
                        txtEdad.Text = array_usuario[6].ToString();
                        txtPuesto.Text = /*array_usuario[8].ToString();*/ "Supervisor";
                        txt_correo.Text = array_usuario[9].ToString();
                    }
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

        /* CAPTURA DE PANTALLA - JN */
        private void CapturaSS(String rutaGuardar)
        {
            string aux = @"C:\Users\Phrankie Garcia\Documents\ArchivoPrueba\capturasPantalla";
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
                captureBitmap.Save((string.IsNullOrEmpty(rutaGuardar) || string.IsNullOrWhiteSpace(rutaGuardar)) ? aux : rutaGuardar, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            catalogoParametrizacion ctlg_parametrizacion = new catalogoParametrizacion();
            ctlg_parametrizacion.Show();
        }
    }
}
