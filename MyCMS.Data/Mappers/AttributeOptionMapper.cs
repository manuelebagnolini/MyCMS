using Microsoft.EntityFrameworkCore;
using MyCMS.Core.Models;

namespace MyCMS.Data.Mappers
{
    public class AttributeOptionMapper : IMapper
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<AttributeOption>()
                .HasKey(o => o.AttributeOptionID);

            modelBuilder
                .Entity<AttributeOption>()
                .Property(o => o.Value)
                .IsRequired();

            modelBuilder
                .Entity<AttributeOption>()
                .HasOne(o => o.Attribute)
                .WithMany(a => a.Options)
                .IsRequired();
        }
    }
}
