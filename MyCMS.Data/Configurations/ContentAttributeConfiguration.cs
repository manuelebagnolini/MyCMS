using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCMS.Core.Entities;

namespace MyCMS.Data.Configurations
{
    public class ContentAttributeConfiguration : IEntityTypeConfiguration<ContentAttribute>
    {
        public void Configure(EntityTypeBuilder<ContentAttribute> builder)
        {
            builder
                .HasIndex(a => new { a.ContentId, a.AttributeId })
                .IsUnique();

            builder
                .HasOne(a => a.Content)
                .WithMany(c => c.Attributes)
                .IsRequired();

            builder
                .HasOne(a => a.Attribute)
                .WithMany()
                .IsRequired();
        }
    }
}
