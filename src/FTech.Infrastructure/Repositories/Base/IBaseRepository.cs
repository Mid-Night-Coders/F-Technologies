﻿using FTech.Domain.Entities.Chats;

using System.Linq.Expressions;

namespace FTech.Infrastructure.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(long id);
        ValueTask<TEntity> SelectByIdAsync(Guid guidId);
        ValueTask<IQueryable<TEntity>> GetAllAsync();
        ValueTask<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        ValueTask<TEntity> AddAsync(TEntity entity);
        ValueTask<TEntity> RemoveAsync(TEntity entity);
        ValueTask AddRangeAsync(IEnumerable<TEntity> entities);
        ValueTask RemoveRangeAsync(IEnumerable<TEntity> entities);
        ValueTask<int> SaveChangesAsync();
    }
}
