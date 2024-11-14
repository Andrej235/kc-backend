namespace kc_backend.Models
{
    public class AdvancePurchaseInvoiceItem
    {
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;

        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;

        public int AdvancePurchaseInvoiceId { get; set; }
        public AdvancePurchaseInvoice AdvancePurchaseInvoice { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
