        using Microsoft.EntityFrameworkCore;
using BurgerManiaProject.Data;
namespace BurgerManiaProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<BurgerMgmtDbContext>(options =>
                   options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowedOrigins",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            var app = builder.Build();
            app.UseCors("AllowedOrigins");
            app.UseStaticFiles();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Burger API V1");
                    c.RoutePrefix = "swagger";
                });
            }
            app.UseAuthorization();
            app.MapFallbackToFile("index.html");
            app.MapGet("/home", () => Results.File("home.html"));
            app.MapControllers();

            app.Run();
        }
    }
}
