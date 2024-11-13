namespace kc_backend.Models
{
    public class SalesInvoiceItem
    {
        public int ItemId { get; set; }
        public int WarehouseId { get; set; }
        public int SalesInvoiceId { get; set; }
        public int Quantity { get; set; }
    }
}
