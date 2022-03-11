using Microsoft.EntityFrameworkCore;

namespace MyCMS.Data.DataProviders
{
    public interface IDataProvider
    {
        public void ConfigureContext(DbContextOptionsBuilder optionsBuilder);
    }
}
