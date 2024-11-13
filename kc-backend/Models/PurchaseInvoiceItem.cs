namespace kc_backend.Models
{
    public class PurchaseInvoiceItem
    {
        public int ItemId { get; set; }
        public int WarehouseId { get; set; }
        public int PurchaseInvoiceId { get; set; }
        public int Quantity { get; set; }
    }
}
