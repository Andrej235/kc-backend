using kc_backend.DTOs.Responses.Object;
using Object = kc_backend.Models.Object;

namespace kc_backend.Services.Mapping.Response.ObjectMappers
{
    public class SimpleObjectResponseMapper : IResponseMapper<Object, SimpleObjectResponseDTO>
    {
        public SimpleObjectResponseDTO Map(Models.Object from) => new()
        {
            Id = from.Id,
            Address = from.Address,
            LocalCode = from.LocalCode,
            OwnerId = from.OwnerId,
        };
    }
}
