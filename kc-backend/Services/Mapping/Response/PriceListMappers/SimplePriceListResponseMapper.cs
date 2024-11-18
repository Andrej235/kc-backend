using kc_backend.DTOs.Responses.PriceList;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Response.PriceListMappers
{
    public class SimplePriceListResponseMapper : IResponseMapper<PriceList, SimplePriceListResponseDTO>
    {
        public SimplePriceListResponseDTO Map(PriceList from) => new()
        {
            Id = from.Id,
            Name = from.Name,
        };
    }
}
