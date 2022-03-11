using Microsoft.EntityFrameworkCore;
using MyCMS.Core.Models;

namespace MyCMS.Data.Mappers
{
    public class ContentRelationMapper
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ContentRelation>()
                .HasKey(r => r.ContentRelationID);

            modelBuilder
                .Entity<ContentRelation>()
                .HasIndex(r => new { r.ContainerContentID, r.ReferredContentID, r.ContentRelationTypeID })
                .IsUnique();

            modelBuilder
                .Entity<ContentRelation>()
                .HasOne(r => r.ContainerContent)
                .WithMany(c => c.Contents)
                .HasForeignKey(r => r.ContainerContentID)
                .IsRequired();

            modelBuilder
                .Entity<ContentRelation>()
                .HasOne(r => r.ReferredContent)
                .WithMany(c => c.ReferencedBy)
                .HasForeignKey(r => r.ReferredContentID)
                .IsRequired();

            modelBuilder
                .Entity<ContentRelation>()
                .HasOne(r => r.ContentRelationType)
                .WithMany()
                .IsRequired();
        }
    }
}
