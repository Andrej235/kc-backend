namespace kc_backend.Models
{
    public class AdvanceSalesInvoiceItem
    {
        public int ItemId { get; set; }
        public int WarehouseId { get; set; }
        public int AdvanceSalesInvoiceId { get; set; }
        public int Quantity { get; set; }
    }
}
