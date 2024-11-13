namespace kc_backend.Models
{
    public class DispatchNoteItem
    {
        public int ItemId { get; set; }
        public int WarehouseId { get; set; }
        public int DispatchNoteId { get; set; }
        public int Quantity { get; set; }
    }
}
