using AbpBll.Entities.DTOs;
using AbpBll.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AbpWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExperimentController : Controller
    {
        private readonly IExperimentService _experimentService;
        public ExperimentController(IExperimentService experimentService)
        {
            _experimentService = experimentService;
        }

        [HttpGet("button-color")]
        public async Task<ActionResult<ButtonColorDto>> MakeButtonColorExperiment([FromQuery] string deviceToken)
        {
            return await _experimentService.GetButtonColorForDeviceAsync(deviceToken);
        }


        [HttpGet("price-option")]
        public async Task<ActionResult<PriceOptionDto>> MakePriceOptionExperiment([FromQuery] string deviceToken)
        {
            return await _experimentService.GetPriceOptionForDeviceAsync(deviceToken);
        }
    }
}
