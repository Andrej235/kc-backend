namespace kc_backend.Models
{
    public class SalesInvoice
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public DateTime TaxPaymentDate { get; set; }
        public int Status { get; set; }

        public int ObjectId { get; set; }
        public Object Object { get; set; } = null!;

        public int PriceListId { get; set; }
        public PriceList PriceList { get; set; } = null!;

        public ICollection<SalesInvoiceItem> Items { get; set; } = null!;
    }
}
