using kc_backend.DTOs.Responses.Warehouse;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Response.WarehouseMappers
{
    public class SimpleWarehouseResponseMapper : IResponseMapper<Warehouse, SimpleWarehouseResponseDTO>
    {
        public SimpleWarehouseResponseDTO Map(Warehouse from) => new()
        {
            Id = from.Id,
            Name = from.Name,
            Address = from.Address
        };
    }
}
