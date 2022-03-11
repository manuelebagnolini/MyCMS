using Microsoft.EntityFrameworkCore;

namespace MyCMS.Data.DataProviders
{
    public class SQLiteDataProvider : IDataProvider
    {
        public void ConfigureContext(DbContextOptionsBuilder optionsBuilder)
        {
            var dbFilepath = @Directory.GetCurrentDirectory() + "/../MyCMS.Data/MyCMS.db";
            optionsBuilder.UseSqlite("Filename="+dbFilepath);
        }
    }
}
