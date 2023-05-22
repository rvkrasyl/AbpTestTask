using AbpBll.Entities.DTOs;
using AbpBll.Exceptions;
using AbpBll.Services.Interfaces;
using AbpDal.Data.Interfaces;
using AbpDal.Entities;
using AbpDal.Entities.EnumClasses;
using AbpDal.Entities.ExperimentOptions;

namespace AbpBll.Services
{
    public class ExperimentService : IExperimentService
    {
        private const byte MinDeviceTokenLength = 5;
        private const string InvalidDeviceTokenExceptionMsg = "Device Token Is invalid";
        private readonly IUnitOfWork _unitOfWork;

        public ExperimentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ButtonColorDto> GetButtonColorForDeviceAsync(string deviceToken)
        {
            EnsureTokenIsValid(deviceToken);
            Device device = await _unitOfWork.DeviceRepository.GetByTokenWithColorExperimentAsync(deviceToken)
                ?? await AddNewDeviceToDbAsync(deviceToken);
            ButtonColorExperimentData colorExperimentData = device.ButtonColorExperimentData
                ?? await AddNewButtonColorExperimentAsync(device.Id);

            return ConfigureColorDto(colorExperimentData);
        }

        public async Task<PriceOptionDto> GetPriceOptionForDeviceAsync(string deviceToken)
        {
            EnsureTokenIsValid(deviceToken);
            Device device = await _unitOfWork.DeviceRepository.GetByTokenWithPriceExperimentAsync(deviceToken)
                ?? await AddNewDeviceToDbAsync(deviceToken);
            PriceExperimentData priceExperimentData = device.PriceExperimentData
                ?? await AddNewPriceOptionExperimentAsync(device.Id);

            return ConfigurePriceDto(priceExperimentData);
        }

        private static void EnsureTokenIsValid(string deviceToken)
        {
            if (string.IsNullOrWhiteSpace(deviceToken) || deviceToken.Length < MinDeviceTokenLength)
            {
                throw new UserInputException(InvalidDeviceTokenExceptionMsg);
            }
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

        private async Task<PriceExperimentData> AddNewPriceOptionExperimentAsync(Guid deviceId)
        {
            PriceExperimentData data = new()
            {
                Price = PriceExperimentOptions.GetExperimentalPrice(),
                DeviceId = deviceId
            };
            await _unitOfWork.PriceExperimentRepository.AddAsync(data);

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

        private static PriceOptionDto ConfigurePriceDto(PriceExperimentData data)
        {
            return new()
            {
                Key = AvailableExperiments.PriceOption.Name,
                Value = data.Price,
            };
        }
    }
}
