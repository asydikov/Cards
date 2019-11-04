using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cards.Core.EF;
using Cards.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cards.Core.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly CardContext _context;
        protected readonly Guid _currentUserId;

        public RepositoryBase(CardContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            TEntity entity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            IEnumerable<TEntity> entities = await _context.Set<TEntity>().ToListAsync();
            return entities;
        }

        public virtual async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllOrderBy(Expression<Func<TEntity, int>> predicate)
        {
            return await _context.Set<TEntity>().OrderBy(predicate).ToListAsync();
        }

        public virtual async Task<Guid> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();

        }

        public virtual async Task DeleteEntityAsync(Guid id)
        {
            TEntity entity = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}