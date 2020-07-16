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
        ORespuesta[] _Respuesta;
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
        DataTable datos_camara;
        string id_transaccion = string.Empty;
        int flag = 0;
        int width = 0;
        int height = 0;
        #endregion

        //CONSTRUCTOR
        public Form1(object[] user_data)
        {
            InitializeComponent();
            this.user_data = user_data;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Declaramos una variable para manejar los monitores
            Screen[] sMonitores;
            sMonitores = Screen.AllScreens;
            // Posicion del formulario
            this.Left = sMonitores[1].Bounds.Left;
            this.Top = sMonitores[1].Bounds.Top;
            DataTable dtbl = new DataTable();
            conexionBD cnn = new conexionBD();
            dtbl = cnn.fnConsultaSentencia("select marca, dir_ip from tbl_camaras");
            foreach (DataRow item in dtbl.Rows)
            {
                cbbx_camara_empleado.Items.Add(item.Field<string>("marca") + " " +  item.Field<string>("dir_ip"));
                cbbx_camara_entrevistador.Items.Add(item.Field<string>("marca") + " " + item.Field<string>("dir_ip"));
            }
        }
        
        public void fncargaFotoUsuario(string id)
        {
            conexionBD cc = new conexionBD();
            img_fotoUsuario.Image = cc.ObtenerBitmapBDD(Int32.Parse(id), "tbl_fotoUsuarios", "id_user=@id");
            img_fotoUsuario.SizeMode = PictureBoxSizeMode.StretchImage;
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

                        conexionBD cc = new conexionBD();
                        pictureBox1.Image = cc.ObtenerBitmapBDD(Int32.Parse(array_usuario[0].ToString()), "tbl_fotoUsuarios", "id_user = @id");
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
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

        public string fnGeneraTransaccionPrevia()
        {
            conexionBD cnn = new conexionBD();
            transacciones trans = new transacciones();
            if(trans.fnInsertaDatosTransaccion(txt_num_empleado.Text, id_entrevistador, DateTime.Now.ToString("MM/dd/yyyy"), "0", "0", "0", "0", "0", " "))
            {
                DataTable dtl = cnn.fnConsultaSentencia("SELECT id_det FROM tbl_transaccionDet WHERE id_user= " + txt_num_empleado.Text + " AND id_encuestador = " + id_entrevistador + " AND fiebre = 0 AND tos_estornudos = 0 AND malestar_gen = 0 AND dolor_cabeza = 0 AND dificultad_resp = 0 AND path_comprobante = ' '");
                foreach (DataRow item in dtl.Rows)
                {
                    object[] obj = item.ItemArray;
                    return obj[0].ToString();
                }
            }
            return string.Empty;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCuestionado.Text) || string.IsNullOrWhiteSpace(txtCuestionado.Text) || string.IsNullOrEmpty(txt_correo.Text) || string.IsNullOrWhiteSpace(txt_correo.Text))
            {
                cuadroMensaje mensaje = new cuadroMensaje();
                mensaje.fnCargarMensaje("Debes ingresar datos del empleado");
                mensaje.ShowDialog();
                return;
            }
            if (fnValidaTemperatura())
            {
                Form2 form2 = new Form2(txt_num_empleado.Text, id_entrevistador);
                this.id_transaccion = fnGeneraTransaccionPrevia();
                form2.id_transaccion = this.id_transaccion;
                fnScreenShot();
                form2.Show();
            }

            this.txt_num_empleado.Text = string.Empty;
            this.txtCuestionado.Text = string.Empty;
            this.txtGenero.Text = string.Empty;
            this.txtEdad.Text = string.Empty;
            this.txtPuesto.Text = string.Empty;
            this.txt_correo.Text = string.Empty;
            this.txt_temperatura.Text = string.Empty;
            this.pictureBox1.Image = null;
            return;
        }

        public bool fnValidaTemperatura()
        {
            if (string.IsNullOrEmpty(this.txt_temperatura.Text) || string.IsNullOrWhiteSpace(this.txt_temperatura.Text))
            {
                cuadroMensaje mensaje = new cuadroMensaje();
                mensaje.fnCargarMensaje("DEBES DE INGRESAR LA TEMPERATURA");
                mensaje.ShowDialog();
                return false;
            }
            else
            {
                float temp = float.Parse(this.txt_temperatura.Text, CultureInfo.InvariantCulture.NumberFormat);
                string temp_BDConfig = "37.5";
                float aux1 = float.Parse(temp_BDConfig, CultureInfo.InvariantCulture.NumberFormat);
                if (temp >= aux1)
                {
                    message msg = new message();
                    msg.ShowDialog();
                    return true;
                }
                return true;
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            filtroWithGrid filtro = new filtroWithGrid();
            filtro.ShowDialog();
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
            //INICIALIZAMOS LAS VARIABLES
            _Devices = new List<ORealPlay>();
            _Respuesta = new ORespuesta[10];
            int contador = 0;
            _Camaras = 0;
            _XLocation = 0;
            _YLocation = 0;
            //LOGEO DE CAMARAS
            ORealPlay[] _Data = new ORealPlay[10];
            parameters parametros = new parameters();
            this.datos_camara = parametros.fnRecuperaDatosCamara();
            foreach (DataRow item in this.datos_camara.Rows)
            {
                if (item.Field<string>("marca").Equals("DAHUA") || item.Field<string>("marca").Equals("HIKVISION"))
                {
                    _Data[contador] = new ORealPlay();
                    _Respuesta[contador] = new ORespuesta();
                    _Data[contador].IP = item.Field<string>("dir_ip");
                    _Data[contador].Puerto = ushort.Parse(item.Field<string>("dir_port"));
                    _Data[contador].Usuario = item.Field<string>("usuario");
                    _Data[contador].Password = item.Field<string>("contra");
                    if (item.Field<string>("marca").Equals("DAHUA"))
                    {
                        _Respuesta[contador] = _Data[contador].LoginDahua();
                        if (!_Respuesta[contador].Exitoso)
                        {
                            MessageBox.Show(_Respuesta[contador].Mensaje);
                        }
                        _Data[contador].Nombre = "Dahua " + _Data[contador].IP;
                        _Devices.Add(_Data[contador]);
                    }
                    else if (item.Field<string>("marca").Equals("HIKVISION"))
                    {
                        _Respuesta[contador] = _Data[contador].LoginHikvision();
                        if (!_Respuesta[contador].Exitoso)
                        {
                            MessageBox.Show(_Respuesta[contador].Mensaje);
                        }
                        _Data[contador].Nombre = "Hikvision " + _Data[contador].IP;
                        _Devices.Add(_Data[contador]);
                    }
                    contador++;
                }
            }
        }

        public void fnShowCameraHikVison(string panel, string marca, string dir_ip)
        {
            try
            {
                int aux = 0;
                _Respuesta = new ORespuesta[10];
                foreach (ORealPlay _Device in _Devices)
                {
                    if (_Device.Nombre.ToString().ToUpper().Trim().Equals((marca + " " + dir_ip).ToUpper().Trim()))
                    {
                        _Device.Canal = 1;
                        var picture = new PictureBox
                        {
                            Name = "canal" + _Camaras.ToString(),
                            Size = new Size(520, 320),
                            Location = new Point(_XLocation, _YLocation),
                        };
                        if (panel.Equals("ENTREVISTADOR"))
                        {
                            if (this.panel_webcam.Controls.Count > 0)
                                this.panel_webcam.Controls.RemoveAt(0);
                            panel_webcam.Controls.Add(picture);
                            _Device.Window = picture.Handle;
                        }
                        else if (panel.Equals("EMPLEADO"))
                        {
                            if (this.panel_camaraExt.Controls.Count > 0)
                                this.panel_camaraExt.Controls.RemoveAt(0);
                            panel_camaraExt.Controls.Add(picture);
                            _Device.Window = picture.Handle;
                        }
                        if (_Device.Nombre.ToUpper().Contains("DAHUA"))
                        {
                            _Respuesta[aux] = _Device.StartRealPlayDahua();
                            if (!_Respuesta[aux].Exitoso)
                            {
                                MessageBox.Show(_Respuesta[aux].Mensaje);
                            }
                        }
                        else if (_Device.Nombre.ToUpper().Contains("HIKVISION"))
                        {
                            _Respuesta[aux] = _Device.StartRealPlayHikvision();
                            if (!_Respuesta[aux].Exitoso)
                            {
                                MessageBox.Show(_Respuesta[aux].Mensaje);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void fnConectarWebCam_Luxand(string panel)
        {
            if (panel.Equals("EMPLEADO"))
            {
                //SE CARGA LA CAMARA EN UN FORM QUE SE CARGA E EL PANEL
                visorCamaraLuxand vcl = new visorCamaraLuxand(user_data);
                if (this.panel_camaraExt.Controls.Count > 0)
                    this.panel_camaraExt.Controls.RemoveAt(0);
                Form fh = vcl as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.panel_camaraExt.Controls.Add(fh);
                this.panel_camaraExt.Tag = fh;
                fh.Show();
            }
            else
            {
                //SE CARGA LA CAMARA EN UN FORM QUE SE CARGA E EL PANEL
                visorCamaraLuxand vcl = new visorCamaraLuxand(user_data);
                if (this.panel_webcam.Controls.Count > 0)
                    this.panel_webcam.Controls.RemoveAt(0);
                Form fh = vcl as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.panel_webcam.Controls.Add(fh);
                this.panel_webcam.Tag = fh;
                fh.Show();
            }
        }

        public void fnConectarWebCam(string panel)
        {
            _FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            _Webcam = new OWebcam();
            _XLocation_pnlWebCam = 0;
            _YLocation_pnlWebCam = 0;
            var picture = new PictureBox
            {
                Name = "canal" + _Camaras.ToString(),
                Size = new Size(520, 320),
                Location = new Point(_XLocation_pnlWebCam, _YLocation_pnlWebCam),
            };
            if (panel.Equals("ENTREVISTADOR"))
            {
                if (panel_webcam.Controls.Count > 0)
                {
                    panel_webcam.Controls.RemoveAt(0);
                }
                panel_webcam.Controls.Add(picture);
            }
            else panel_camaraExt.Controls.Add(picture);

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
            if (string.IsNullOrEmpty(txt_num_empleado.Text) || string.IsNullOrWhiteSpace(txt_num_empleado.Text))
            {
                this.txtEdad.Text = string.Empty;
                this.txtPuesto.Text = string.Empty;
                this.txtGenero.Text = string.Empty;
                this.txtCuestionado.Text = string.Empty;
                this.txt_correo.Text = string.Empty;
                this.txt_temperatura.Text = string.Empty;
            }
            fnFiltroPorEmpleado(txt_num_empleado.Text);
        }

        private void fnScreenShot()
        {
            try
            {
                Screen[] screens = Screen.AllScreens;
                foreach (Screen screen in screens)
                {
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
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    captureBitmap.Save(stream, ImageFormat.Jpeg);
                    /// Guardar la captura de pantalla en base de datos
                    conexionBD cnn = new conexionBD();
                    cnn.fnInsertaImagenBDD(stream.ToArray(), Int32.Parse(this.id_transaccion));
                }
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
            fnScreenShot();
            cuadroMensaje msg = new cuadroMensaje();
            msg.fnCargarMensaje("SE HA REALIZADO LA CAPTURA DE PANTALLA");
            msg.Show();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            // SE CARGA LA IMAGEN Y LOS DATOS DEL USUARIO DE LA BASE DE DATOS
            fncargaFotoUsuario(this.id_entrevistador);
            fnCargaDatosEntrevistador_login();
            fnInicializaCamaraHikVision();
            foreach (DataRow item in datos_camara.Rows)
            {
                if (item.Field<string>("marca").Equals("INTEGRATED CAMERA"))
                {
                    //fnConectarWebCam_Luxand(item.Field<string>("cuadro_camara"));
                    //fnConectarWebCam();
                }
                else
                {
                    fnShowCameraHikVison(item.Field<string>("cuadro_camara"), item.Field<string>("marca"), item.Field<string>("dir_ip"));
                }
                
            }
            this.flag = 1;
            width = this.Width;
            height = this.Height;
            this.WindowState = FormWindowState.Maximized;
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
                
                if (nuevo_usuario.fnIngresaUsuario(user_input.userName, user_input.userPaterno, user_input.userMaterno, user_input.userGenero, user_input.userEdad, user_input.userRol, user_input.userPuesto, user_input.userCorreo, "jorbee2020", user_input.userPathImagen))
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
            gridHistoricoComprobantes historico = new gridHistoricoComprobantes();
            historico.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fncargaFotoUsuario(this.id_entrevistador);
            fnCargaDatosEntrevistador_login();
            fnInicializaCamaraHikVision();
            foreach (DataRow item in datos_camara.Rows)
            {
                if (item.Field<string>("marca").Equals("INTEGRATED CAMERA"))
                {
                    //fnConectarWebCam_Luxand(item.Field<string>("cuadro_camara"));
                    //fnConectarWebCam();
                }
                else
                {
                    fnShowCameraHikVison(item.Field<string>("cuadro_camara"), item.Field<string>("marca"), item.Field<string>("dir_ip"));
                }
            }
            this.flag = 1;
        }

        private void txt_temperatura_TextChanged(object sender, EventArgs e)
        {
            if (txt_temperatura.Text.Length == 3)
            {
                txt_temperatura.Text = txt_temperatura.Text.Substring(0, 2) + "." + txt_temperatura.Text.Substring(2);
            }
        }

        private void txt_temperatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (TextBox)sender;
            // Si el carácter pulsado no es un carácter válido se anula
            e.Handled = !char.IsDigit(e.KeyChar) // No es dígito
                        && !char.IsControl(e.KeyChar) // No es carácter de control (backspace)
                        && (e.KeyChar != '.' // No es signo decimal o es la 1ª posición o ya hay un signo decimal
                            || textBox.SelectionStart == 0
                            || textBox.Text.Contains('.'));
        }

        private void cbbx_camara_empleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string camara_conectar = cbbx_camara_empleado.SelectedItem.ToString();
            if (flag != 0)
            {
                if (camara_conectar.Equals("INTEGRATED CAMERA"))
                {
                    fnConectarWebCam("ENTREVISTADOR");
                    return;
                }
                int aux = 0;
                _Respuesta = new ORespuesta[10];
                foreach (ORealPlay _Device in _Devices)
                {
                    if (_Device.Nombre.ToUpper().Trim().Equals(camara_conectar.ToUpper().Trim()))
                    {
                        _Device.Canal = 1;
                        var picture = new PictureBox
                        {
                            Name = "canal" + _Camaras.ToString(),
                            Size = new Size(520, 320),
                            Location = new Point(_XLocation, _YLocation),
                        };
                        if (this.panel_camaraExt.Controls.Count > 0)
                            this.panel_camaraExt.Controls.RemoveAt(0);
                        panel_camaraExt.Controls.Add(picture);
                        _Device.Window = picture.Handle;

                        if (_Device.Nombre.ToUpper().Contains("DAHUA"))
                        {
                            _Respuesta[aux] = _Device.StartRealPlayDahua();
                            if (!_Respuesta[aux].Exitoso)
                            {
                                MessageBox.Show(_Respuesta[aux].Mensaje);
                            }
                        }
                        else if (_Device.Nombre.ToUpper().Contains("HIKVISION"))
                        {
                            _Respuesta[aux] = _Device.StartRealPlayHikvision();
                            if (!_Respuesta[aux].Exitoso)
                            {
                                MessageBox.Show(_Respuesta[aux].Mensaje);
                            }
                        }
                    }
                }
            }
        }

        private void cbbx_camara_entrevistador_SelectedIndexChanged(object sender, EventArgs e)
        {
            string camara_conectar = cbbx_camara_entrevistador.SelectedItem.ToString();
            if (flag != 0)
            {
                if (camara_conectar.Trim().Equals("INTEGRATED CAMERA"))
                {
                    fnConectarWebCam("ENTREVISTADOR");
                    return;
                }
                int aux = 0;
                _Respuesta = new ORespuesta[10];
                foreach (ORealPlay _Device in _Devices)
                {
                    if (_Device.Nombre.ToUpper().Trim().Equals(camara_conectar.ToUpper().Trim()))
                    {
                        _Device.Canal = 1;
                        var picture = new PictureBox
                        {
                            Name = "canal" + _Camaras.ToString(),
                            Size = new Size(520, 320),
                            Location = new Point(_XLocation, _YLocation),
                        };
                        if (this.panel_webcam.Controls.Count > 0)
                            this.panel_webcam.Controls.RemoveAt(0);
                        panel_webcam.Controls.Add(picture);
                        _Device.Window = picture.Handle;

                        if (_Device.Nombre.ToUpper().Contains("DAHUA"))
                        {
                            _Respuesta[aux] = _Device.StartRealPlayDahua();
                            if (!_Respuesta[aux].Exitoso)
                            {
                                MessageBox.Show(_Respuesta[aux].Mensaje);
                            }
                        }
                        else if (_Device.Nombre.ToUpper().Contains("HIKVISION"))
                        {
                            _Respuesta[aux] = _Device.StartRealPlayHikvision();
                            if (!_Respuesta[aux].Exitoso)
                            {
                                MessageBox.Show(_Respuesta[aux].Mensaje);
                            }
                        }
                    }
                }
            }
        }

        
        private void Form1_Resize(object sender, EventArgs e)
        {
            if(flag != 0)
            {
                groupBox1.Location = new System.Drawing.Point(groupBox1.Location.X + ((this.Width - this.width)/2), groupBox1.Location.Y + ((this.Height - this.height)/2));
                groupBox2.Location = new System.Drawing.Point(groupBox2.Location.X + ((this.Width - this.width)/2), groupBox2.Location.Y + ((this.Height - this.height)/2));
                groupBox3.Location = new System.Drawing.Point(groupBox3.Location.X + ((this.Width - this.width)/2), groupBox3.Location.Y + ((this.Height - this.height)/2));
                groupBox4.Location = new System.Drawing.Point(groupBox4.Location.X + ((this.Width - this.width)/2), groupBox4.Location.Y + ((this.Height - this.height)/2));
            }
        }
    }
}
