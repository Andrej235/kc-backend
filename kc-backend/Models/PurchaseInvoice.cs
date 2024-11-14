namespace kc_backend.Models
{
    public class PurchaseInvoice
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public DateTime TaxPaymentDate { get; set; }
        public int NonTaxableAmount { get; set; }
        public string Note { get; set; } = null!;

        public int PartnerId { get; set; }
        public Partner Partner { get; set; } = null!;

        public ICollection<PurchaseInvoiceItem> Items { get; set; } = [];
    }
}
