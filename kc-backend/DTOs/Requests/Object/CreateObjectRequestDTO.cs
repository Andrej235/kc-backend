namespace kc_backend.DTOs.Requests.Object
{
    public class CreateObjectRequestDTO
    {
        public string Address { get; set; } = null!;
        public string LocalCode { get; set; } = null!;
        public int OwnerId { get; set; }
    }
}
