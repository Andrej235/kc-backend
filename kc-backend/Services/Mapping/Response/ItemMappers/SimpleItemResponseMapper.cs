using kc_backend.DTOs.Responses.Item;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Response.ItemMappers
{
    public class SimpleItemResponseMapper : IResponseMapper<Item, SimpleItemResponseDTO>
    {
        public SimpleItemResponseDTO Map(Item from) => new()
        {
            Id = from.Id,
            Barcode = from.Barcode,
            Name = from.Name,
            QuantityPerPackage = from.QuantityPerPackage,
        };
    }
}
