using kc_backend.DTOs.Requests.Warehouse;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Request.WarehouseMappers
{
    public class UpdateWarehouseRequestMapper : IRequestMapper<UpdateWarehouseRequestDTO, Warehouse>
    {
        public Warehouse Map(UpdateWarehouseRequestDTO from) => new()
        {
            Id = from.Id,
            Name = from.Name,
            Address = from.Address,
        };
    }
}
