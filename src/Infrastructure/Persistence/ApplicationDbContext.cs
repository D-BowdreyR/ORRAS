using System.Reflection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ORRA.Application.Common.Interfaces;
using ORRA.Domain.Entities;
using ORRA.Domain.Common;

namespace ORRA.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IDateTime _dateTime;
        public ApplicationDbContext(DbContextOptions options,
         IDateTime dateTime) : base(options)
        {
            _dateTime = dateTime;
        }

        // All DbSets
        public DbSet<Person> People { get; set; }
        public DbSet<Modality> Modalities { get; set; }
        public DbSet<ImagingProcedure> ImagingProcedures { get; set; }

        // Save method

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            // build the save entity bahaviour here

            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                // switch between the entry's state
                switch (entry.State)
                {
                    case EntityState.Added:
                        // set user who created it

                        // set date created
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        // set user who modified it

                        // set date of modification
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }


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