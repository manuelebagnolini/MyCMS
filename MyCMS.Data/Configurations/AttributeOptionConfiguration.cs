using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCMS.Core.Entities;

namespace MyCMS.Data.Configurations
{
    public class AttributeOptionConfiguration : IEntityTypeConfiguration<AttributeOption>
    {
        public void Configure(EntityTypeBuilder<AttributeOption> builder)
        {
            builder
                .Property(o => o.Value)
                .IsRequired();

            builder
                .HasOne(o => o.Attribute)
                .WithMany(a => a.Options)
                .IsRequired();
        }
    }
}
