namespace kc_backend.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<WarehouseItem> Items { get; set; } = [];
    }
}
