using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCMS.Core.Entities;

namespace MyCMS.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.Username)
                .IsRequired();

            builder
                .Property(u => u.Name)
                .IsRequired();

            builder
                .Property(u => u.Surname)
                .IsRequired();

            builder
                .Property(u => u.Email)
                .IsRequired();
        }
    }
}
