namespace kc_backend.Models
{
    public class ProformaInvoice
    {
        public int Id { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public DateTime IssueDate { get; set; }
        public float Discount { get; set; }
        public int PartnerId { get; set; }
        public int PriceListId { get; set; }
    }
}
