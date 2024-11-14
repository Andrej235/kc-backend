namespace kc_backend.Models
{
    public class ProformaInvoiceItem
    {
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;

        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;

        public int ProformaInvoiceId { get; set; }
        public ProformaInvoice ProformaInvoice { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
