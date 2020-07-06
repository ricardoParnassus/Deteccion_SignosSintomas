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
        public CrearComprobantePDF(string nombre, string fecha)
        {
            this.nombre_completo = nombre;
            this.fecha_aplicacion = fecha;
        }

        public void fnCrearArchivo()
        {
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\Phrankie Garcia\Documents\ArchivoPrueba\prueba.pdf", FileMode.Create));
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
            doc.Add(new Paragraph("NUMERO DE FOLIO: " + this.nombre_completo));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            #region table
            //// Creamos una tabla que contendrá el nombre, apellido y fecha 
            //// de nuestros visitante.
            //PdfPTable tblPrueba = new PdfPTable(3);
            //tblPrueba.WidthPercentage = 100;
            //// Configuramos el título de las columnas de la tabla
            //PdfPCell clFechaAplicacion = new PdfPCell(new Phrase("Fecha de aplicacion", _standardFont));
            //clFechaAplicacion.BorderWidth = 0;
            //clFechaAplicacion.BorderWidthBottom = 0.75f;
            //PdfPCell clNombre = new PdfPCell(new Phrase("Nombre Completo", _standardFont));
            //clNombre.BorderWidth = 0;
            //clNombre.BorderWidthBottom = 0.75f;
            //// Añadimos las celdas a la tabla
            //tblPrueba.AddCell(clFechaAplicacion);
            //tblPrueba.AddCell(clNombre);
            //// Llenamos la tabla con información
            //clFechaAplicacion = new PdfPCell(new Phrase(this.fecha_aplicacion, _standardFont));
            //clFechaAplicacion.BorderWidth = 0;
            //clNombre = new PdfPCell(new Phrase(this.nombre_completo, _standardFont));
            //clNombre.BorderWidth = 0;
            //// Añadimos las celdas a la tabla
            //tblPrueba.AddCell(clFechaAplicacion);
            //tblPrueba.AddCell(clNombre);
            //doc.Add(tblPrueba);
            #endregion

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
