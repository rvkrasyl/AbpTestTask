using AbpDal.Data.Interfaces;
using AbpDal.Repositories;
using AbpDal.Repositories.Interfaces;

namespace AbpDal.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AbpExperimentDbContext _context;

        public UnitOfWork(AbpExperimentDbContext context)
            => _context = context;

        public IButtonColorExperimentRepository ButtonColorExperimentRepository => new ButtonColorExperimentRepository(_context);

        public IPriceExperimentRepository PriceExperimentRepository => new PriceExperimentRepository(_context);

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
