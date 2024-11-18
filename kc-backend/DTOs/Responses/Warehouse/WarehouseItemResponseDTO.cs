using kc_backend.DTOs.Responses.Item;

namespace kc_backend.DTOs.Responses.Warehouse
{
    public class WarehouseItemResponseDTO
    {
        public SimpleItemResponseDTO Item { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
