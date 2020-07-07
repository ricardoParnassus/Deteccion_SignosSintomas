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
        String cameraName;
        bool needClose = false;
        // WinAPI procedure to release HBITMAP handles returned by FSDKCam.GrabFrame
        [DllImport("gdi32.dll")]
        static extern bool DeleteObject(IntPtr hObject);

        public visorCamaraLuxand()
        {
            InitializeComponent();
        }

        private void visorCamaraLuxand_Load(object sender, EventArgs e)
        {
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

            int cameraHandle = 0;
            int r = FSDKCam.OpenVideoCamera(ref cameraName, ref cameraHandle);
            if (r != FSDK.FSDKE_OK)
            {
                MessageBox.Show("Error opening the first camera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            int tracker = 0;
            FSDK.CreateTracker(ref tracker);
            int err = 0; // set realtime face detection parameters
            FSDK.SetTrackerMultipleParameters(tracker, "RecognizeFaces=false; HandleArbitraryRotations=false; DetermineFaceRotationAngle=false; InternalResizeWidth=100; FaceDetectionThreshold=5;", ref err);
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
                FSDK.FeedFrame(tracker, 0, image.ImageHandle, ref faceCount, out IDs, sizeof(long) * 256); // maximum 256 faces detected
                Array.Resize(ref IDs, (int)faceCount);
                Image frameImage = image.ToCLRImage();
                Graphics gr = Graphics.FromImage(frameImage);
                for (int i = 0; i < IDs.Length; ++i)
                {
                    FSDK.TFacePosition facePosition = new FSDK.TFacePosition();
                    FSDK.GetTrackerFacePosition(tracker, 0, IDs[i], ref facePosition);

                    int left = facePosition.xc - (int)(facePosition.w * 0.6);
                    int top = facePosition.yc - (int)(facePosition.w * 0.5);
                    gr.DrawRectangle(Pens.LightGreen, left, top, (int)(facePosition.w * 1.2), (int)(facePosition.w * 1.2));
                }
                // display current frame
                pictureBox1.Image = frameImage;
                GC.Collect(); // collect the garbage
                // make UI controls accessible
                Application.DoEvents();
            }
            FSDK.FreeTracker(tracker);
            FSDKCam.CloseVideoCamera(cameraHandle);
            FSDKCam.FinalizeCapturing();
        }

        private void INICIAR_Click(object sender, EventArgs e)
        {
            
        }
    }
}
