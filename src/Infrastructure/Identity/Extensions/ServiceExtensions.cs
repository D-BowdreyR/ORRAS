
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ORRAS.Infrastructure.Persistence;

namespace ORRAS.Infrastructure.Identity.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection Add(this IServiceCollection services, IConfiguration config)
        {
            

            return services;
        }
    }
}