using Microsoft.EntityFrameworkCore;

namespace MyCMS.Data.Mappers
{
    public class AttributeMapper : IMapper
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Core.Models.Attribute>()
                .HasKey(a => a.AttributeID);

            modelBuilder
                .Entity<Core.Models.Attribute>()
                .Property(a => a.Name)
                .IsRequired();

            modelBuilder
                .Entity<Core.Models.Attribute>()
                .HasIndex(a => a.Name)
                .IsUnique();

            modelBuilder
                .Entity<Core.Models.Attribute>()
                .Property(a => a.AttributeType)
                .IsRequired();
        }
    }
}
