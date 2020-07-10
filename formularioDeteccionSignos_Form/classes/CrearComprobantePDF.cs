using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formularioDeteccionSignos_Form.classes
{
    class CrearComprobantePDF
    {
        Document doc = new Document(PageSize.LETTER);
        string nombre_completo = string.Empty;
        string fecha_aplicacion = string.Empty;
        string nombre_archivo = string.Empty;
        string numero_entrevistador = string.Empty;
        string numero_empleado = string.Empty;
        public CrearComprobantePDF(string nombre, string fecha, string codigo, string num_entrevistador)
        {
            this.nombre_completo = nombre;
            this.fecha_aplicacion = fecha;
            this.nombre_archivo = codigo;
            this.numero_entrevistador = num_entrevistador;
        }

        public void fnCrearArchivo()
        {
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"ArchivoPrueba\" + this.nombre_archivo + ".pdf", FileMode.Create));
            doc.AddTitle("DETECCION DE SINTOMAS");
            doc.AddCreator("GENERADO AUTOMATICAMENTE POR SISTEMA");
            // Abrimos el archivo
            //doc.Open();
        }

        public void fnConstruirCuerpoArchivo()
        {
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            doc.Open();
            doc.Add(new Paragraph("CUESTIONARIO DE DETECCION DE SIGNOS Y SINTOMAS"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("FECHA DE APLICACIÓN: " + this.fecha_aplicacion));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("NOMBRE DEL ENTREVISTADO: " + this.nombre_completo));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("NOMBRE DEL ENTREVISTADOR: " + this.nombre_completo));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("EN LOS ULTIMOS 7 DÍAS, HA TENIDO ALGUNO DE LOS SIGUIENTES SÍNTOMAS"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("SINTOMA****************************************SI**********NO"));
            doc.Add(new Paragraph("FIEBRE*****************************************SI**********NO"));
            doc.Add(new Paragraph("TOS********************************************SI**********NO"));
            doc.Add(new Paragraph("ESTORNUDOS*************************************SI**********NO"));
            doc.Add(new Paragraph("MALESTAR GENERAL*******************************SI**********NO"));
            doc.Add(new Paragraph("DOLOR DE CABEZA********************************SI**********NO"));
            doc.Add(new Paragraph("DIFICULTAD PARA RESPIRAR***********************SI**********NO"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("PRESENTA SÍNTOMAS******************************SI**********NO"));
            doc.Add(new Paragraph("NUMERO EMPLEADO QUE REALIZO EL FILTRO: " + this.numero_entrevistador));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("------------------------------CORTE AQUI----------------------------------");
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("FECHA DE APLICACIÓN: " + this.fecha_aplicacion));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("NOMBRE DEL ENTREVISTADO: " + this.nombre_completo));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("NUMERO DE FOLIO: " + this.nombre_completo));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("SI PRESENTA FIEBRE, ASOCIADO CON EL RESTO DE LOS SÍNTOMAS, ACUDA A LA" +
                                  "UNIDAD DE SALUD MAS CERCANA A SU DOMICILIO Y SIGA LAS INDICACIONES DEL " +
                                  "PERSONAL MEDICO."));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("SE RECOMIENDA PERMANECER EN CASA PARA EVITAR CONTAGIAR A OTRAS " +
                                  "PERSONAS Y TENER UNA PRONTA RECUPERACIÓN."));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("CONSERVE ESTE TALÓN QUE COMPRUEBA TU ASISTENCIA."));
            doc.Add(Chunk.NEWLINE);

            doc.Close();
            //writer.Close();
        }
    }
}
