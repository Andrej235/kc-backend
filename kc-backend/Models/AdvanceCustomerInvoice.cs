namespace kc_backend.Models
{
    public class AdvanceCustomerInvoice
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Description { get; set; } = null!;
        public int Demand { get; set; }

        public int PartnerId { get; set; }
        public Partner Partner { get; set; } = null!;

        public int PriceListId { get; set; }
        public PriceList PriceList { get; set; } = null!;
    }
}
