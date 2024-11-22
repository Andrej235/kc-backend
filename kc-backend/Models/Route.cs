namespace kc_backend.Models
{
    public class Route
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsComplete { get; set; }
        public string Description { get; set; } = null!;
        public float GoodsWeight { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;

        public ICollection<Requisition> Requisitions { get; set; } = [];
    }
}
