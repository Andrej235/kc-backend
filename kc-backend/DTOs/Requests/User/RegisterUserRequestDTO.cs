namespace kc_backend.DTOs.Requests.User
{
    public class RegisterUserRequestDTO
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string CompanyPosition { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
