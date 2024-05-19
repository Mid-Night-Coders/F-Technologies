using FTech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FTech.Infrastructure.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _appDbContext;

        public BaseRepository(AppDbContext appDbContext)
            => _appDbContext = appDbContext;

        public async ValueTask<TEntity> AddAsync(TEntity entity)
        {
            var entry = await _appDbContext.Set<TEntity>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _appDbContext.Set<TEntity>().AddRangeAsync(entities);
            await _appDbContext.SaveChangesAsync();
        }

        public async ValueTask<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await _appDbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);

        public async ValueTask<IEnumerable<TEntity>> GetAllAsync()
            => await _appDbContext.Set<TEntity>().ToListAsync();

        public async ValueTask<TEntity> GetByIdAsync(int id)
            => await _appDbContext.Set<TEntity>().FindAsync(id);

        public async ValueTask<TEntity> RemoveAsync(TEntity entity)
        {
            var entry = _appDbContext.Set<TEntity>().Remove(entity);
            await _appDbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _appDbContext.Set<TEntity>().RemoveRange(entities);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
