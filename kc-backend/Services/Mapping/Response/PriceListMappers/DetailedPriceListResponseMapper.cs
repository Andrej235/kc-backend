using kc_backend.DTOs.Responses.PriceList;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Response.PriceListMappers
{
    public class DetailedPriceListResponseMapper(IResponseMapper<PriceListItem, PriceListItemResponseDTO> itemMapper) : IResponseMapper<PriceList, DetailedPriceListResponseDTO>
    {
        public DetailedPriceListResponseDTO Map(PriceList from) => new()
        {
            Id = from.Id,
            Name = from.Name,
            ItemCount = from.Items.Count, //Has items in memory since they are needed for the line below
            Items = from.Items.Select(itemMapper.Map)
        };
    }
}
