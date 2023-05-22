using AbpBll.Entities.DTOs;

namespace AbpBll.Services.Interfaces
{
    public interface IExperimentService
    {
        Task<ButtonColorDto> GetButtonColorForDeviceAsync(string deviceToken);

        Task<PriceOptionDto> GetPriceOptionForDeviceAsync(string deviceToken);
    }
}
