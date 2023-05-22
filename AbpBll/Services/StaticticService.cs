using AbpBll.Entities.Models;
using AbpBll.Services.Interfaces;
using AbpDal.Data.Interfaces;
using AbpDal.Entities;
using AbpDal.Entities.EnumClasses;

namespace AbpBll.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatisticService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ExperimentDetails>> GetStatisticAsync()
        {
            var allDevicesData = await _unitOfWork.DeviceRepository.GetAllWithExperimentsDataAsync();
            List<ExperimentOptionDevices> buttonExperimentsDevices = GetButtonColorExperimenDevices(allDevicesData);
            List<ExperimentOptionDevices> priceExperimentsDevices = GetPriceOptionExperimentDevices(allDevicesData);
            
            return SetupExperimentDetails(buttonExperimentsDevices, priceExperimentsDevices);
        }

        private static List<ExperimentDetails> SetupExperimentDetails(List<ExperimentOptionDevices> buttonExperimentsDevices, List<ExperimentOptionDevices> priceExperimentsDevices)
            => new()
            {
                new ExperimentDetails() { ExperimentName = AvailableExperiments.ButtonColor.Name, ExperimentOptionDevices = buttonExperimentsDevices, DevicesInExperimentCount = buttonExperimentsDevices.Sum(d => d.DeviceCount) },
                new ExperimentDetails() { ExperimentName = AvailableExperiments.PriceOption.Name, ExperimentOptionDevices = priceExperimentsDevices, DevicesInExperimentCount = priceExperimentsDevices.Sum(d => d.DeviceCount) },
            };

        private static List<ExperimentOptionDevices> GetPriceOptionExperimentDevices(IEnumerable<Device> allDevicesData)
            => allDevicesData
                .Where(d => d.PriceExperimentData != null)
                .Select(d => d.PriceExperimentData)
                .GroupBy(ped => ped.Price)
                .Select(o => new ExperimentOptionDevices() { ExperimentOption = o.Key.ToString(), DeviceCount = o.Count() })
                .ToList();

        private static List<ExperimentOptionDevices> GetButtonColorExperimenDevices(IEnumerable<Device> allDevicesData)
            => allDevicesData
                .Where(d => d.ButtonColorExperimentData != null)
                .Select(d => d.ButtonColorExperimentData)
                .GroupBy(bcde => bcde.ButtonColor)
                .Select(o => new ExperimentOptionDevices() { ExperimentOption = o.Key, DeviceCount = o.Count() })
                .ToList();
    }
}
