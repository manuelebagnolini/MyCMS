using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCMS.Core.Entities;

namespace MyCMS.Data.Configurations
{
    public class ContentTypeConfiguration : IEntityTypeConfiguration<ContentType>
    {
        public void Configure(EntityTypeBuilder<ContentType> builder)
        {
            builder
                .Property(c => c.Name)
                .IsRequired();
        }
    }
}
