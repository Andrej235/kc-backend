namespace kc_backend.Models
{
    public class AdvanceSalesInvoice
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime TransactionDate { get; set; }

        public int ObjectId { get; set; }
        public Object Object { get; set; } = null!;

        public int PriceListId { get; set; }
        public PriceList PriceList { get; set; } = null!;
    }
}
