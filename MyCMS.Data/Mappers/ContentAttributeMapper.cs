using Microsoft.EntityFrameworkCore;
using MyCMS.Core.Models;

namespace MyCMS.Data.Mappers
{
    public class ContentAttributeMapper
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ContentAttribute>()
                .HasKey(a => a.ContentAttributeID);

            modelBuilder
                .Entity<ContentAttribute>()
                .HasIndex(a => new { a.ContentID, a.AttributeID })
                .IsUnique();

            modelBuilder
                .Entity<ContentAttribute>()
                .HasOne(a => a.Content)
                .WithMany(c => c.Attributes)
                .IsRequired();

            modelBuilder
                .Entity<ContentAttribute>()
                .HasOne(a => a.Attribute)
                .WithMany()
                .IsRequired();
        }
    }
}
