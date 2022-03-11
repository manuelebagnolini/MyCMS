using Microsoft.EntityFrameworkCore;
using MyCMS.Core.Models;

namespace MyCMS.Data.Mappers
{
    public class ContentMapper : IMapper
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Content>()
                .HasKey(c => c.ContentID);

            modelBuilder
                .Entity<Content>()
                .Property(c => c.Title)
                .IsRequired();

            modelBuilder
                .Entity<Content>()
                .HasOne(c => c.ContentType)
                .WithMany()
                .IsRequired();

            modelBuilder
                .Entity<Content>()
                .HasOne(c => c.CreateUser)
                .WithMany()
                .IsRequired();

            modelBuilder
                .Entity<Content>()
                .Property(c => c.CreateDatetime)
                .IsRequired();

            modelBuilder
                .Entity<Content>()
                .HasOne(c => c.ModifyUser)
                .WithMany()
                .IsRequired();

            modelBuilder
                .Entity<Content>()
                .Property(c => c.ModifyDatetime)
                .IsRequired();
        }
    }
}
