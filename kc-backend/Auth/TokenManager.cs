using kc_backend.Exceptions;
using kc_backend.Models;
using kc_backend.Services.Create;
using kc_backend.Services.Delete;
using kc_backend.Services.Read;
using kc_backend.Services.Update;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace kc_backend.Auth
{
    public class TokenManager(ConfigurationManager configuration,
                              IReadSingleService<RefreshToken> readSingleService,
                              ICreateService<RefreshToken> createService,
                              IUpdateSingleService<RefreshToken> updateService,
                              IDeleteService<RefreshToken> deleteService) : ITokenManager
    {
        private readonly ConfigurationManager configuration = configuration;
        private readonly IReadSingleService<RefreshToken> readSingleService = readSingleService;
        private readonly ICreateService<RefreshToken> createService = createService;
        private readonly IUpdateSingleService<RefreshToken> updateService = updateService;
        private readonly IDeleteService<RefreshToken> deleteService = deleteService;

        private (string jwt, Guid jwtId) CreateJWTAndId(Guid userId, bool isVerified)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]!);
            Guid jwtId = Guid.NewGuid();

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(
                    [
                        new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, jwtId.ToString()),
                        new Claim(ClaimTypes.Role, isVerified ? "admin" : "unverified")
                    ]
                ),

                Expires = DateTime.UtcNow.Add(TimeSpan.Parse(configuration["Jwt:TokenLifespan"]!)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"]
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return (tokenString, jwtId);
        }

        public async Task<string> GenerateJWTAndRefreshToken(Guid userId, bool isVerified, IResponseCookies cookies)
        {
            (string jwt, Guid jwtId) = CreateJWTAndId(userId, isVerified);

            RefreshToken refresh = new()
            {
                JwtId = jwtId,
                UserId = userId,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
            };

            _ = await createService.Add(refresh);

            CookieOptions cookieOptions = new()
            {
                HttpOnly = true,
                Secure = false, //TODO-PROD: Set to true in production
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7) //TODO-PROD: Set to something concrete in production
            };
            cookies.Append("refreshToken", refresh.Token.ToString(), cookieOptions);

            return jwt;
        }

        public async Task<string> RefreshJWT(Guid jwtId, Guid refreshToken, Guid userId)
        {
            RefreshToken? token = await readSingleService.Get(x => x.Token == refreshToken, x => x.Include(x => x.User));
            if (token is null || token.JwtId != jwtId || token.UserId != userId)
                throw new InvalidRequestDTOException("Invalid token");

            (string newJwt, Guid newJwtId) = CreateJWTAndId(token.User.Id, token.User.IsVerified);
            token.JwtId = newJwtId;
            await updateService.Update(token);

            return newJwt;
        }

        public Task InvalidateAllTokensForUser(Guid userId) => deleteService.Delete(x => x.UserId == userId);

        public Task InvalidateRefreshToken(Guid refreshToken) => deleteService.Delete(x => x.Token == refreshToken);
    }
}
