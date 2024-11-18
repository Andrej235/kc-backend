using kc_backend.DTOs.Requests.Object;

namespace kc_backend.Services.Mapping.Request.ObjectMappers
{
    public class CreateObjectRequestMapper : IRequestMapper<CreateObjectRequestDTO, Models.Object>
    {
        public Models.Object Map(CreateObjectRequestDTO from) => new()
        {
            Address = from.Address,
            LocalCode = from.LocalCode,
            OwnerId = from.OwnerId
        };
    }
}
