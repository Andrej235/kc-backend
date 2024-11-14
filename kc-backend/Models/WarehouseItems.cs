namespace kc_backend.Models
{
    public class WarehouseItems
    {
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;

        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
