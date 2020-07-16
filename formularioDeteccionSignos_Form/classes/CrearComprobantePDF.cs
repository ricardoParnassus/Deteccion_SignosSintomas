using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public int fiebre = 0;
        public int tos = 0;
        public int malestar = 0;
        public int dolor = 0;
        public int dificultad = 0;
        public CrearComprobantePDF(string nombre, string fecha, string codigo, string num_entrevistador, int fiebre, int tos, int malestar, int dolor, int dificultad)
        {
            this.nombre_completo = nombre;
            this.fecha_aplicacion = fecha;
            this.nombre_archivo = codigo;
            this.numero_entrevistador = num_entrevistador;
            this.fiebre = fiebre;
            this.tos = tos;
            this.malestar = malestar;
            this.dolor = dolor;
            this.dificultad = dificultad;
        }

        public string fnNombreEntrevistador(string id)
        {
            try
            {
                conexionBD cnn = new conexionBD();
                DataTable dtbl = cnn.fnConsultaSentencia("SELECT nombre, apellido_uno, apellido_dos FROM tbl_usuarios WHERE id_user="+id);
                foreach (DataRow item in dtbl.Rows)
                {
                    return item.Field<string>("nombre") + " " + item.Field<string>("apellido_uno") + " " + item.Field<string>("apellido_dos");
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public void fnCrearArchivo()
        {
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ArchivoPrueba\" + this.nombre_archivo + ".pdf", FileMode.Create));
            doc.AddTitle("DETECCION DE SINTOMAS");
            doc.AddCreator("GENERADO AUTOMATICAMENTE POR SISTEMA");
            // Abrimos el archivo
            //doc.Open();
        }

        public void fnConstruirCuerpoArchivo()
        {
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            doc.Open();
            Paragraph titulo = new Paragraph("CUESTIONARIO DE DETECCION DE SIGNOS Y SÍNTOMAS");
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("Fecha de aplicación: " + this.fecha_aplicacion));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("Nombre del entrevistado: " + this.nombre_completo));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("Nombre de la persona que realizo el filtro: " + fnNombreEntrevistador(this.numero_entrevistador)));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("En los ultimos 7 días, ha tenido alguno de los siguientes síntomas:"));
            doc.Add(Chunk.NEWLINE);

            PdfPTable table_sintomas = new PdfPTable(3);
            table_sintomas.AddCell("SÍNTOMA");
            table_sintomas.AddCell("SI");
            table_sintomas.AddCell("NO");
            //Fiebre
            table_sintomas.AddCell("FIEBRE");
            table_sintomas.AddCell((this.fiebre == 1) ? "X" : " ");
            table_sintomas.AddCell((this.fiebre == 0) ? "X" : " ");
            //Tos, Estornudos
            table_sintomas.AddCell("TOS, ESTORNUDOS");
            table_sintomas.AddCell((this.tos == 1) ? "X" : " ");
            table_sintomas.AddCell((this.tos == 0) ? "X" : " ");
            //Malestar General
            table_sintomas.AddCell("MALESTAR GENERAL");
            table_sintomas.AddCell((this.malestar == 1) ? "X" : " ");
            table_sintomas.AddCell((this.malestar == 0) ? "X" : " ");
            //Dolor de cabeza
            table_sintomas.AddCell("DOLOR DE CABEZA");
            table_sintomas.AddCell((this.dolor == 1) ? "X" : " ");
            table_sintomas.AddCell((this.dolor == 0) ? "X" : " ");
            //Dificultad para respirar
            table_sintomas.AddCell("DIFICULTAD PARA RESPIRAR");
            table_sintomas.AddCell((this.dificultad == 1) ? "X" : " ");
            table_sintomas.AddCell((this.dificultad == 0) ? "X" : " ");
            doc.Add(table_sintomas);
            doc.Add(Chunk.NEWLINE);

            Paragraph corte_aqui = new Paragraph(new Paragraph("--------------------------------------------------CORTE AQUI--------------------------------------------------"));
            corte_aqui.Alignment = Element.ALIGN_CENTER;
            doc.Add(corte_aqui);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("Fecha de aplicación: " + this.fecha_aplicacion));
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("Nombre del entrevistado: " + this.nombre_completo));
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
