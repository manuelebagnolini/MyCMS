using Microsoft.EntityFrameworkCore;
using MyCMS.Core;
using MyCMS.Core.Interfaces;
using System.Linq.Expressions;

namespace MyCMS.Data
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MyCMSContext _context;

        public EntityRepository(MyCMSContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Table { get { return _context.Set<TEntity>(); } }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<int> CountAll()
        {
            return await _context.Set<TEntity>().CountAsync();
        }

        public async Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).CountAsync();
        }

        public async Task Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
