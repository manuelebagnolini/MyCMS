using System.Linq.Expressions;

namespace MyCMS.Core.Interfaces
{
    public interface IEntityRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate);
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task SaveChanges();

        IQueryable<TEntity> Table { get; }
    }
}
