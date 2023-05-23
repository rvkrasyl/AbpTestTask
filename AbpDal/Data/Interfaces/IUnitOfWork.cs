using AbpDal.Repositories.Interfaces;

namespace AbpDal.Data.Interfaces
{
    /// <summary>
    /// Represents object which is a single point to access to project's necessary data. Part of unitOfWork pattern. 
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Repository that contains methods to interact with Button Color experiments data.
        /// </summary>
        IButtonColorExperimentRepository ButtonColorExperimentRepository { get; }

        /// <summary>
        /// Repository that contains methods to interact with Price Options experiments data.
        /// </summary>
        IPriceExperimentRepository PriceExperimentRepository { get; }

        /// <summary>
        /// Repository that contains methods to interact with devices which took part in experiments.
        /// </summary>
        IDeviceRepository DeviceRepository { get; }

        /// <summary>
        /// Saves all the changes applied to DB.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task SaveAsync();
    }
}
