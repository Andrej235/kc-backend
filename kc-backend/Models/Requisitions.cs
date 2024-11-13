namespace kc_backend.Models
{
    public class Requisitions
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public float Discount { get; set; }
        public int ObjectId { get; set; }
        public int PriceListId { get; set; }
    }
}
