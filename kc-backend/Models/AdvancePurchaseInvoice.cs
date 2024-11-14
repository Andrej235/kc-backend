namespace kc_backend.Models
{
    public class AdvancePurchaseInvoice
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime TransactionDate { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;

        public int PriceListId { get; set; }
        public PriceList PriceList { get; set; } = null!;

        public ICollection<AdvancePurchaseInvoiceItem> Items { get; set; } = [];
    }
}
