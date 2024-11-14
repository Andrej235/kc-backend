namespace kc_backend.Models
{
    public class DispatchNoteItem
    {
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;

        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;

        public int DispatchNoteId { get; set; }
        public DispatchNote DispatchNote { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
