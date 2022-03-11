using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCMS.Core.Entities;

namespace MyCMS.Data.Configurations
{
    public class ContentRelationConfiguration : IEntityTypeConfiguration<ContentRelation>
    {
        public void Configure(EntityTypeBuilder<ContentRelation> builder)
        {
            builder
                .HasIndex(r => new { r.ContainerContentId, r.ReferredContentId, r.ContentRelationTypeId })
                .IsUnique();

            builder
                .HasOne(r => r.ContainerContent)
                .WithMany(c => c.Contents)
                .HasForeignKey(r => r.ContainerContentId)
                .IsRequired();

            builder
                .HasOne(r => r.ReferredContent)
                .WithMany(c => c.ReferencedBy)
                .HasForeignKey(r => r.ReferredContentId)
                .IsRequired();

            builder
                .HasOne(r => r.ContentRelationType)
                .WithMany()
                .IsRequired();
        }
    }
}
