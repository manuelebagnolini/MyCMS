using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyCMS.Data.Intefaces
{
    public interface IDataProvider
    {
        public void ConfigureContext(DbContextOptionsBuilder optionsBuilder, IConfiguration configuration);
    }
}
