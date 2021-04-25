using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ORRAS.Domain.Entities;

namespace ORRAS.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        // describe all Dbsets (domain entities) that must be implemented by the ORM
        DbSet<ImagingModality> ImagingModalities { get; set; }
        DbSet<ImagingProcedure> ImagingProcedures { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Contact> Contacts { get; set; }
        
        // describe a SaveChangesAsync override method that must be implemented by the ORM
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}