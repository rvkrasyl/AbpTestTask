using AbpDal.Data;
using AbpDal.Entities;
using AbpDal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AbpDal.Repositories
{
    public class DeviceRepository : Repository<Device>, IDeviceRepository
    {
        public DeviceRepository(AbpExperimentDbContext experimentDbContext)
            : base(experimentDbContext)
        {
        }

        public async Task<Device> GetByTokenWithColorExperimentAsync(string deviceToken)
            => await DbSet.FromSqlInterpolated($"SELECT * FROM dbo.Devices WHERE DeviceToken = {deviceToken}")
                .Include(d => d.ButtonColorExperimentData)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        public async Task<Device> GetByTokenWithPriceExperimentAsync(string deviceToken)
            => await DbSet.FromSqlInterpolated($"SELECT * FROM dbo.Devices WHERE DeviceToken = {deviceToken}")
                .Include(d => d.PriceExperimentData)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        public override async Task AddAsync(Device entity)
        {
            FormattableString query = $"INSERT INTO dbo.Devices (Id, DeviceToken) VALUES ({entity.Id}, {entity.DeviceToken});";
            await ExperimentDbContext.Database.ExecuteSqlInterpolatedAsync(query);
        }
    }
}
