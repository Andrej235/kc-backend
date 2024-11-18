using static kc_backend.Models.Partner;

namespace kc_backend.DTOs.Responses.Partner
{
    public class SimplePartnerResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public PartnerType Type { get; set; }
    }
}
