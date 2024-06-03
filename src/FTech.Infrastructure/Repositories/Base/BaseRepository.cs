using FTech.Domain.Entities.Chats;
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

        public async ValueTask<IQueryable<TEntity>> GetAllAsync()
            =>_appDbContext.Set<TEntity>().AsQueryable();
           
        public async ValueTask<TEntity> GetByIdAsync(long id)
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

        public ValueTask<TEntity> SelectByIdAsync(Guid guidId)
        {
            return _appDbContext.Set<TEntity>().FindAsync(guidId);
        }

        public async ValueTask<int> SaveChangesAsync()
            => await _appDbContext.SaveChangesAsync();
    }
}
