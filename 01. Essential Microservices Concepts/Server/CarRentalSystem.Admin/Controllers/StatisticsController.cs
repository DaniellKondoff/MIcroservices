using CarRentalSystem.Admin.Services.Statistics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRentalSystem.Admin.Controllers
{
    public class StatisticsController : AdministrationController
    {
        private readonly IStatisticsService statistics;

        public StatisticsController(IStatisticsService statistics)
            => this.statistics = statistics;

        public async Task<IActionResult> Index()
            => View(await this.statistics.Full());
    }
}
