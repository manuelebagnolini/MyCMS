using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCMS.Core.Entities;

namespace MyCMS.Data.Configurations
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder
                .Property(c => c.Title)
                .IsRequired();

            builder
                .HasOne(c => c.ContentType)
                .WithMany()
                .IsRequired();

            builder
                .HasOne(c => c.CreateUser)
                .WithMany()
                .IsRequired();

            builder
                .Property(c => c.CreateDatetime)
                .IsRequired();

            builder
                .HasOne(c => c.ModifyUser)
                .WithMany()
                .IsRequired();

            builder
                .Property(c => c.ModifyDatetime)
                .IsRequired();
        }
    }
}
