using formularioDeteccionSignos_Form.classes;
using Luxand;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formularioDeteccionSignos_Form.resources.views
{
    public partial class visorCamaraLuxand : Form
    {

        // program states: whether we recognize faces, or user has clicked a face
        enum ProgramState { psRemember, psRecognize }
        ProgramState programState = ProgramState.psRecognize;

        String cameraName;
        object[] user_data;
        string[] registra_usuario;
        bool needClose = false;
        string userName;
        String TrackerMemoryFile = "tracker70.dat";
        int mouseX = 0;
        int mouseY = 0;
        string id_user = string.Empty;
        string nombre = string.Empty;
        string edad = string.Empty;
        string puesto = string.Empty;
        // WinAPI procedure to release HBITMAP handles returned by FSDKCam.GrabFrame
        [DllImport("gdi32.dll")]
        static extern bool DeleteObject(IntPtr hObject);

        public visorCamaraLuxand(object[] obj_user)
        {
            InitializeComponent();
            this.user_data = obj_user;
            this.id_user = obj_user[0].ToString();
            this.nombre = obj_user[2].ToString() + " " + obj_user[3].ToString() + " " + obj_user[4].ToString();
            this.edad = obj_user[6].ToString();
            this.puesto = obj_user[8].ToString();
        }

        private void visorCamaraLuxand_Load(object sender, EventArgs e)
        {
            #region LOGIN FORM LOAD
            if (FSDK.FSDKE_OK != FSDK.ActivateLibrary("mSZS6iUJqv9FC3B1C/jRhX3ASGvOLBkZ6vkufv7UbozMo3suOSsk0JeJjFLRpkWJVM8vfeJdvE2nbaAkr56KLoRA0aE6Cb5mYxaoIPhLufRgx0tHtH7mErwYclqix/DgYmXuPtV3V0BcVSS6h9ruSczSNkPcMVULXnbcmCqzuJ8="))
            {
                MessageBox.Show("Please run the License Key Wizard (Start - Luxand - FaceSDK - License Key Wizard)", "Error activating FaceSDK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            FSDK.InitializeLibrary();
            FSDKCam.InitializeCapturing();

            //FSDKCam.GetCameraListEx
            string[] cameraList;
            string[] cameras_rutas;
            int count;
            FSDKCam.GetCameraListEx(out cameraList, out cameras_rutas, out count);
            if (0 == count)
            {
                MessageBox.Show("Please attach a camera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            cameraName = cameraList[0]; // choose the first camera
            FSDKCam.VideoFormatInfo[] formatList;
            FSDKCam.GetVideoFormatList(ref cameraName, out formatList, out count);
            #endregion

            #region FaceTracking
            //int cameraHandle = 0;
            //int r = FSDKCam.OpenVideoCamera(ref cameraName, ref cameraHandle);
            //if (r != FSDK.FSDKE_OK)
            //{
            //    MessageBox.Show("Error opening the first camera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    Application.Exit();
            //}
            //int tracker = 0;
            //FSDK.CreateTracker(ref tracker);
            //int err = 0; // set realtime face detection parameters
            //FSDK.SetTrackerMultipleParameters(tracker, "RecognizeFaces=false; HandleArbitraryRotations=false; DetermineFaceRotationAngle=false; InternalResizeWidth=100; FaceDetectionThreshold=5;", ref err);
            //while (!needClose)
            //{
            //    Int32 imageHandle = 0;
            //    if (FSDK.FSDKE_OK != FSDKCam.GrabFrame(cameraHandle, ref imageHandle)) // grab the current frame from the camera
            //    {
            //        Application.DoEvents();
            //        continue;
            //    }
            //    FSDK.CImage image = new FSDK.CImage(imageHandle);
            //    long[] IDs;
            //    long faceCount = 0;
            //    FSDK.FeedFrame(tracker, 0, image.ImageHandle, ref faceCount, out IDs, sizeof(long) * 256); // maximum 256 faces detected
            //    Array.Resize(ref IDs, (int)faceCount);
            //    Image frameImage = image.ToCLRImage();
            //    Graphics gr = Graphics.FromImage(frameImage);
            //    for (int i = 0; i < IDs.Length; ++i)
            //    {
            //        FSDK.TFacePosition facePosition = new FSDK.TFacePosition();
            //        FSDK.GetTrackerFacePosition(tracker, 0, IDs[i], ref facePosition);

            //        int left = facePosition.xc - (int)(facePosition.w * 0.6);
            //        int top = facePosition.yc - (int)(facePosition.w * 0.5);
            //        gr.DrawRectangle(Pens.LightGreen, left, top, (int)(facePosition.w * 1.2), (int)(facePosition.w * 1.2));
            //    }
            //    // display current frame
            //    pictureBox1.Image = frameImage;
            //    GC.Collect(); // collect the garbage
            //    // make UI controls accessible
            //    Application.DoEvents();
            //}
            //FSDK.FreeTracker(tracker);
            //FSDKCam.CloseVideoCamera(cameraHandle);
            //FSDKCam.FinalizeCapturing();
            #endregion
        }

        private void INICIAR_Click_1(object sender, EventArgs e)
        {
            #region FaceTracking
            //int cameraHandle = 0;
            //int r = FSDKCam.OpenVideoCamera(ref cameraName, ref cameraHandle);
            //if (r != FSDK.FSDKE_OK)
            //{
            //    MessageBox.Show("Error opening the first camera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    Application.Exit();
            //}
            //int tracker = 0;
            //FSDK.CreateTracker(ref tracker);
            //int err = 0; // set realtime face detection parameters
            //FSDK.SetTrackerMultipleParameters(tracker, "RecognizeFaces=false; HandleArbitraryRotations=false; DetermineFaceRotationAngle=false; InternalResizeWidth=100; FaceDetectionThreshold=5;", ref err);
            //while (!needClose)
            //{
            //    Int32 imageHandle = 0;
            //    if (FSDK.FSDKE_OK != FSDKCam.GrabFrame(cameraHandle, ref imageHandle)) // grab the current frame from the camera
            //    {
            //        Application.DoEvents();
            //        continue;
            //    }
            //    FSDK.CImage image = new FSDK.CImage(imageHandle);
            //    long[] IDs;
            //    long faceCount = 0;
            //    FSDK.FeedFrame(tracker, 0, image.ImageHandle, ref faceCount, out IDs, sizeof(long) * 256); // maximum 256 faces detected
            //    Array.Resize(ref IDs, (int)faceCount);
            //    Image frameImage = image.ToCLRImage();
            //    Graphics gr = Graphics.FromImage(frameImage);
            //    for (int i = 0; i < IDs.Length; ++i)
            //    {
            //        FSDK.TFacePosition facePosition = new FSDK.TFacePosition();
            //        FSDK.GetTrackerFacePosition(tracker, 0, IDs[i], ref facePosition);

            //        int left = facePosition.xc - (int)(facePosition.w * 0.6);
            //        int top = facePosition.yc - (int)(facePosition.w * 0.5);
            //        gr.DrawRectangle(Pens.LightGreen, left, top, (int)(facePosition.w * 1.2), (int)(facePosition.w * 1.2));
            //    }
            //    // display current frame
            //    pictureBox1.Image = frameImage;
            //    GC.Collect(); // collect the garbage
            //    // make UI controls accessible
            //    Application.DoEvents();
            //}
            //FSDK.FreeTracker(tracker);
            //FSDKCam.CloseVideoCamera(cameraHandle);
            //FSDKCam.FinalizeCapturing();
            #endregion

            #region liveRecognition
            int cameraHandle = 0;
            int r = FSDKCam.OpenVideoCamera(ref cameraName, ref cameraHandle);
            if (r != FSDK.FSDKE_OK)
            {
                MessageBox.Show("Error opening the first camera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            int tracker = 0; 	// creating a Tracker
            if (FSDK.FSDKE_OK != FSDK.LoadTrackerMemoryFromFile(ref tracker, TrackerMemoryFile)) // try to load saved tracker state
                FSDK.CreateTracker(ref tracker); // if could not be loaded, create a new tracker
            int err = 0; // set realtime face detection parameters
            FSDK.SetTrackerMultipleParameters(tracker, "HandleArbitraryRotations=false; DetermineFaceRotationAngle=false; InternalResizeWidth=100; FaceDetectionThreshold=5;", ref err);
            while (!needClose)
            {
                Int32 imageHandle = 0;
                if (FSDK.FSDKE_OK != FSDKCam.GrabFrame(cameraHandle, ref imageHandle)) // grab the current frame from the camera
                {
                    Application.DoEvents();
                    continue;
                }
                FSDK.CImage image = new FSDK.CImage(imageHandle);
                long[] IDs;
                long faceCount = 0;
                FSDK.FeedFrame(tracker, 0, image.ImageHandle, ref faceCount, out IDs, sizeof(long) * 256); // maximum of 256 faces detected
                Array.Resize(ref IDs, (int)faceCount);
                // make UI controls accessible (to find if the user clicked on a face)
                Application.DoEvents();
                Image frameImage = image.ToCLRImage();
                Graphics gr = Graphics.FromImage(frameImage);
                for (int i = 0; i < IDs.Length; ++i)
                {
                    FSDK.TFacePosition facePosition = new FSDK.TFacePosition();
                    FSDK.GetTrackerFacePosition(tracker, 0, IDs[i], ref facePosition);
                    int left = facePosition.xc - (int)(facePosition.w * 0.6);
                    int top = facePosition.yc - (int)(facePosition.w * 0.5);
                    int w = (int)(facePosition.w * 1.2);
                    String name;
                    int res = FSDK.GetAllNames(tracker, IDs[i], out name, 65536); // maximum of 65536 characters
                    if (FSDK.FSDKE_OK == res && name.Length > 0)
                    { // draw name
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Center;
                        gr.DrawString(name, new System.Drawing.Font("Arial", 16),
                            new System.Drawing.SolidBrush(System.Drawing.Color.LightGreen),
                            facePosition.xc, top + w + 5, format);
                    }
                    Pen pen = Pens.LightGreen;
                    if (mouseX >= left && mouseX <= left + w && mouseY >= top && mouseY <= top + w)
                    {
                        pen = Pens.Blue;
                        if (ProgramState.psRemember == programState)
                        {
                            if (FSDK.FSDKE_OK == FSDK.LockID(tracker, IDs[i]))
                            {
                                // get the user name
                                InputName inputName = new InputName();
                                if (DialogResult.OK == inputName.ShowDialog())
                                {
                                    userName = inputName.userName;
                                    if (userName == null || userName.Length <= 0)
                                    {
                                        String s = "";
                                        FSDK.SetName(tracker, IDs[i], "");
                                        FSDK.PurgeID(tracker, IDs[i]);
                                    }
                                    else
                                    {
                                        FSDK.SetName(tracker, IDs[i], userName);
                                    }
                                    FSDK.UnlockID(tracker, IDs[i]);
                                }
                            }
                        }
                    }
                    gr.DrawRectangle(pen, left, top, w, w);
                }
                programState = ProgramState.psRecognize;
                // display current frame
                pictureBox1.Image = frameImage;
                GC.Collect(); // collect the garbage after the deletion
            }
            FSDK.SaveTrackerMemoryToFile(tracker, TrackerMemoryFile);
            FSDK.FreeTracker(tracker);
            FSDKCam.CloseVideoCamera(cameraHandle);
            FSDKCam.FinalizeCapturing();
            #endregion
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            programState = ProgramState.psRemember;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            mouseX = 0;
            mouseY = 0;
        }

        private void visorCamaraLuxand_Shown(object sender, EventArgs e)
        {
            #region liveRecognition
            int cameraHandle = 0;
            int r = FSDKCam.OpenVideoCamera(ref cameraName, ref cameraHandle);
            if (r != FSDK.FSDKE_OK)
            {
                MessageBox.Show("Error opening the first camera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            int tracker = 0; 	// creating a Tracker
            if (FSDK.FSDKE_OK != FSDK.LoadTrackerMemoryFromFile(ref tracker, TrackerMemoryFile)) // try to load saved tracker state
                FSDK.CreateTracker(ref tracker); // if could not be loaded, create a new tracker
            int err = 0; // set realtime face detection parameters
            FSDK.SetTrackerMultipleParameters(tracker, "HandleArbitraryRotations=false; DetermineFaceRotationAngle=false; InternalResizeWidth=100; FaceDetectionThreshold=5;", ref err);
            while (!needClose)
            {
                Int32 imageHandle = 0;
                if (FSDK.FSDKE_OK != FSDKCam.GrabFrame(cameraHandle, ref imageHandle)) // grab the current frame from the camera
                {
                    Application.DoEvents();
                    continue;
                }
                FSDK.CImage image = new FSDK.CImage(imageHandle);
                long[] IDs;
                long faceCount = 0;
                FSDK.FeedFrame(tracker, 0, image.ImageHandle, ref faceCount, out IDs, sizeof(long) * 256); // maximum of 256 faces detected
                Array.Resize(ref IDs, (int)faceCount);
                // make UI controls accessible (to find if the user clicked on a face)
                Application.DoEvents();
                Image frameImage = image.ToCLRImage();
                Graphics gr = Graphics.FromImage(frameImage);
                for (int i = 0; i < IDs.Length; ++i)
                {
                    FSDK.TFacePosition facePosition = new FSDK.TFacePosition();
                    FSDK.GetTrackerFacePosition(tracker, 0, IDs[i], ref facePosition);
                    int left = facePosition.xc - (int)(facePosition.w * 0.6);
                    int top = facePosition.yc - (int)(facePosition.w * 0.5);
                    int w = (int)(facePosition.w * 1.2);
                    String name = this.nombre + " Edad: " + this.edad + " Puesto: " + this.puesto;
                    //String name;
                    //String nombre;
                    int res = FSDK.GetAllNames(tracker, IDs[i], out nombre, 65536); // maximum of 65536 characters
                    if (FSDK.FSDKE_OK == res && name.Length > 0)
                    { // draw name
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Center;
                        gr.DrawString(name, new System.Drawing.Font("Arial", 16),
                            new System.Drawing.SolidBrush(System.Drawing.Color.LightGreen),
                            facePosition.xc, top + w + 5, format);
                    }
                    Pen pen = Pens.LightGreen;
                    if (mouseX >= left && mouseX <= left + w && mouseY >= top && mouseY <= top + w)
                    {
                        pen = Pens.Blue;
                        if (ProgramState.psRemember == programState)
                        {
                            if (FSDK.FSDKE_OK == FSDK.LockID(tracker, IDs[i]))
                            {
                                // get the user name
                                InputName inputName = new InputName();
                                if (DialogResult.OK == inputName.ShowDialog())
                                {
                                    userName = inputName.userName;
                                    /**********************************
                                     extraemos data del form input name
                                     **********************************/
                                    string nombre = inputName.userName;
                                    string a_paterno = inputName.userPaterno;
                                    string a_materno = inputName.userMaterno;
                                    string genero = inputName.userGenero;
                                    string edad = inputName.userEdad;
                                    string rol = inputName.userRol;
                                    string puesto = inputName.userPuesto;
                                    string correo = inputName.userCorreo;
                                    /*******************************************
                                     guardamos los datos en la tabla de usuarios
                                     *******************************************/
                                    fnRegistraUsuarioBD(nombre, a_paterno, a_materno, genero, edad, rol, puesto, correo);
                                    if (userName == null || userName.Length <= 0)
                                    {
                                        String s = "";
                                        FSDK.SetName(tracker, IDs[i], "");
                                        FSDK.PurgeID(tracker, IDs[i]);
                                    }
                                    else
                                    {
                                        FSDK.SetName(tracker, IDs[i], userName);
                                    }
                                    FSDK.UnlockID(tracker, IDs[i]);
                                }
                            }
                        }
                    }
                    gr.DrawRectangle(pen, left, top, w, w);
                }
                programState = ProgramState.psRecognize;
                // display current frame
                pictureBox1.Image = frameImage;
                GC.Collect(); // collect the garbage after the de
            }
            FSDK.SaveTrackerMemoryToFile(tracker, TrackerMemoryFile);
            FSDK.FreeTracker(tracker);
            FSDKCam.CloseVideoCamera(cameraHandle);
            FSDKCam.FinalizeCapturing();
            #endregion
        }

        private void visorCamaraLuxand_FormClosing(object sender, FormClosingEventArgs e)
        {
            needClose = true;
        }

        private void fnRegistraUsuarioBD(string nombre, string paterno, string materno, string genero, string edad, string rol, string puesto, string correo)
        {
            usuarioClass nuevo_usuario = new usuarioClass();
            cuadroMensaje mensaje = new cuadroMensaje();
            if (nuevo_usuario.fnIngresaUsuario(nombre, paterno, materno, genero, edad, rol, puesto, correo, "jorbee2020"))
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
}
