using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ORRA.Domain.Entities;

namespace ORRA.Infrastructure.Persistence.Configurations
{
    public class ImagingModalityConfiguration : IEntityTypeConfiguration<ImagingModality>
    {
        public void Configure(EntityTypeBuilder<ImagingModality> builder)
        {
            builder.HasIndex(m => m.ModalityCode);

        }
    }
}