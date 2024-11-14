namespace kc_backend.Models
{
    public class Partner
    {
        public enum PartnerType
        {
            Customer = 1,
            Supplier = 2
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Phone2 { get; set; }
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string JMBG { get; set; } = null!;
        public bool TaxObliged { get; set; }
        public string TaxId { get; set; } = null!;//Pib
        public bool IsActive { get; set; }
        public string Email { get; set; } = null!;
        public string BankAccount { get; set; } = null!;
        public PartnerType Type { get; set; }
    }
}
