namespace kc_backend.Models
{
    public class AdvanceCustomerInvoice
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Description { get; set; }
        public int Demand { get; set; }
        public int PartnerId { get; set; }
        public int PriceListId { get; set; }
    }
}
