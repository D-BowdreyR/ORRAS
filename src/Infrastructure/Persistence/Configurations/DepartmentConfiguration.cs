using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ORRAS.Domain.Entities;

namespace ORRAS.Infrastructure.Persistence.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasOne<Company>(o => o.Company)
                .WithMany(d => d.Departments)
                .HasForeignKey(o => o.CompanyId);
            
        }
    }
}