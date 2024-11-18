using kc_backend.DTOs.Requests.Object;

namespace kc_backend.Services.Mapping.Request.ObjectMappers
{
    public class UpdateObjectRequestMapper : IRequestMapper<UpdateObjectRequestDTO, Models.Object>
    {
        public Models.Object Map(UpdateObjectRequestDTO from) => new()
        {
            Id = from.Id,
            Address = from.Address,
            LocalCode = from.LocalCode
        };
    }
}
