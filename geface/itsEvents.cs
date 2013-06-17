using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Portal_GEFACE.geface
{
    public class itsEvents : PdfPageEventHelper
    {
        String _usuario;
        public String USUARIO
        {
            get { return _usuario;}
            set { _usuario = value;}
        }
        DateTime _creacion;
        public DateTime CREACION
        {
            get { return _creacion; }
            set { _creacion = value; }
        }
        String _hora;
        protected String HORA
        {
            get { return _hora; }
            set { _hora = value; }
        }
    

        //PdfContentByte cb;
        //PdfTemplate template;
        //public override void OnOpenDocument(PdfWriter writer, Document document)
        //{
        //    cb = writer.DirectContent;
        //    template = cb.CreateTemplate(50, 50);
        //}
        
        public override void OnStartPage(iTextSharp.text.pdf.PdfWriter writer ,iTextSharp.text.Document document )
        {
            base.OnStartPage(writer, document);
            #region ENCABEZADO
            //agregar imagen 
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(AppDomain.CurrentDomain.BaseDirectory.ToString() + "/img/cofiño_stahl.jpg");
            //jpg.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;
            jpg.ScalePercent(25f);

            //We are going to add two strings in header. Create separate Phrase object with font setting and string to be included
            Phrase p1Header = new Phrase("Facturación Electrónica", FontFactory.GetFont("verdana", 14));
            Phrase p2Header = new Phrase(DateTime.Now.ToLongDateString(), FontFactory.GetFont("verdana", 8));            

            //create iTextSharp.text Image object using local image path
            iTextSharp.text.Image imgPDF = iTextSharp.text.Image.GetInstance(HttpRuntime.AppDomainAppPath + "\\img\\cofiño_stahl.jpg");
            imgPDF.ScalePercent(25f);
            //Create PdfTable object
            PdfPTable pdfTab = new PdfPTable(3);
            //We will have to create separate cells to include image logo and 2 separate strings
            PdfPCell pdfCell1 = new PdfPCell(imgPDF);
            PdfPCell pdfCell2 = new PdfPCell(p1Header);
            PdfPCell pdfCell3 = new PdfPCell(p2Header);
            //set the alignment of all three cells and set border to 0
            pdfCell1.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell2.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell3.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell1.Border = 0;
            pdfCell2.Border = 0;
            pdfCell3.Border = 0;
            pdfCell2.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell3.VerticalAlignment = Element.ALIGN_BOTTOM;
            //establecer anchos
            float[] withsHead = new float[] { 14f, 49f, 21f };
            //add all three cells into PdfTable
            pdfTab.AddCell(pdfCell1);
            pdfTab.AddCell(pdfCell2);
            pdfTab.AddCell(pdfCell3);
            pdfTab.SetWidthPercentage(withsHead, document.PageSize);
            pdfTab.TotalWidth = document.PageSize.Width - 30;
            //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
            //first param is start row. -1 indicates there is no end row and all the rows to be included to write
            //Third and fourth param is x and y position to start writing
            pdfTab.WriteSelectedRows(0, -1, 30, document.PageSize.Height - 15, writer.DirectContent);
            //set pdfContent value
            PdfContentByte pdfContent = writer.DirectContent;
            //Move the pointer and draw line to separate header section from rest of page
            pdfContent.MoveTo(30, document.PageSize.Height - 45);
            pdfContent.LineTo(document.PageSize.Width - 40, document.PageSize.Height - 45);
            pdfContent.Stroke();         
            document.Add(new Phrase(Chunk.NEWLINE));
            document.Add(new Phrase(Chunk.NEWLINE));
            document.Add(new Phrase(Chunk.NEWLINE));
            #endregion           
        }
        //public override void OnEndPage(PdfWriter writer, Document document)
        //{
        //    base.OnEndPage(writer, document);

        //    int pageN = writer.PageNumber;
        //    String text = "Page " + pageN.ToString() + " of ";
        //    //float len = this.RunDateFont.BaseFont.GetWidthPoint(text, this.RunDateFont.Size);

        //    iTextSharp.text.Rectangle pageSize = document.PageSize;

        //    cb.SetRGBColorFill(100, 100, 100);

        //    cb.BeginText();
        //    cb.SetFontAndSize((BaseFont, Size);
        //    cb.SetTextMatrix(document.LeftMargin, pageSize.GetBottom(document.BottomMargin));
        //    cb.ShowText(text);

        //    cb.EndText();

        //    cb.AddTemplate(template, document.LeftMargin , pageSize.GetBottom(document.BottomMargin));
        //}

        //public override void OnCloseDocument(PdfWriter writer, Document document)
        //{
        //    base.OnCloseDocument(writer, document);

        //    template.BeginText();
        //    template.SetFontAndSize(BaseFont.COURIER,10.0);
        //    template.SetTextMatrix(0, 0);
        //    template.ShowText("" + (writer.PageNumber - 1));
        //    template.EndText();
        //}
        protected PdfTemplate total;
        protected BaseFont helv;
        private bool settingFont = false;

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            total = writer.DirectContent.CreateTemplate(100, 20);
            total.BoundingBox = new Rectangle(-20, -20, 150, 20);            
            helv = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.NOT_EMBEDDED);
            HORA = String.Format("{0}:{1}:{2}", CREACION.Hour.ToString(), CREACION.Minute.ToString(), CREACION.Second.ToString());
        }
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfContentByte cb = writer.DirectContent;
            cb.SaveState();            
            string text = String.Format("[{1} {2}] - Página {0} de ", writer.PageNumber, USUARIO, HORA );
            float textBase = document.Bottom ;
            float textSize = 8; //helv.GetWidthPoint(text, 12);
            cb.BeginText();
            cb.SetFontAndSize(helv, 8);
            //if ((writer.PageNumber % 2) == 1)
            //{
                cb.SetTextMatrix(document.Left-20, textBase);
                cb.ShowText(text);
                cb.EndText();
                cb.AddTemplate(total, document.Left , textBase);
            //}
            //else
            //{
            //    float adjust = helv.GetWidthPoint("0", 8);
            //    cb.SetTextMatrix(document.Right - textSize - adjust - text.Length - USUARIO.Length - HORA.Length-50, textBase);
            //    cb.ShowText(text);
            //    cb.EndText();
            //    cb.AddTemplate(total, document.Right, textBase);
            //}
            cb.RestoreState();


            PdfContentByte pdfContent = writer.DirectContent;
            //Move the pointer and draw line to separate header section from rest of page
            pdfContent.MoveTo(30, 30);
            pdfContent.LineTo(document.PageSize.Width - 40, 30);
            pdfContent.Stroke();
        }
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            total.BeginText();
            total.SetFontAndSize(helv, 8);
            total.SetTextMatrix(USUARIO.Length+HORA.Length+28+63, 0);
            int pageNumber = writer.PageNumber - 1;
            total.ShowText(Convert.ToString(pageNumber));
            total.EndText();
        }

    }
}
