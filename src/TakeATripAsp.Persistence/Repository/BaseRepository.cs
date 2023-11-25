using Microsoft.EntityFrameworkCore;
using TakeTripAsp.Application.Repository;
using TakeTripAsp.Domain.Common;
using TakeTripAsp.Persistence.Context;

namespace TakeTripAsp.Persistence.Repository
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        protected TakeTripAspDbContext ctx;

        public BaseRepository(TakeTripAspDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var newEntity = await ctx.Set<TEntity>().AddAsync(entity);
            await SaveAsync();

            return newEntity.Entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            ctx.Set<TEntity>().Remove(entity);
            await SaveAsync();
        }

        public async Task<TEntity> GetAsync(TKey key)
        {
            return await ctx.Set<TEntity>().FindAsync(key);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await ctx.Set<TEntity>().ToListAsync();
        }

        public async Task SaveAsync()
        {
            await ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            ctx.Set<TEntity>().Update(entity);
            await SaveAsync();
        }
    }
}
