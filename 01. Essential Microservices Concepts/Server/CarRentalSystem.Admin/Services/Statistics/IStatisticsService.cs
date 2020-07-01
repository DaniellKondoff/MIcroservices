using CarRentalSystem.Admin.Models.Statistics;
using Refit;
using System.Threading.Tasks;

namespace CarRentalSystem.Admin.Services.Statistics
{
    public interface IStatisticsService
    {
        [Get("/Statistics")]
        Task<StatisticsOutputModel> Full();
    }
}
