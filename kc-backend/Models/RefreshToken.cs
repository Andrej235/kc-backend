namespace kc_backend.Models
{
    public class RefreshToken
    {
        public Guid Token { get; set; }
        public Guid JwtId { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
