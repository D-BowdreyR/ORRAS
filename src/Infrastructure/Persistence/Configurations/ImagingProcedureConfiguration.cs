using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ORRA.Domain.Entities;

namespace ORRA.Infrastructure.Persistence.Configurations
{
    public class ImagingProcedureConfiguration : IEntityTypeConfiguration<ImagingProcedure>
    {
        public void Configure(EntityTypeBuilder<ImagingProcedure> builder)
        {
            builder.HasOne<Modality>(e => e.Modality)
             .WithMany(m => m.ImagingProcedures)
             .HasForeignKey(e => e.ModalityId);
             
        }
    }
}