using AbpDal.Data;
using AbpDal.Entities;
using AbpDal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AbpDal.Repositories
{
    public class PriceExperimentRepository : Repository<PriceExperimentData>, IPriceExperimentRepository
    {
        public PriceExperimentRepository(AbpExperimentDbContext experimentDbContext)
            : base(experimentDbContext)
        {
        }

        public override async Task AddAsync(PriceExperimentData entity)
        {
            FormattableString query = $"INSERT INTO dbo.PriceExperiments (Id, Price, ExperimentDate, DeviceId) VALUES ({entity.Id}, {entity.Price}, {entity.ExperimentDate}, {entity.DeviceId});";
            await ExperimentDbContext.Database.ExecuteSqlInterpolatedAsync(query);
        }
    }
}