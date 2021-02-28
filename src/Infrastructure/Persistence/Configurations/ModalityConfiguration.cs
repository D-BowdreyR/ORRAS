using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ORRA.Domain.Entities;

namespace ORRA.Infrastructure.Persistence.Configurations
{
    public class ModalityConfiguration : IEntityTypeConfiguration<Modality>
    {
        public void Configure(EntityTypeBuilder<Modality> builder)
        {
            builder.HasIndex(m => m.ModalityCode);
        }
    }
}