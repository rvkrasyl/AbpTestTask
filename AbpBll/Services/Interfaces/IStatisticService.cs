using AbpBll.Entities.Models;

namespace AbpBll.Services.Interfaces
{
    public interface IStatisticService
    {
        Task<IEnumerable<ExperimentDetails>> GetStatisticAsync();
    }
}
