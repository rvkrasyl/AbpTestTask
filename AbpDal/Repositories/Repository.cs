using AbpDal.Data;
using AbpDal.Entities.BaseEntities;
using AbpDal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AbpDal.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : EntityWithId
    {
        public Repository(AbpExperimentDbContext experimentDbContext)
        {
            ExperimentDbContext = experimentDbContext;
            DbSet = experimentDbContext.Set<TEntity>();
        }

        protected AbpExperimentDbContext ExperimentDbContext { get; }

        protected DbSet<TEntity> DbSet { get; }

        public virtual async Task AddAsync(TEntity entity)
            => await DbSet.AddAsync(entity);
    }
}
