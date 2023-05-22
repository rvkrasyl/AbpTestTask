﻿using AbpDal.Entities;

namespace AbpDal.Repositories.Interfaces
{
    public interface IDeviceRepository : IRepository<Device>
    {
        Task<Device> GetByTokenWithColorExperimentAsync(string deviceToken);
    }
}
