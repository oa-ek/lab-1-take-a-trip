using TakeTripAsp.Core.Entity;

namespace TakeTripAsp.Repository
{
    public interface IRepository<TEntity, TKey>
         where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(TKey key);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
}
