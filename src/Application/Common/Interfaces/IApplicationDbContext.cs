using System;
using System.Threading;
using System.Threading.Tasks;

namespace ORRA.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        // describe all Dbsets (domain entities) that must be implemented by the ORM
        

        
        // describe a SaveChangesAsync override method that must be implemented by the ORM
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}