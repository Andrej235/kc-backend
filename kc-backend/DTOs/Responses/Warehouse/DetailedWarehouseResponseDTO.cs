namespace kc_backend.DTOs.Responses.Warehouse
{
    public class DetailedWarehouseResponseDTO : SimpleWarehouseResponseDTO
    {
        public IEnumerable<WarehouseItemResponseDTO> Items { get; set; } = [];
    }
}
