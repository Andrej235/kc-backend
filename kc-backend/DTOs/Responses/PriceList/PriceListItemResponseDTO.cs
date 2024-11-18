using kc_backend.DTOs.Responses.Item;

namespace kc_backend.DTOs.Responses.PriceList
{
    public class PriceListItemResponseDTO
    {
        public int PriceListId { get; set; }
        public float Price { get; set; }
        public SimpleItemResponseDTO Item { get; set; } = null!;
    }
}
