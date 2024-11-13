
namespace kc_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

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
