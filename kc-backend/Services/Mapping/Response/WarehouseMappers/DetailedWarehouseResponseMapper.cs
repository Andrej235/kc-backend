using kc_backend.DTOs.Responses.Warehouse;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Response.WarehouseMappers
{
    public class DetailedWarehouseResponseMapper(IResponseMapper<WarehouseItem, WarehouseItemResponseDTO> itemMapper) : IResponseMapper<Warehouse, DetailedWarehouseResponseDTO>
    {
        private readonly IResponseMapper<WarehouseItem, WarehouseItemResponseDTO> itemMapper = itemMapper;

        public DetailedWarehouseResponseDTO Map(Warehouse from) => new()
        {
            Id = from.Id,
            Address = from.Address,
            Name = from.Name,
            Items = from.Items.Select(itemMapper.Map),
        };
    }
}
