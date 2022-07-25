using System.Data;
using Microsoft.Data.SqlClient;
using SimpleChatApp.Infrastructure.Repositories;
using SimpleChatApp.Infrastructure.Repositories.Imp;
using SimpleChatApp.Models.Services;
using SimpleChatApp.Models.Services.Imp;

namespace SimpleChatApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services
                .AddScoped<IDbConnection>(
                    _ => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
                )
                .AddScoped<IChatLogRepository, ChatLogRepository>()
                .AddScoped<IChatService, ChatService>();

            builder.Configuration.GetConnectionString("DefaultConnection");

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Login}/{id?}"
            );

            app.Run();
        }
    }
}