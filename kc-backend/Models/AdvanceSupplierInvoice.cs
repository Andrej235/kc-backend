namespace kc_backend.Models
{
    public class AdvanceSupplierInvoice
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Description { get; set; } = null!;
        public int Demand { get; set; }

        public int PartnerId { get; set; }
        public Partner Partner { get; set; } = null!;
    }
}
