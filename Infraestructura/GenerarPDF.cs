using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
namespace Infraestructura
{
    public class GenerarPDF
    {
        public void GuardarPDF(List<Persona> personas, string ruta)
        {
            FileStream file = new FileStream(ruta, FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.LEGAL, 40, 40, 40, 40);
            PdfWriter pdf =  PdfWriter.GetInstance(document, file);
            document.AddTitle("INFORME PULSACIONES");
            document.AddCreator("PULSACIONES PERSONAS");
            document.AddAuthor("KEVIN");
            document.Open();
            document.Add(new Paragraph("informe en pdf, aprendiendo pdf como en primaria"));
            document.Add(Llenartabla(personas));
            document.Close();
        }
        public PdfPTable Llenartabla (List<Persona> personas)
        {
            PdfPTable tabla = new PdfPTable(5);
            tabla.AddCell(new Paragraph ("Identificacion"));
            tabla.AddCell(new Paragraph("Nombre"));
            tabla.AddCell(new Paragraph("Edad"));
            tabla.AddCell(new Paragraph("Sexo"));
            tabla.AddCell(new Paragraph("Pulsacion"));
            foreach (var item in personas)
            {
                tabla.AddCell(item.Identificacion);
                tabla.AddCell(item.Nombre);
                tabla.AddCell($"{item.Edad}");
                tabla.AddCell(item.Sexo);
                tabla.AddCell($"{item.Pulsaciones}");


            }
            return tabla;
           
        }

    }
}
