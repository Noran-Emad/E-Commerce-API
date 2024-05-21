using E_Commerce.DAL;
using E_Commerce.DAL.Context;
using E_Commerce.DAL.Repos;
using E_Commerce.DAL.Repos.OrdersRepo;
using E_Commerce.DAL.Repos.ProducrsRepo;
using Microsoft.EntityFrameworkCore;
using E_Commerce.BL;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata;
using System.Text;
namespace E_Commerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            const string AllowAllCorsPolicy = "AllowAll";

            // Add services to the container.


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("E_CommerceSystem");
            builder.Services.AddDbContext<DbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddDALServices(builder.Configuration);
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
