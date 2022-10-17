using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyCMS.Data.Interfaces
{
    public interface IDataProvider
    {
        public void ConfigureContext(DbContextOptionsBuilder optionsBuilder, IConfiguration configuration);
    }
}
