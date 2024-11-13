namespace kc_backend.Models
{
    public class SalesInvoices
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public DateTime TaxPaymentDate { get; set; }
        public int Status { get; set; }
        public int ObjectId { get; set; }
        public int PriceListId { get; set; }
    }
}
