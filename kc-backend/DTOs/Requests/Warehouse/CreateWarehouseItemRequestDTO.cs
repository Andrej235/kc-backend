namespace kc_backend.DTOs.Requests.Warehouse
{
    public class CreateWarehouseItemRequestDTO
    {
        public int WarehouseId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
