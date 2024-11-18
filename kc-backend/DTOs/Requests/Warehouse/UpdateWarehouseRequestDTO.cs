namespace kc_backend.DTOs.Requests.Warehouse
{
    public class UpdateWarehouseRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
