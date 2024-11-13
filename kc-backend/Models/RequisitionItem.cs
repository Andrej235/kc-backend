namespace kc_backend.Models
{
    public class RequisitionItem
    {
        public int RequisitionId { get; set; }
        public int ItemId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
    }
}
