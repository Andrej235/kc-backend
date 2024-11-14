namespace kc_backend.Models
{
    public class RequisitionItem
    {
        public int RequisitionId { get; set; }
        public Requisition Requisition { get; set; } = null!;

        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;

        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
