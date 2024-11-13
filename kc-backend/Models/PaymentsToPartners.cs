using static kc_backend.Models.PartnerPayment;

namespace kc_backend.Models
{
    public class PaymentsToPartners
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public int TotalPaid { get; set; }
        public CurrencyType Currency { get; set; }
        public int PartnerId { get; set; }
    }
}
