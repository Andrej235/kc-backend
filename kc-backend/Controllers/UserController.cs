using kc_backend.Auth;
using kc_backend.DTOs.Requests.User;
using kc_backend.DTOs.Responses.AuthTokens;
using kc_backend.DTOs.Responses.User;
using kc_backend.Exceptions;
using kc_backend.Models;
using kc_backend.Services.Create;
using kc_backend.Services.Mapping.Request;
using kc_backend.Services.Mapping.Response;
using kc_backend.Services.Read;
using kc_backend.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace kc_backend.Controllers
{
    [ApiController]
    [Route("api/user")]
    public partial class UserController(ICreateService<User> createService,
                                        IReadSingleSelectedService<User> readSingleSelectedService,
                                        ITokenManager tokenManager,
                                        IRequestMapper<RegisterUserRequestDTO, User> registrationMapper,
                                        IResponseMapper<string, SimpleJWTResponseDTO> jwtResponseMapper) : ControllerBase
    {
        [GeneratedRegex(@"^[a-zA-Z0-9_.]{3,15}$")]
        private static partial Regex ValidUsernameRegex();

        private readonly HashSet<string> restrictedUsernames =
        [
            "admin",
        ];

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SimpleJWTResponseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<SimpleJWTResponseDTO> Register([FromBody] RegisterUserRequestDTO request)
        {
            if (!ValidUsernameRegex().IsMatch(request.Username))
                throw new InvalidRequestDTOException("Username is invalid");

            if (restrictedUsernames.Contains(request.Username.ToLower()))
                throw new InvalidRequestDTOException("Username is reserved");

            User mapped = registrationMapper.Map(request);
            User newUser = await createService.Add(mapped);

            string jwt = await tokenManager.GenerateJWTAndRefreshToken(newUser.Id, newUser.IsVerified, Response.Cookies);
            return jwtResponseMapper.Map(jwt);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SimpleJWTResponseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestDTO request)
        {
            if (request.Password.Length < 8)
                throw new InvalidRequestDTOException("Incorrect email or password");

            var user = (ValidUsernameRegex().IsMatch(request.Username)
                ? await readSingleSelectedService.Get(
                    x => new
                    {
                        x.Id,
                        x.IsVerified,
                        x.PasswordHash,
                        x.Salt
                    },
                    x => x.Username == request.Username)
                : null)
                ?? throw new InvalidLoginCredentialsException("Incorrect email or password");

            byte[] hash = request.Password.ToHash(user.Salt);
            if (!user.PasswordHash.SequenceEqual(hash))
                throw new InvalidLoginCredentialsException("Incorrect email or password");

            string jwt = await tokenManager.GenerateJWTAndRefreshToken(user.Id, user.IsVerified, Response.Cookies);
            return Created((string?)null, jwtResponseMapper.Map(jwt));
        }

        [Authorize(AuthenticationSchemes = "AllowExpired")]
        [HttpPost("refresh")]
        [ProducesResponseType(typeof(SimpleJWTResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Refresh()
        {
            if (User.Identity is not ClaimsIdentity claimsIdentity
                || claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value is not string userIdString
                || claimsIdentity.FindFirst(JwtRegisteredClaimNames.Jti)?.Value is not string jwtIdString
                || !Request.Cookies.TryGetValue("refreshToken", out string? refreshTokenString)
                || !Guid.TryParse(jwtIdString, out Guid jwtId)
                || !Guid.TryParse(userIdString, out Guid userId)
                || !Guid.TryParse(refreshTokenString, out Guid refreshToken))
                return Unauthorized("Invalid token");


            if (jwtId == default || userId == default || refreshToken == default)
                throw new UnauthorizedException();

            string newJwt = await tokenManager.RefreshJWT(jwtId, refreshToken, userId);
            return Created((string?)null, jwtResponseMapper.Map(newJwt));
        }

        [Authorize]
        [HttpDelete("logout")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Logout()
        {
            if (!Request.Cookies.TryGetValue("refreshToken", out string? refreshTokenString) || !Guid.TryParse(refreshTokenString, out Guid refreshToken))
                return Unauthorized("Invalid token");

            await tokenManager.InvalidateRefreshToken(refreshToken);
            return NoContent();
        }

        [Authorize]
        [HttpGet("basic")]
        [ProducesResponseType(typeof(UserResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetBasicInfo()
        {
            if (User.Identity is not ClaimsIdentity claimsIdentity
                || claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value is not string userIdString
                || !Guid.TryParse(userIdString, out Guid userId))
                return Unauthorized();

            if (userId == default)
                throw new UnauthorizedException();

            UserResponseDTO user = await readSingleSelectedService.Get(
                x => new UserResponseDTO
                {
                    Username = x.Username,
                },
                x => x.Id == userId)
                ?? throw new UnauthorizedException();

            return Ok(user);
        }
    }
}
