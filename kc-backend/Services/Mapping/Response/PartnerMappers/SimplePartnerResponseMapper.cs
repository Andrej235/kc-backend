using kc_backend.DTOs.Responses.Partner;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Response.PartnerMappers
{
    public class SimplePartnerResponseMapper : IResponseMapper<Partner, SimplePartnerResponseDTO>
    {
        public SimplePartnerResponseDTO Map(Partner from) => new()
        {
            Id = from.Id,
            Name = from.Name,
            IsActive = from.IsActive,
            Type = from.Type,
        };
    }
}
