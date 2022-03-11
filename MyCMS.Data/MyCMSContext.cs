using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyCMS.Core.Entities;
using MyCMS.Data.Configurations;
using MyCMS.Data.Intefaces;

namespace MyCMS.Data
{
    public class MyCMSContext : DbContext
    {
        IDataProvider _dataProvider;
        IConfiguration _configuration;

        public MyCMSContext(DbContextOptions<MyCMSContext> options, IDataProvider dataProvider, IConfiguration configuration) : base(options)
        {
            _dataProvider = dataProvider;
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _dataProvider.ConfigureContext(optionsBuilder, _configuration);
        }

        public DbSet<Core.Entities.Attribute> Attributes { get; set; }
        public DbSet<AttributeOption> AttributeOptions { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentAttribute> ContentAttributes { get; set; }
        public DbSet<ContentRelation> ContentRelations { get; set; }
        public DbSet<ContentRelationType> ContentRelationTypes { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AttributeConfiguration().Configure(modelBuilder.Entity<Core.Entities.Attribute>());
            new AttributeOptionConfiguration().Configure(modelBuilder.Entity<AttributeOption>());
            new ContentConfiguration().Configure(modelBuilder.Entity<Content>());
            new ContentAttributeConfiguration().Configure(modelBuilder.Entity<ContentAttribute>());
            new ContentRelationConfiguration().Configure(modelBuilder.Entity<ContentRelation>());
            new ContentRelationTypeConfiguration().Configure(modelBuilder.Entity<ContentRelationType>());
            new ContentTypeConfiguration().Configure(modelBuilder.Entity<ContentType>());
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
        }
    }
}