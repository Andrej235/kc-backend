namespace kc_backend.DTOs.Responses.Warehouse
{
    public class SimpleWarehouseResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
