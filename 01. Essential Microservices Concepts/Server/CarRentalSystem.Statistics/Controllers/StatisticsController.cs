using CarRentalSystem.Common.Controllers;
using CarRentalSystem.Statistics.Models;
using CarRentalSystem.Statistics.Services.Statistics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRentalSystem.Statistics.Controllers
{
    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService statistics;

        public StatisticsController(IStatisticsService statistics)
            => this.statistics = statistics;

        [HttpGet]
        public async Task<StatisticsOutputModel> Full()
            => await this.statistics.Full();
    }
}
