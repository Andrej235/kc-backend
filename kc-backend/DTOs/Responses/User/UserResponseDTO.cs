namespace kc_backend.DTOs.Responses.User
{
    public class UserResponseDTO
    {
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string CompanyPosition { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
