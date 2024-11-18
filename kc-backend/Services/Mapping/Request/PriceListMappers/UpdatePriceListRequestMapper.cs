using kc_backend.DTOs.Requests.PriceList;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Request.PriceListMappers
{
    public class UpdatePriceListRequestMapper : IRequestMapper<UpdatePriceListRequestDTO, PriceList>
    {
        public PriceList Map(UpdatePriceListRequestDTO from) => new()
        {
            Id = from.Id,
            Name = from.Name,
        };
    }
}
