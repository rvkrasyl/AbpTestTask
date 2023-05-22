using AbpDal.Data;
using AbpDal.Entities;
using AbpDal.Repositories.Interfaces;

namespace AbpDal.Repositories
{
    public class PriceExperimentRepository : Repository<PriceExperimentData>, IPriceExperimentRepository
    {
        public PriceExperimentRepository(AbpExperimentDbContext experimentDbContext)
            : base(experimentDbContext)
        {
        }
    }
}
