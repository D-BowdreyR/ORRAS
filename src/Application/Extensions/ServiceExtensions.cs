using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ORRA.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // TODO: build services here

            // add MediaR
            services.AddMediatR(Assembly.GetExecutingAssembly());
            // add AutoMapper


            return services;
        }
    }
}