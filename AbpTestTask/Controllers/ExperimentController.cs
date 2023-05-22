using Microsoft.AspNetCore.Mvc;

namespace AbpWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExperimentController : Controller
    {
        public ExperimentController()
        {
        }

        [HttpGet("button-color")]
        public async Task<ActionResult<string>> MakeButtonColorExperiment([FromQuery] string deviceToken)
        {
            return await Task.FromResult("oasd");
        }


        [HttpGet("price-option")]
        public async Task<ActionResult<string>> MakeOriceOptionExperiment([FromQuery] string deviceToken)
        {
            return await Task.FromResult("oasd");
        }
    }
}
