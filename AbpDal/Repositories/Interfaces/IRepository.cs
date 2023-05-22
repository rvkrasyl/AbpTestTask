using AbpDal.Entities.BaseEntities;

namespace AbpDal.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : EntityWithId
    {
        Task AddAsync(TEntity entity);
    }
}
