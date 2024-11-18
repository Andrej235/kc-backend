namespace kc_backend.DTOs.Responses.Warehouse
{
    public class DetailedWarehouseResponseDTO : SimpleWarehouseResponseDTO
    {
        public ICollection<WarehouseItemResponseDTO> Items { get; set; } = [];
    }
}
