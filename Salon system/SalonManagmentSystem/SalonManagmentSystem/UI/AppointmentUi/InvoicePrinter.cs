using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SalonManagmentSystem.UI.AppointmentUi
{
    using System;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.IO;
    using System.Windows.Forms;
    using TheArtOfDevHtmlRenderer.Adapters;

    public class InvoicePrinter
    {
        private readonly PrintDocument printDocument = new PrintDocument();
        int Appid;
        string customerName;
        List<Tuple<string, int>> services;
        decimal disc = 0;

        public InvoicePrinter(int Appid, string customerName, List<Tuple<string, int>> services, decimal discount)
        {

            // Set up event handler for the PrintPage event
            printDocument.PrintPage += PrintDocument_PrintPage;
            this.Appid = Appid;
            this.customerName = customerName;
            this.services = services;
            this.disc = discount;
            

        }

        // Event handler for the PrintPage event
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Enhance Beauty Salon", new Font("Arial", 25, FontStyle.Bold), Brushes.Black, new Point(250, 10));

            e.Graphics.DrawString("Customer Invoice", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(290, 50));
            e.Graphics.DrawString("Appointment Details", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(20, 70));
            e.Graphics.DrawString("____________________________________________________________________________________________________________", new Font("Arial", 12), Brushes.Black, new Point(20, 100));
            e.Graphics.DrawString("Date: " + DateTime.Now.ToShortDateString() + "      " + "Time: " + DateTime.Now.ToShortTimeString(), new Font("Arial", 12), Brushes.Black, new Point(20, 120));
            e.Graphics.DrawString("Appointment Number: "  + Appid.ToString(), new Font("Arial", 12), Brushes.Black, new Point(20, 160));
            e.Graphics.DrawString("Customer Name: " + customerName, new Font("Arial", 12), Brushes.Black, new Point(20, 180));
            e.Graphics.DrawString("____________________________________________________________________________________________________________", new Font("Arial", 12), Brushes.Black, new Point(20, 200));
            e.Graphics.DrawString("Service Details", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(20, 240));
            e.Graphics.DrawString("Service Name", new Font("Arial", 13), Brushes.Black, new Point(20, 270));
            e.Graphics.DrawString("Price", new Font("Arial", 13), Brushes.Black, new Point(20 + 400, 270));
            int y = 320;
            int x = 20;
            int total = 0;
            foreach (Tuple<string, int> service in services)
            {
                e.Graphics.DrawString(service.Item1, new Font("Arial", 12), Brushes.Black, new Point(x, y));
                e.Graphics.DrawString(service.Item2.ToString(), new Font("Arial", 12), Brushes.Black, new Point(x + 400, y));
                total += service.Item2;
                y += 20;
            }
            decimal subTotal = total-((total * disc) / 100);
            e.Graphics.DrawString("____________________________________________________________________________________________________________", new Font("Arial", 12), Brushes.Black, new Point(20, y));
            e.Graphics.DrawString("Total: " + total.ToString(), new Font("Arial", 12), Brushes.Black, new Point(20 + 350, y+20));
            e.Graphics.DrawString("Discount: " + disc.ToString(), new Font("Arial", 12), Brushes.Black, new Point(20 + 350, y + 40));
            e.Graphics.DrawString("________________________", new Font("Arial", 12), Brushes.Black, new Point(20+330, y+60));
            e.Graphics.DrawString("Total: " + subTotal.ToString(), new Font("Arial", 12), Brushes.Black, new Point(20 + 350, y + 80));
            e.Graphics.DrawString("________________________", new Font("Arial", 12), Brushes.Black, new Point(20 + 330, y + 100));


        }

        // Method to print the invoice
        public void PrintInvoice()
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
        }

        // Method to preview the invoice
        public void PreviewInvoice()
        {
            using (PrintPreviewDialog previewDialog = new PrintPreviewDialog())
            {
                previewDialog.Document = printDocument;
                previewDialog.ShowDialog();
            }
        }

        public void SaveInvoiceAsPdf()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Save PDF File";
            saveFileDialog.FileName = $"{customerName} Invoice at {DateTime.Now.ToString("yyyy-MM-dd-HH=mm-ss")}.pdf";
            string filePath = saveFileDialog.FileName;
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // Add content to the PDF document
            document.Add(new Paragraph("                                    Enhance Beauty Salon", FontFactory.GetFont(FontFactory.HELVETICA, 18, iTextSharp.text.Font.BOLD)));
            document.Add(new Paragraph("Customer Invoice", FontFactory.GetFont(FontFactory.HELVETICA, 16, iTextSharp.text.Font.BOLD)));
            document.Add(new Paragraph("Appointment Details", FontFactory.GetFont(FontFactory.HELVETICA, 16, iTextSharp.text.Font.BOLD)));
            document.Add(new Paragraph("Date: " + DateTime.Now.ToShortDateString() + "      " + "Time: " + DateTime.Now.ToShortTimeString()));
            document.Add(new Paragraph("                                                         "));
            document.Add(new Paragraph("Appointment Number: " + Appid.ToString()));
            document.Add(new Paragraph("Customer Name: " + customerName));

            document.Add(new Paragraph("Service Details", FontFactory.GetFont(FontFactory.HELVETICA, 16, iTextSharp.text.Font.BOLD)));
            document.Add(new Paragraph("                                                         "));
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.AddCell("Service Name");
            table.AddCell("Price");

            foreach (Tuple<string, int> service in services)
            {
                table.AddCell(service.Item1);
                table.AddCell(service.Item2.ToString());
            }
            document.Add(table);

            // Calculate total
            int total = 0;
            foreach (var service in services)
            {
                total += service.Item2;
            }
            decimal subtotal = total - ((total * disc) / 100);
            document.Add(new Paragraph("                                                                       Total: " + total.ToString()));
            document.Add(new Paragraph("                                                                 Discount: " + disc.ToString()));
            document.Add(new Paragraph("                                                               ________________________"));
            document.Add(new Paragraph("                                                                Sub total: " + subtotal.ToString()));
            document.Add(new Paragraph("                                                               ________________________"));

            // Close the document
            document.Close();
        }
    }

}



