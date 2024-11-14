namespace kc_backend.Models
{
    public class PurchaseInvoiceItem
    {
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;

        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;

        public int PurchaseInvoiceId { get; set; }
        public PurchaseInvoice PurchaseInvoice { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
