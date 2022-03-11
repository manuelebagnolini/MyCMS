using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyCMS.Data.Intefaces;

namespace MyCMS.Data.DataProviders
{
    public class SQLiteDataProvider : IDataProvider
    {
        public void ConfigureContext(DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
        {
            var connectionString = configuration["DBSettings:ConnectionString"];
            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
