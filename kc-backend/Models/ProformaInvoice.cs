namespace kc_backend.Models
{
    public class ProformaInvoice
    {
        public int Id { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public DateTime IssueDate { get; set; }
        public float Discount { get; set; }

        public int PartnerId { get; set; }
        public Partner Partner { get; set; } = null!;

        public int PriceListId { get; set; }
        public PriceList PriceList { get; set; } = null!;

        public ICollection<ProformaInvoiceItem> Items { get; set; } = null!;
    }
}
