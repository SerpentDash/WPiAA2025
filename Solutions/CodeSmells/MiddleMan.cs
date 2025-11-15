using System;

namespace CodeSmells
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }

    public class InvoiceRepository
    {
        public Invoice GetInvoiceById(int id)
        {
            Console.WriteLine($"Retrieving invoice {id}");
            return new Invoice { Id = id, Content = "Invoice content" };
        }

        public void SaveInvoice(Invoice invoice)
        {
            Console.WriteLine($"Saving invoice {invoice.Id}");
        }
    }
}
