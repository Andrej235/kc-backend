using kc_backend.DTOs.Responses.Item;
using kc_backend.DTOs.Responses.Warehouse;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Response.WarehouseMappers
{
    public class WarehouseItemResponseMapper(IResponseMapper<Item, SimpleItemResponseDTO> itemMapper) : IResponseMapper<WarehouseItem, WarehouseItemResponseDTO>
    {
        private readonly IResponseMapper<Item, SimpleItemResponseDTO> itemMapper = itemMapper;

        public WarehouseItemResponseDTO Map(WarehouseItem from) => new()
        {
            Item = itemMapper.Map(from.Item),
            Quantity = from.Quantity,
        };
    }
}
