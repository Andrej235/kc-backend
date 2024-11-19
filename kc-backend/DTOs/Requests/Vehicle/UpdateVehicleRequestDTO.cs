namespace kc_backend.DTOs.Requests.Vehicle
{
    public class UpdateVehicleRequestDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string PlateNumber { get; set; } = null!;
        public float LoadCapacity { get; set; }
    }
}
