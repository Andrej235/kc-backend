using kc_backend.DTOs.Requests.PriceList;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Request.PriceListMappers
{
    public class CreatePriceListRequestMapper : IRequestMapper<CreatePriceListRequestDTO, PriceList>
    {
        public PriceList Map(CreatePriceListRequestDTO from) => new()
        {
            Name = from.Name,
            Items = []
        };
    }
}
