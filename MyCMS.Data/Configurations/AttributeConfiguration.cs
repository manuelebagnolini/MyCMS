using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyCMS.Data.Configurations
{
    public class AttributeConfiguration : IEntityTypeConfiguration<Core.Entities.Attribute>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Attribute> builder)
        {
            builder
                .Property(a => a.Name)
                .IsRequired();

            builder
                .HasIndex(a => a.Name)
                .IsUnique();

            builder
                .Property(a => a.AttributeType)
                .IsRequired();
        }
    }
}
