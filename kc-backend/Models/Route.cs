namespace kc_backend.Models
{
    public class Route
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public float GoodsWeight { get; set; }
        public int VehicleId { get; set; }
    }
}
