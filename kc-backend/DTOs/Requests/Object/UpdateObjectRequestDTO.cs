namespace kc_backend.DTOs.Requests.Object
{
    public class UpdateObjectRequestDTO
    {
        public int Id { get; set; }
        public string Address { get; set; } = null!;
        public string LocalCode { get; set; } = null!;
    }
}
