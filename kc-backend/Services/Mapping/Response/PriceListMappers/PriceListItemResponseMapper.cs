using kc_backend.DTOs.Responses.Item;
using kc_backend.DTOs.Responses.PriceList;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Response.PriceListMappers
{
    public class PriceListItemResponseMapper(IResponseMapper<Item, SimpleItemResponseDTO> itemMapper) : IResponseMapper<PriceListItem, PriceListItemResponseDTO>
    {
        private readonly IResponseMapper<Item, SimpleItemResponseDTO> itemMapper = itemMapper;

        public PriceListItemResponseDTO Map(PriceListItem from) => new()
        {
            Item = itemMapper.Map(from.Item),
            PriceListId = from.PriceListId,
            Price = from.Price,
        };
    }
}
