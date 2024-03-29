using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ORRAS.Infrastructure.Identity;
using ORRAS.Infrastructure.Persistence;

namespace ORRAS.WebUI
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host  = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var userManager = services.GetRequiredService<UserManager<AppUser>>();

                    // if we are not using the in-memory database, then we must be using an SQL provider, 
                    // so migrations are assumed to be supported
                    if (!context.Database.IsInMemory())
                    {
                        await context.Database.MigrateAsync();
                    }
                    // run the seed data method
                    await Seed.SeedDefaultUsersAsync(context, userManager);
                    await Seed.SeedSampleDataAsync(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();

                    logger.LogError(ex, "An error occurred while migrating or seeding the database");

                    throw;
                }
            }
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}