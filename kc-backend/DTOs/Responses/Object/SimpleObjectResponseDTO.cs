namespace kc_backend.DTOs.Responses.Object
{
    public class SimpleObjectResponseDTO
    {
        public int Id { get; set; }
        public string Address { get; set; } = null!;
        public string LocalCode { get; set; } = null!;
        public int OwnerId { get; set; }
    }
}
