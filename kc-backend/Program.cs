
using kc_backend.Auth;
using kc_backend.Data;
using kc_backend.DTOs.Requests.User;
using kc_backend.DTOs.Responses.AuthTokens;
using kc_backend.Models;
using kc_backend.Services.Create;
using kc_backend.Services.Delete;
using kc_backend.Services.Mapping.Request;
using kc_backend.Services.Mapping.Response;
using kc_backend.Services.Read;
using kc_backend.Services.Update;
using Microsoft.EntityFrameworkCore;

namespace kc_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            ConfigurationManager configuration = builder.Configuration;
            _ = builder.Services.AddSingleton(configuration);
            _ = builder.Services.AddDbContext<DataContext>(x =>
            {
                _ = x.UseSqlServer(configuration.GetConnectionString("SQLConnectionString"));
                _ = x.EnableSensitiveDataLogging(); //TODO-PROD: remove in production
            });

            _ = builder.Services.AddControllers();
            _ = builder.Services.AddOpenApi();

            #region User
            _ = builder.Services.AddScoped<ICreateService<User>, CreateService<User>>();
            _ = builder.Services.AddScoped<IReadSingleSelectedService<User>, ReadService<User>>();
            _ = builder.Services.AddScoped<IRequestMapper<RegisterUserRequestDTO, User>, RegisterUserRequestMapper>();
            _ = builder.Services.AddScoped<IResponseMapper<string, SimpleJWTResponseDTO>, SimpleJWTResponseMapper>();

            _ = builder.Services.AddScoped<ITokenManager, TokenManager>();
            _ = builder.Services.AddScoped<IReadSingleService<RefreshToken>, ReadService<RefreshToken>>();
            _ = builder.Services.AddScoped<ICreateService<RefreshToken>, CreateService<RefreshToken>>();
            _ = builder.Services.AddScoped<IUpdateSingleService<RefreshToken>, UpdateService<RefreshToken>>();
            _ = builder.Services.AddScoped<IDeleteService<RefreshToken>, DeleteService<RefreshToken>>();
            #endregion

            WebApplication app = builder.Build();
            if (app.Environment.IsDevelopment())
                _ = app.MapOpenApi();

            //_ = app.UseHttpsRedirection();
            _ = app.UseAuthorization();
            _ = app.MapControllers();
            app.Run();
        }
    }
}
