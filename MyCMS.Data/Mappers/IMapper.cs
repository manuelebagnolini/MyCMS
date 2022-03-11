using Microsoft.EntityFrameworkCore;

namespace MyCMS.Data.Mappers
{
    public interface IMapper
    {
        public void Map(ModelBuilder modelBuilder);
    }
}
