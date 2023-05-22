using AbpBll.Entities.DTOs;
using AbpBll.Services.Interfaces;
using AbpDal.Data.Interfaces;
using AbpDal.Entities;
using AbpDal.Entities.EnumClasses;
using AbpDal.Entities.ExperimentOptions;

namespace AbpBll.Services
{
    public class ExperimentService : IExperimentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExperimentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ButtonColorDto> GetButtonColorForDeviceAsync(string deviceToken)
        {
            Device device = await _unitOfWork.DeviceRepository.GetByTokenWithColorExperimentAsync(deviceToken)
                ?? await AddNewDeviceToDbAsync(deviceToken);
            ButtonColorExperimentData colorExperimentData = device.ButtonColorExperimentData
                ?? await AddNewButtonColorExperimentAsync(device.Id);

            return ConfigureColorDto(colorExperimentData);
        }

        public Task<PriceOptionDto> GetPriceOptionForDeviceAsync(string deviceToken)
        {
            throw new NotImplementedException();
        }

        private async Task<Device> AddNewDeviceToDbAsync(string deviceToken)
        {
            Device device = new()
            {
                DeviceToken = deviceToken,
                ButtonColorExperimentData = default,
                PriceExperimentData = default,
            };
            await _unitOfWork.DeviceRepository.AddAsync(device);

            return device;
        }

        private async Task<ButtonColorExperimentData> AddNewButtonColorExperimentAsync(Guid deviceId)
        {
            ButtonColorExperimentData data = new()
            {
                ButtonColor = ButtonColorOptions.GetExperimentalColor(),
                DeviceId = deviceId
            };
            await _unitOfWork.ButtonColorExperimentRepository.AddAsync(data);

            return data;
        }

        private static ButtonColorDto ConfigureColorDto(ButtonColorExperimentData data)
        {
            return new()
            {
                Key = AvailableExperiments.ButtonColor.Name,
                Value = data.ButtonColor,
            };
        }
    }
}
