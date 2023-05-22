using AbpDal.Repositories.Interfaces;

namespace AbpDal.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IButtonColorExperimentRepository ButtonColorExperimentRepository { get; }

        IPriceExperimentRepository PriceExperimentRepository { get; }

        Task SaveAsync();
    }
}
