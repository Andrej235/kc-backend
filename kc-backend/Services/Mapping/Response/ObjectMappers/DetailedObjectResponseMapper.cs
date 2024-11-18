using kc_backend.DTOs.Responses.Object;
using kc_backend.DTOs.Responses.Partner;
using kc_backend.Models;
using Object = kc_backend.Models.Object;

namespace kc_backend.Services.Mapping.Response.ObjectMappers
{
    public class DetailedObjectResponseMapper(IResponseMapper<Partner, SimplePartnerResponseDTO> partnerMapper) : IResponseMapper<Object, DetailedObjectResponseDTO>
    {
        public DetailedObjectResponseDTO Map(Object from) => new()
        {
            Id = from.Id,
            Address = from.Address,
            LocalCode = from.LocalCode,
            OwnerId = from.OwnerId,
            Owner = partnerMapper.Map(from.Owner),
        };
    }
}
