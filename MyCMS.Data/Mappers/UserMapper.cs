using Microsoft.EntityFrameworkCore;
using MyCMS.Core.Models;

namespace MyCMS.Data.Mappers
{
    public class UserMapper
    {
        public void Map(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasKey(u => u.UserID);

            modelBuilder
                .Entity<User>()
                .Property(u => u.Username)
                .IsRequired();

            modelBuilder
                .Entity<User>()
                .Property(u => u.Name)
                .IsRequired();

            modelBuilder
                .Entity<User>()
                .Property(u => u.Surname)
                .IsRequired();

            modelBuilder
                .Entity<User>()
                .Property(u => u.Email)
                .IsRequired();
        }
    }
}
