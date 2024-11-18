using kc_backend.DTOs.Requests.Warehouse;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Request.WarehouseMappers
{
    public class CreateWarehouseRequestMapper : IRequestMapper<CreateWarehouseRequestDTO, Warehouse>
    {
        public Warehouse Map(CreateWarehouseRequestDTO from) => new()
        {
            Name = from.Name,
            Address = from.Address,
        };
    }
}
