using AbpDal.Data;
using AbpDal.Entities;
using AbpDal.Repositories.Interfaces;

namespace AbpDal.Repositories
{
    public class DeviceRepository : Repository<Device>, IDeviceRepository
    {
        public DeviceRepository(AbpExperimentDbContext experimentDbContext)
            : base(experimentDbContext)
        {
        }
    }
}
