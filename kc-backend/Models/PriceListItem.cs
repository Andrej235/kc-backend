namespace kc_backend.Models
{
    public class PriceListItem
    {
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;

        public int PriceListId { get; set; }
        public PriceList PriceList { get; set; } = null!;

        public float Price { get; set; }
    }
}
