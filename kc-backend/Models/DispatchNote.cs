namespace kc_backend.Models
{
    public class DispatchNote
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Status { get; set; }
        public float Discount { get; set; }
        public int ObjectId { get; set; }
        public int PriceListId { get; set; }
    }
}
