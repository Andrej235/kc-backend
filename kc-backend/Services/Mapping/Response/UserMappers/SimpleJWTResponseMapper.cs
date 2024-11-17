using kc_backend.DTOs.Responses.AuthTokens;

namespace kc_backend.Services.Mapping.Response.UserMappers
{
    public class SimpleJWTResponseMapper : IResponseMapper<string, SimpleJWTResponseDTO>
    {
        public SimpleJWTResponseDTO Map(string from) => new()
        {
            Token = from
        };
    }
}
