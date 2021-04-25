using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Npgsql;
using NUnit.Framework;
using ORRAS.Infrastructure.Persistence;
using ORRAS.WebUI;
using Respawn;


[SetUpFixture]
// A Class to hold all the testing setup and tear down utility methods
public class TestingUtility
{
    private static IConfigurationRoot _configuration;
    private static IServiceScopeFactory _scopeFactory;
    private static Checkpoint _checkpoint;

    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables();
        
        _configuration = builder.Build();

        var startup = new Startup(_configuration);

        var services = new ServiceCollection();

        services.AddSingleton(Mock.Of<IWebHostEnvironment>(opt =>
            opt.EnvironmentName == "Development" &&
            opt.ApplicationName == "ORRAS.WebUI"));

        services.AddLogging();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(_configuration.GetConnectionString("PostgreSQL")));

        startup.ConfigureServices(services);

        // TODO replace service registration for the interface of a currentuser service
        // remove existing registration

        // Register a MOCK of the userservice

        _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

        _checkpoint = new Checkpoint
        {
            TablesToIgnore = new[] { "__EFMigrationsHistory" },
            DbAdapter = DbAdapter.Postgres
        };

        EnsureDatabase();
    }

    private static void EnsureDatabase()
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

        context.Database.Migrate();
    }

    public static async Task ResetState()
    {
        var connection = _configuration.GetConnectionString("PostgreSQL");

        using (var conn = new NpgsqlConnection(connection))
        {
            await conn.OpenAsync();

            await _checkpoint.Reset(conn);
        }
    }

    // TODO: Implement a RunAsUserAsync method that will set the current user to a Test user account

    // TODO: Implemnet a helper method for this to Create the user in the database

    // TODO: Implement wrapper methods for an Admin User and a normal user

    public static async Task<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

        return await context.FindAsync<TEntity>(keyValues);
    }

    public static async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

        context.Add(entity);
        await context.SaveChangesAsync();
    }

    public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        using var scope = _scopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetService<ISender>();

        return await mediator.Send(request);
    }

    [OneTimeTearDown]
    public void RunAfterAnyTests()
    {
    }
}