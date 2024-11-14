
using kc_backend.Data;
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
