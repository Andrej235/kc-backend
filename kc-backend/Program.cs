
using kc_backend.Auth;
using kc_backend.Data;
using kc_backend.DTOs.Requests.Partner;
using kc_backend.DTOs.Requests.User;
using kc_backend.DTOs.Responses.AuthTokens;
using kc_backend.Exceptions;
using kc_backend.Models;
using kc_backend.Services.Create;
using kc_backend.Services.Delete;
using kc_backend.Services.Mapping.Request;
using kc_backend.Services.Mapping.Request.PartnerMappers;
using kc_backend.Services.Mapping.Request.UserMappers;
using kc_backend.Services.Mapping.Response;
using kc_backend.Services.Mapping.Response.UserMappers;
using kc_backend.Services.Read;
using kc_backend.Services.Update;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace kc_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            ConfigurationManager configuration = builder.Configuration;
            _ = builder.Services.AddExceptionHandler<ExceptionHandlerMiddleware>();
            _ = builder.Services.AddProblemDetails();

            _ = builder.Services.AddSingleton(configuration);
            _ = builder.Services.AddDbContext<DataContext>(x =>
            {
                _ = x.UseSqlServer(configuration.GetConnectionString("SQLConnectionString"));
                _ = x.EnableSensitiveDataLogging(); //TODO-PROD: remove in production
            });

            #region JWT / Auth
            _ = builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = configuration["JWT:Audience"],
                ValidIssuer = configuration["JWT:Issuer"],
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!)),
                ClockSkew = TimeSpan.Zero,
            })
            .AddScheme<AuthenticationSchemeOptions, AllowExpiredAuthenticationHandler>("AllowExpired", (p) => { });

            _ = builder.Services.AddScoped<ITokenManager, TokenManager>();
            _ = builder.Services.AddAuthorization(x =>
            {
                x.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .RequireRole("admin")
                    .Build();
            });
            #endregion


            _ = builder.Services.AddControllers();
            _ = builder.Services.AddOpenApi();

            #region User
            _ = builder.Services.AddScoped<ICreateService<User>, CreateService<User>>();
            _ = builder.Services.AddScoped<IReadSingleSelectedService<User>, ReadService<User>>();
            _ = builder.Services.AddScoped<IRequestMapper<RegisterUserRequestDTO, User>, RegisterUserRequestMapper>();
            _ = builder.Services.AddScoped<IResponseMapper<string, SimpleJWTResponseDTO>, SimpleJWTResponseMapper>();

            _ = builder.Services.AddScoped<IReadSingleService<RefreshToken>, ReadService<RefreshToken>>();
            _ = builder.Services.AddScoped<ICreateService<RefreshToken>, CreateService<RefreshToken>>();
            _ = builder.Services.AddScoped<IUpdateSingleService<RefreshToken>, UpdateService<RefreshToken>>();
            _ = builder.Services.AddScoped<IDeleteService<RefreshToken>, DeleteService<RefreshToken>>();
            #endregion

            #region Partners
            _ = builder.Services.AddScoped<ICreateService<Partner>, CreateService<Partner>>();
            _ = builder.Services.AddScoped<IRequestMapper<CreatePartnerRequestDTO, Partner>, CreatePartnerRequestMapper>();
            #endregion

            WebApplication app = builder.Build();
            _ = app.UseExceptionHandler();

            if (app.Environment.IsDevelopment())
                _ = app.MapOpenApi();

            //_ = app.UseHttpsRedirection();
            //TODO: Add cors

            _ = app.UseAuthentication();
            _ = app.UseAuthorization();

            _ = app.MapControllers().RequireAuthorization();
            app.Run();
        }
    }
}
