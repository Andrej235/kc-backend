using kc_backend.DTOs.Requests.User;
using kc_backend.Models;
using kc_backend.Utilities;

namespace kc_backend.Services.Mapping.Request
{
    public class RegisterUserRequestMapper : IRequestMapper<RegisterUserRequestDTO, User>
    {
        public User Map(RegisterUserRequestDTO from)
        {
            byte[] salt = HashingService.GenerateSalt();
            byte[] hash = from.Password.ToHash(salt);

            return new User
            {
                Username = from.Username,
                Salt = salt,
                PasswordHash = hash,
                IsVerified = false
            };
        }
    }
}
