using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCMS.Core.Entities;

namespace MyCMS.Data.Configurations
{
    public class ContentRelationTypeConfiguration : IEntityTypeConfiguration<ContentRelationType>
    {
        public void Configure(EntityTypeBuilder<ContentRelationType> builder)
        {
            builder
                .Property(a => a.Name)
                .IsRequired();
        }
    }
}
