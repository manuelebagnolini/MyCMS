using Microsoft.EntityFrameworkCore;
using MyCMS.Core.Models;

namespace MyCMS.Data.Mappers
{
    public class ContentTypeMapper
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ContentType>()
                .HasKey(c => c.ContentTypeID);

            modelBuilder
                .Entity<ContentType>()
                .Property(c => c.Name)
                .IsRequired();
        }
    }
}
