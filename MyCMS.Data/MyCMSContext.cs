using Microsoft.EntityFrameworkCore;
using MyCMS.Core.Models;
using MyCMS.Data.DataProviders;
using MyCMS.Data.Mappers;

namespace MyCMS.Data
{
    public class MyCMSContext : DbContext
    {
        IDataProvider _dataProvider;

        public MyCMSContext(DbContextOptions<MyCMSContext> options, IDataProvider dataProvider) : base(options)
        {
            _dataProvider = dataProvider;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _dataProvider.ConfigureContext(optionsBuilder);
        }

        public DbSet<Core.Models.Attribute> Attributes { get; set; }
        public DbSet<AttributeOption> AttributeOptions { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentAttribute> ContentAttributes { get; set; }
        public DbSet<ContentRelation> ContentRelations { get; set; }
        public DbSet<ContentRelationType> ContentRelationTypes { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AttributeMapper().Map(modelBuilder);
            new AttributeOptionMapper().Map(modelBuilder);
            new ContentMapper().Map(modelBuilder);
            new ContentAttributeMapper().Map(modelBuilder);
            new ContentRelationMapper().Map(modelBuilder);
            new ContentRelationTypeMapper().Map(modelBuilder);
            new ContentTypeMapper().Map(modelBuilder);
            new UserMapper().Map(modelBuilder);
        }
    }
}