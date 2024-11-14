namespace kc_backend.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string PlateNumber { get; set; } = null!;
        public float LoadCapacity { get; set; }
    }
}
