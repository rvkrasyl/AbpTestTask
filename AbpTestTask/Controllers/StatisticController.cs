﻿using AbpBll.Entities.Models;
using AbpBll.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AbpWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticController : Controller
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
            => _statisticService = statisticService;

        [HttpGet]
        public async Task<IEnumerable<ExperimentDetails>> GetExperimentsStatistic()
            => await _statisticService.GetStatisticAsync();
    }
}
