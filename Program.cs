using Microsoft.Identity.Web;
using TapChef_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using TapChef_Backend.Interfaces;
using TapChef_Backend.Repositories;
using TapChef_Backend.DTOs.Orders;

namespace TapChef_Backend
{
    public class Program
    {
        private static void AddContext<T>(WebApplicationBuilder builder, string connectionStringName) where T : DbContext
        {
            builder.Services.AddDbContext<T>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString(connectionStringName);
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = options.DefaultPolicy;
            });
            
            // DB Contexts
            AddContext<DataContext>(builder, "TapChefDB");

            // Repositories
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IVendorRepository, VendorRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}