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
        public ComprobanteVisor()
        {
            InitializeComponent();
        }

        private void ComprobanteVisor_Load(object sender, EventArgs e)
        {
            CrearComprobantePDF pdf = new CrearComprobantePDF("Ricardo Garcia Perez", "3 de Julio del 2020");
            pdf.fnCrearArchivo();
            pdf.fnConstruirCuerpoArchivo();
            web_browser_files.Navigate(@"C:\Users\Phrankie Garcia\Documents\ArchivoPrueba\prueba.pdf");
        }
    }
}
