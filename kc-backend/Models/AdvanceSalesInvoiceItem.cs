namespace kc_backend.Models
{
    public class AdvanceSalesInvoiceItem
    {
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;

        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;

        public int AdvanceSalesInvoiceId { get; set; }
        public AdvanceSalesInvoice AdvanceSalesInvoice { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
