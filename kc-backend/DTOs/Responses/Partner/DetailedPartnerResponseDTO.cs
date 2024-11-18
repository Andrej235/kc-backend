using kc_backend.DTOs.Responses.Object;

namespace kc_backend.DTOs.Responses.Partner
{
    public class DetailedPartnerResponseDTO : SimplePartnerResponseDTO
    {
        public string Phone { get; set; } = null!;
        public string? Phone2 { get; set; }
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string JMBG { get; set; } = null!;
        public bool TaxObliged { get; set; }
        public string TaxId { get; set; } = null!; //Pib
        public string Email { get; set; } = null!;
        public string BankAccount { get; set; } = null!;
        public IEnumerable<SimpleObjectResponseDTO> Objects { get; set; } = null!;
    }
}
