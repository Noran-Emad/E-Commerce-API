using E_Commerce.DAL;
using E_Commerce.DAL.DBContext;
using E_Commerce.BL;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Text;
using static E_Commerce.API.Constant;
using Microsoft.IdentityModel.Tokens;
using E_Commerce.DAL.DBContext;
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

            

            builder.Services.AddDALServices(builder.Configuration);
            builder.Services.AddBLServices();

            #region Authentication

            builder.Services.AddAuthentication(options =>
            {
                // Configure used authentication 
                options.DefaultAuthenticateScheme = "MyDefault";
                options.DefaultChallengeScheme = "MyDefault"; // return 401 if not authenticated, 403 if authenticated but not authorized
            })
            // Define the authentication scheme
            .AddJwtBearer("MyDefault", options =>
            {
                var keyFromConfig = builder.Configuration.GetValue<string>(AppSettings.SecretKey)!;
                var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig);
                var key = new SymmetricSecurityKey(keyInBytes);

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = key
                };
            });

            #endregion

            #region Identity

            builder.Services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;

                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<EContext>();

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
