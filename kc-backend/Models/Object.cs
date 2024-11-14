namespace kc_backend.Models
{
    public class Object
    {
        public int Id { get; set; }
        public string Address { get; set; } = null!;
        public string LocalCode { get; set; } = null!;

        public int OwnerId { get; set; }
        public Partner Owner { get; set; } = null!;
    }
}
