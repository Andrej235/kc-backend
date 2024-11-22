namespace kc_backend.Models
{
    public class Requisition
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public float Discount { get; set; }

        public int ObjectId { get; set; }
        public Object Object { get; set; } = null!;

        public int PriceListId { get; set; }
        public PriceList PriceList { get; set; } = null!;

        public ICollection<RequisitionItem> Items { get; set; } = null!;
        public ICollection<Route> UsedInRoutes { get; set; } = null!;
    }
}
