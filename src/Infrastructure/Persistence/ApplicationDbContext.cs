using System.Reflection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ORRA.Application.Common.Interfaces;
using ORRA.Domain.Entities;

namespace ORRA.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext( DbContextOptions options) : base(options)
        {
        }

        // All DbSets
        public DbSet<Person> People { get; set; }
        public DbSet<Modality> Modalities { get; set; }
        public DbSet<ImagingProcedure> ImagingProcedures { get; set; }

        // Save method

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            // build the save entity bahaviour here

            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

        // override OnModelCreation to add entity configuration using fluentAPI
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

    }
}