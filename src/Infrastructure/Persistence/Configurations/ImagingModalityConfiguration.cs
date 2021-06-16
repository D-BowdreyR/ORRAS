using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ORRAS.Domain.Entities;

namespace ORRAS.Infrastructure.Persistence.Configurations
{
    public class ImagingModalityConfiguration : IEntityTypeConfiguration<ImagingModality>
    {
        public void Configure(EntityTypeBuilder<ImagingModality> builder)
        {
            builder.HasIndex(m => m.ModalityCode);

        }
    }
}