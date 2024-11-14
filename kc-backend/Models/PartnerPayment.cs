namespace kc_backend.Models
{
    public class PartnerPayment
    {
        public enum CurrencyType
        {
            RSD = 1,
            EUR = 2
        }

        public int Id { get; set; }
        public string BankName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public int TotalPaid { get; set; }
        public CurrencyType Currency { get; set; }

        public int PartnerId { get; set; }
        public Partner Partner { get; set; }
    }
}
