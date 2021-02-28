using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ORRA.Application.Common.Interfaces;
using ORRA.Infrastructure.Services;

namespace ORRA.Infrastructure.Persistence.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            // build services here
            if (config.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ORRA_Db"));
            }
            else 
            {
                //TODO: Change MySql database provider
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlite(config.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddTransient<IDateTime, DateTimeService>();


            return services;
        }
    }
}