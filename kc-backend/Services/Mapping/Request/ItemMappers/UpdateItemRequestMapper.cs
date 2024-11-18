using kc_backend.DTOs.Requests.Item;
using kc_backend.Models;

namespace kc_backend.Services.Mapping.Request.ItemMappers
{
    public class UpdateItemRequestMapper : IRequestMapper<UpdateItemRequestDTO, Item>
    {
        public Item Map(UpdateItemRequestDTO from) => new()
        {
            Id = from.Id,
            Name = from.Name,
            Barcode = from.Barcode,
            QuantityPerPackage = from.QuantityPerPackage,
        };
    }
}
