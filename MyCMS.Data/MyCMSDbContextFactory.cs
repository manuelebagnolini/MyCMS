using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyCMS.Data.DataProviders;

namespace MyCMS.Data
{
    // Needed to run migrations on this project
    public class MyCMSDbContextFactory : IDesignTimeDbContextFactory<MyCMSContext>
    {
        public MyCMSContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../MyCMS.Web.API/appsettings.json")
                .Build();
            
            var builder = new DbContextOptionsBuilder<MyCMSContext>();
            
            var dataProviderTypeSetting = configuration["DBSettings:DataProviderType"];
            
            DataProviderType dataProviderType;
            Enum.TryParse(dataProviderTypeSetting, out dataProviderType);

            var dataProviderManager = new DataProviderManager();
            var dataProvider = dataProviderManager.GetDataProvider(dataProviderType);

            return new MyCMSContext(builder.Options, dataProvider, configuration);
        }
    }
}
