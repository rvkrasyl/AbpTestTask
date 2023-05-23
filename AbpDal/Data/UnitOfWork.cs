using AbpDal.Data.Interfaces;
using AbpDal.Repositories;
using AbpDal.Repositories.Interfaces;

namespace AbpDal.Data
{
    /// <inheritdoc/>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AbpExperimentDbContext _context;

        /// <summary>
        /// Inicialize UnitOfWorkInstance
        /// </summary>
        /// <param name="context">An actual dbContext</param>
        public UnitOfWork(AbpExperimentDbContext context)
            => _context = context;

        /// <inheritdoc/>
        public IButtonColorExperimentRepository ButtonColorExperimentRepository => new ButtonColorExperimentRepository(_context);

        /// <inheritdoc/>
        public IPriceExperimentRepository PriceExperimentRepository => new PriceExperimentRepository(_context);

        /// <inheritdoc/>
        public IDeviceRepository DeviceRepository => new DeviceRepository(_context);

        /// <inheritdoc/>
        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
