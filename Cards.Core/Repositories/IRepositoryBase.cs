using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cards.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cards.Core.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : EntityBase
    {
        Task<TEntity> GetAsync(Guid id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAllOrderBy(Expression<Func<TEntity, int>> predicate);

        Task<Guid> CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteEntityAsync(Guid id);

    }
}