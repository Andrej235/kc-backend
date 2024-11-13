namespace kc_backend.Models
{
    public class AdvancePurchaseInvoiceItem
    {
        public int ItemId { get; set; }
        public int WarehouseId { get; set; }
        public int AdvancePurchaseInvoiceId { get; set; }
        public int Quantity { get; set; }
    }
}
