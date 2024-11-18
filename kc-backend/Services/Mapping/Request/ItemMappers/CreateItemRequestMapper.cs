using kc_backend.DTOs.Requests.Item;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Request.ItemMappers
{
    public class CreateItemRequestMapper : IRequestMapper<CreateItemRequestDTO, Item>
    {
        public Item Map(CreateItemRequestDTO from) => new()
        {
            Name = from.Name,
            Barcode = from.Barcode,
            QuantityPerPackage = from.QuantityPerPackage,
        };
    }
}
