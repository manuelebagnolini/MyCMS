using Microsoft.EntityFrameworkCore;
using MyCMS.Core.Models;

namespace MyCMS.Data.Mappers
{
    public class ContentRelationTypeMapper
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ContentRelationType>()
                .HasKey(a => a.ContentRelationTypeID);

            modelBuilder
                .Entity<ContentRelationType>()
                .Property(a => a.Name)
                .IsRequired();
        }
    }
}
