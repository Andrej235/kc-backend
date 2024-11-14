namespace kc_backend.Models
{
    public class PurchaseInvoiceCompensation
    {
        public int InvoiceId { get; set; }
        public PurchaseInvoice PurchaseInvoice { get; set; } = null!;

        public int CompensationId { get; set; }
        public Compensation Compensation { get; set; } = null!;
    }
}
