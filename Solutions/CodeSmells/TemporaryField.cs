using System;

namespace CodeSmells
{
    public class PdfWriter : IDisposable
    {
        private readonly string _filename;

        public PdfWriter(string filename)
        {
            _filename = filename;
            Console.WriteLine($"Creating PDF file: {_filename}");
        }

        public void Write(string content)
        {
            Console.WriteLine($"Writing content to {_filename}: {content}");
        }

        public void Close()
        {
            Console.WriteLine($"Closing {_filename}");
        }

        public void Dispose()
        {
            Close();
        }
    }

    public class InvoiceGenerator
    {
        public void GenerateInvoice()
        {
            int invoiceNumber = 12345;
            using (var pdfWriter = new PdfWriter($"Invoice_{invoiceNumber}.pdf"))
            {
                pdfWriter.Write("Invoice Content");
            }
        }

        public void OtherMethod()
        {
        }
    }
}
