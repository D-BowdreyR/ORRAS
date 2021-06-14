using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ORRAS.Application.Common.Interfaces;
using ORRAS.Infrastructure.Identity;
using ORRAS.Infrastructure.Services;

namespace ORRAS.Infrastructure.Persistence.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            // build services here
            
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("AzureSQL"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddTransient<IDateTime, DateTimeService>();          


            return services;
        }
    }
}