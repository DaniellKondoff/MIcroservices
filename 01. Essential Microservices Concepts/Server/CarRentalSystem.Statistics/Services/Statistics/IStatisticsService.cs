using CarRentalSystem.Statistics.Models;
using System.Threading.Tasks;

namespace CarRentalSystem.Statistics.Services.Statistics
{
    public interface IStatisticsService
    {
        Task<StatisticsOutputModel> Full();

        Task AddCarAd();
    }
}
