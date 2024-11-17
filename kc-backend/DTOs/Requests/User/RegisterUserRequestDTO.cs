namespace kc_backend.DTOs.Requests.User
{
    public class RegisterUserRequestDTO
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
