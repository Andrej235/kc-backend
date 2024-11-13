namespace kc_backend.Models
{
    public class ProformaInvoiceItem
    {
        public int ItemId { get; set; }
        public int WarehouseId { get; set; }
        public int ProformaInvoiceId { get; set; }
        public int Quantity { get; set; }
    }
}
