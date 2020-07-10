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
using formularioDeteccionSignos_Form.resources.camera.Respuesta;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Globalization;
using System.Drawing.Imaging;
using Luxand;
using System.Runtime.InteropServices;
using System.Windows.Threading;
using System.Threading;

namespace formularioDeteccionSignos_Form
{
    public partial class Form1 : MaterialForm
    {
        #region VARIABLES GLOBALES
        //VARIABLES GLOBALES
        String cameraName;
        bool needClose = false;
        // WinAPI procedure to release HBITMAP handles returned by FSDKCam.GrabFrame
        [DllImport("gdi32.dll")]
        static extern bool DeleteObject(IntPtr hObject);
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
        object[] user_data;
        #endregion

        //CONSTRUCTOR
        public Form1(object[] user_data)
        {
            InitializeComponent();
            this.user_data = user_data;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //se carga el formulario winform
            //conexionBD cnn = new conexionBD();
            //cnn.fnInsertaIMagenBDD(1, @"C:\Users\Phrankie Garcia\Documents\ArchivoPrueba\descarga_1.jpg");
            this.Location = new Point(0, 0); //sobra si tienes la posición en el diseño
            //this.Size = new Size(this.Width, Screen.PrimaryScreen.WorkingArea.Size.Height);
            //this.WindowState = FormWindowState.Maximized;
            fnInicializaCamaraHikVision();
            fnShowCameraHikVison();
            //fnConectarWebCam();
        }
        
        public void fncargaFotoUsuario()
        {
            try
            {
                conexionBD cc = new conexionBD();
                img_fotoUsuario.Image = cc.ObtenerBitmapBDD(Int32.Parse(id_entrevistador));
                img_fotoUsuario.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {

            }
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
            fnValidaTemperatura();

            Form2 form2 = new Form2();
            form2.Show();
        }

        public void fnValidaTemperatura()
        {
            float temp = float.Parse(this.txt_temperatura.Text, CultureInfo.InvariantCulture.NumberFormat);
            string temp_BDConfig = "37.5";
            float aux1 = float.Parse(temp_BDConfig, CultureInfo.InvariantCulture.NumberFormat);
            if (temp >= aux1)
            {
                message msg = new message();
                msg.ShowDialog();
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

            //if (DialogResult.OK == filtro.ShowDialog())
            //{
            //    id_filtro = filtro.id_recuperado;
            //    fnFiltroPorEmpleado(id_filtro);
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
                captureBitmap.Save((string.IsNullOrEmpty(rutaGuardar) || string.IsNullOrWhiteSpace(rutaGuardar)) ? aux : rutaGuardar, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// AGREGAMOS PARAMETROS DEL SISTEMA(CAMARAS, TEMPERATURA PERMITIDA)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            catalogoParametrizacion ctlg_parametrizacion = new catalogoParametrizacion();
            ctlg_parametrizacion.Show();
        }

        /// <summary>
        /// REALIZA UNA CAPTURA DE PANTALLA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            fnScreenShot("");
            cuadroMensaje msg = new cuadroMensaje();
            msg.fnCargarMensaje("SE HA REALIZADO LA CAPTURA DE PANTALLA");
            msg.Show();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // SE CARGA LA IMAGEN Y LOS DATOS DEL USUARIO DE LA BASE DE DATOS
            fncargaFotoUsuario();
            fnCargaDatosEntrevistador_login();
            //SE CARGA LA CAMARA EN UN FORM QUE SE CARGA E EL PANEL
            visorCamaraLuxand vcl = new visorCamaraLuxand(user_data);
            if (this.panel_webcam.Controls.Count > 0)
                this.panel_webcam.Controls.RemoveAt(0);
            Form fh = vcl as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            //Dispatcher.Invoke(((Action) (() => this.panel_webcam.Controls.Add(fh))));
            //Dispatcher.Invoke(((Action)(() => this.panel_webcam.Tag = fh)));
            this.panel_webcam.Controls.Add(fh);
            this.panel_webcam.Tag = fh;
            fh.Show();
            //SE AGREGA EL FORM EN EL PANEL A TRAVES DE UN HILO
            //ThreadStart _delegate = new ThreadStart(hiloEjecucion);
            //Thread hilo = new Thread(() => hiloEjecucion());
            //Thread hilo = new Thread(_delegate);
            //hilo.Start();
        }
        
        public void fnCargaDatosEntrevistador_login()
        {
            this.lbl_num_entrevistador.Text = this.user_data[1].ToString();
            this.lbl_nombre_entrevistador.Text = this.user_data[2].ToString() + this.user_data[3].ToString() + this.user_data[4].ToString();
            this.lbl_genero_entrevistador.Text = this.user_data[5].ToString();
            this.lbl_edad_entrevistador.Text = this.user_data[6].ToString();
            this.lbl_puesto_entrevistador.Text = this.user_data[8].ToString();
            this.lbl_correo_entrevistador.Text = this.user_data[9].ToString();
        }

        public void hiloEjecucion()
        {
            //Dispatcher.Invoke(((Action)(() => txtTrabajo.Text += "")));
            //Dispatcher.Invoke(((Action)(() => txtTrabajo.Text += "\nIniciando...")));
            //new Clases.Metodos().Prueba();
            Thread TypingThread = new Thread(delegate () {
                // Cambiar el estado de los botones dentro del hilo TypingThread
                // Esto no generará excepciones de nuevo !
                //if (button1.InvokeRequired)
                //{
                //    button1.Invoke(new MethodInvoker(delegate
                //    {
                //        button1.Enabled = true;
                //        button2.Enabled = false;
                //    }));
                //}
                visorCamaraLuxand vcl = new visorCamaraLuxand(user_data);
                if (this.panel_webcam.Controls.Count > 0)
                    this.panel_webcam.Controls.RemoveAt(0);
                Form fh = vcl as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                //Dispatcher.Invoke(((Action) (() => this.panel_webcam.Controls.Add(fh))));
                //Dispatcher.Invoke(((Action)(() => this.panel_webcam.Tag = fh)));
                this.panel_webcam.Controls.Add(fh);
                this.panel_webcam.Tag = fh;
                fh.Show();
            });
            // Cambiar el estado de los botones en el hilo principal
            //button1.Enabled = false;
            //button2.Enabled = true;
            TypingThread.Start();
        }

        /// <summary>
        /// INGRESA UN USUARIO NUEVO AL SISTEMA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            InputName user_input = new InputName();
            usuarioClass nuevo_usuario = new usuarioClass();
            cuadroMensaje mensaje = new cuadroMensaje();
            if (DialogResult.OK == user_input.ShowDialog())
            {
                
                if (nuevo_usuario.fnIngresaUsuario(user_input.userName, user_input.userPaterno, user_input.userMaterno, user_input.userGenero, user_input.userEdad, user_input.userRol, user_input.userPuesto, user_input.userCorreo, "jorbee2020"))
                {
                    mensaje.fnCargarMensaje("SE AGREGO EL USUARIO");
                    mensaje.Show();
                }
                else
                {
                    mensaje.fnCargarMensaje("ERROR: NO SE AGREGO EL USUARIO");
                    mensaje.Show();
                }
            }
        }

        /// <summary>
        /// REIMPRIMIME UN COMPROBANTE QUE SE TENGA EN EL HISTORICO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            filtroWithGrid filtro = new filtroWithGrid();
            filtro.ShowDialog();

            string id_user_search = filtro.id_recuperado;
            gridHistoricoComprobantes historico = new gridHistoricoComprobantes(id_user_search);
            historico.Show();
        }
    }
}
