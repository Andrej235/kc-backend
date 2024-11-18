using kc_backend.DTOs.Responses.Partner;

namespace kc_backend.DTOs.Responses.Object
{
    public class DetailedObjectResponseDTO : SimpleObjectResponseDTO
    {
        public SimplePartnerResponseDTO Owner { get; set; } = null!;
    }
}
