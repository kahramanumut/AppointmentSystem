using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RandevuTakip.DAL.Concrete.EfCore;
using RandevuTakip.WebApp.Data;

namespace RandevuTakip
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Automatic Migration
            var host = BuildWebHost(args)
                        .MigrateDbContext<ApplicationDbContext>((_, __) => { })
                        .MigrateDbContext<AppointmentDbContext>((_, __) => { });

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    SeedData.Seed(scope).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                    throw;
                }
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                //.UseUrls("http://0.0.0.0:5000")
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .Build();
    }
}
