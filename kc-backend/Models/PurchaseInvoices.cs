namespace kc_backend.Models
{
    public class PurchaseInvoices
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public DateTime TaxPaymentDate { get; set; }
        public int NonTaxableAmount { get; set; }
        public string Note { get; set; }
        public int PartnerId { get; set; }
    }
}
