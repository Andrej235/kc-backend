
using kc_backend.Auth;
using kc_backend.Data;
using kc_backend.DTOs.Requests.Item;
using kc_backend.DTOs.Requests.Object;
using kc_backend.DTOs.Requests.Partner;
using kc_backend.DTOs.Requests.PriceList;
using kc_backend.DTOs.Requests.User;
using kc_backend.DTOs.Requests.Warehouse;
using kc_backend.DTOs.Responses.AuthTokens;
using kc_backend.DTOs.Responses.Item;
using kc_backend.DTOs.Responses.Object;
using kc_backend.DTOs.Responses.Partner;
using kc_backend.DTOs.Responses.PriceList;
using kc_backend.DTOs.Responses.Warehouse;
using kc_backend.Exceptions;
using kc_backend.Models;
using kc_backend.Services.Create;
using kc_backend.Services.Delete;
using kc_backend.Services.Mapping.Request;
using kc_backend.Services.Mapping.Request.ItemMappers;
using kc_backend.Services.Mapping.Request.ObjectMappers;
using kc_backend.Services.Mapping.Request.PartnerMappers;
using kc_backend.Services.Mapping.Request.PriceListMappers;
using kc_backend.Services.Mapping.Request.UserMappers;
using kc_backend.Services.Mapping.Request.WarehouseMappers;
using kc_backend.Services.Mapping.Response;
using kc_backend.Services.Mapping.Response.ItemMappers;
using kc_backend.Services.Mapping.Response.ObjectMappers;
using kc_backend.Services.Mapping.Response.PartnerMappers;
using kc_backend.Services.Mapping.Response.PriceListMappers;
using kc_backend.Services.Mapping.Response.UserMappers;
using kc_backend.Services.Mapping.Response.WarehouseMappers;
using kc_backend.Services.Read;
using kc_backend.Services.Update;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Object = kc_backend.Models.Object;

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
            _ = builder.Services.AddAuthorization(x => x.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .RequireRole("admin")
                    .Build());
            #endregion

            #region Cors
            _ = builder.Services.AddCors(options => options.AddDefaultPolicy(builder => builder.SetIsOriginAllowed(origin => new Uri(origin).Host is "localhost")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()));
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
            _ = builder.Services.AddScoped<IReadSingleService<Partner>, ReadService<Partner>>();
            _ = builder.Services.AddScoped<IReadSingleSelectedService<Partner>, ReadService<Partner>>();
            _ = builder.Services.AddScoped<IReadRangeService<Partner>, ReadService<Partner>>();
            _ = builder.Services.AddScoped<IUpdateSingleService<Partner>, UpdateService<Partner>>();
            _ = builder.Services.AddScoped<IDeleteService<Partner>, DeleteService<Partner>>();
            _ = builder.Services.AddScoped<IRequestMapper<CreatePartnerRequestDTO, Partner>, CreatePartnerRequestMapper>();
            _ = builder.Services.AddScoped<IRequestMapper<UpdatePartnerRequestDTO, Partner>, UpdatePartnerRequestMapper>();
            _ = builder.Services.AddScoped<IResponseMapper<Partner, SimplePartnerResponseDTO>, SimplePartnerResponseMapper>();
            _ = builder.Services.AddScoped<IResponseMapper<Partner, DetailedPartnerResponseDTO>, DetailedPartnerResponseMapper>();
            #endregion

            #region Objects
            _ = builder.Services.AddScoped<ICreateService<Object>, CreateService<Object>>();
            _ = builder.Services.AddScoped<IReadSingleService<Object>, ReadService<Object>>();
            _ = builder.Services.AddScoped<IReadSingleSelectedService<Object>, ReadService<Object>>();
            _ = builder.Services.AddScoped<IReadRangeService<Object>, ReadService<Object>>();
            _ = builder.Services.AddScoped<IExecuteUpdateService<Object>, UpdateService<Object>>();
            _ = builder.Services.AddScoped<IDeleteService<Object>, DeleteService<Object>>();
            _ = builder.Services.AddScoped<IResponseMapper<Object, SimpleObjectResponseDTO>, SimpleObjectResponseMapper>();
            _ = builder.Services.AddScoped<IResponseMapper<Object, DetailedObjectResponseDTO>, DetailedObjectResponseMapper>();
            _ = builder.Services.AddScoped<IRequestMapper<CreateObjectRequestDTO, Object>, CreateObjectRequestMapper>();
            _ = builder.Services.AddScoped<IRequestMapper<UpdateObjectRequestDTO, Object>, UpdateObjectRequestMapper>();
            #endregion

            #region Items
            _ = builder.Services.AddScoped<ICreateService<Item>, CreateService<Item>>();
            _ = builder.Services.AddScoped<IReadSingleService<Item>, ReadService<Item>>();
            _ = builder.Services.AddScoped<IReadSingleSelectedService<Item>, ReadService<Item>>();
            _ = builder.Services.AddScoped<IReadRangeService<Item>, ReadService<Item>>();
            _ = builder.Services.AddScoped<IUpdateSingleService<Item>, UpdateService<Item>>();
            _ = builder.Services.AddScoped<IDeleteService<Item>, DeleteService<Item>>();
            _ = builder.Services.AddScoped<IResponseMapper<Item, SimpleItemResponseDTO>, SimpleItemResponseMapper>();
            _ = builder.Services.AddScoped<IRequestMapper<CreateItemRequestDTO, Item>, CreateItemRequestMapper>();
            _ = builder.Services.AddScoped<IRequestMapper<UpdateItemRequestDTO, Item>, UpdateItemRequestMapper>();
            #endregion

            #region Warehouses
            _ = builder.Services.AddScoped<ICreateService<Warehouse>, CreateService<Warehouse>>();
            _ = builder.Services.AddScoped<IReadSingleService<Warehouse>, ReadService<Warehouse>>();
            _ = builder.Services.AddScoped<IReadSingleSelectedService<Warehouse>, ReadService<Warehouse>>();
            _ = builder.Services.AddScoped<IReadRangeService<Warehouse>, ReadService<Warehouse>>();
            _ = builder.Services.AddScoped<IUpdateSingleService<Warehouse>, UpdateService<Warehouse>>();
            _ = builder.Services.AddScoped<IDeleteService<Warehouse>, DeleteService<Warehouse>>();
            _ = builder.Services.AddScoped<IResponseMapper<Warehouse, SimpleWarehouseResponseDTO>, SimpleWarehouseResponseMapper>();
            _ = builder.Services.AddScoped<IResponseMapper<Warehouse, DetailedWarehouseResponseDTO>, DetailedWarehouseResponseMapper>();
            _ = builder.Services.AddScoped<IRequestMapper<CreateWarehouseRequestDTO, Warehouse>, CreateWarehouseRequestMapper>();
            _ = builder.Services.AddScoped<IRequestMapper<UpdateWarehouseRequestDTO, Warehouse>, UpdateWarehouseRequestMapper>();

            //WarehouseItems
            _ = builder.Services.AddScoped<ICreateService<WarehouseItem>, CreateService<WarehouseItem>>();
            _ = builder.Services.AddScoped<IExecuteUpdateService<WarehouseItem>, UpdateService<WarehouseItem>>();
            _ = builder.Services.AddScoped<IDeleteService<WarehouseItem>, DeleteService<WarehouseItem>>();
            _ = builder.Services.AddScoped<IResponseMapper<WarehouseItem, WarehouseItemResponseDTO>, WarehouseItemResponseMapper>();
            #endregion

            #region PriceLists
            _ = builder.Services.AddScoped<ICreateService<PriceList>, CreateService<PriceList>>();
            _ = builder.Services.AddScoped<IReadSingleService<PriceList>, ReadService<PriceList>>();
            _ = builder.Services.AddScoped<IReadSingleSelectedService<PriceList>, ReadService<PriceList>>();
            _ = builder.Services.AddScoped<IReadRangeSelectedService<PriceList>, ReadService<PriceList>>();
            _ = builder.Services.AddScoped<IUpdateSingleService<PriceList>, UpdateService<PriceList>>();
            _ = builder.Services.AddScoped<IDeleteService<PriceList>, DeleteService<PriceList>>();
            _ = builder.Services.AddScoped<IResponseMapper<PriceList, SimplePriceListResponseDTO>, SimplePriceListResponseMapper>();
            _ = builder.Services.AddScoped<IResponseMapper<PriceList, DetailedPriceListResponseDTO>, DetailedPriceListResponseMapper>();
            _ = builder.Services.AddScoped<IRequestMapper<CreatePriceListRequestDTO, PriceList>, CreatePriceListRequestMapper>();
            _ = builder.Services.AddScoped<IRequestMapper<UpdatePriceListRequestDTO, PriceList>, UpdatePriceListRequestMapper>();

            //Items
            _ = builder.Services.AddScoped<ICreateService<PriceListItem>, CreateService<PriceListItem>>();
            _ = builder.Services.AddScoped<IExecuteUpdateService<PriceListItem>, UpdateService<PriceListItem>>();
            _ = builder.Services.AddScoped<IDeleteService<PriceListItem>, DeleteService<PriceListItem>>();
            _ = builder.Services.AddScoped<IResponseMapper<PriceListItem, PriceListItemResponseDTO>, PriceListItemResponseMapper>();
            #endregion

            WebApplication app = builder.Build();
            _ = app.UseExceptionHandler();

            if (app.Environment.IsDevelopment())
                _ = app.MapOpenApi();

            //_ = app.UseHttpsRedirection();
            _ = app.UseCors();

            _ = app.UseAuthentication();
            _ = app.UseAuthorization();

            _ = app.MapControllers().RequireAuthorization();
            app.Run();
        }
    }
}
