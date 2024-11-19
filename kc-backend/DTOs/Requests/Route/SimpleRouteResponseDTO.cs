namespace kc_backend.DTOs.Requests.Route
{
    public class SimpleRouteResponseDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; } = null!;
        public float GoodsWeight { get; set; }
        public int VehicleId { get; set; }
    }
}
