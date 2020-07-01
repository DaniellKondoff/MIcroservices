using CarRentalSystem.Gateway.Models.CarAds;
using Refit;
using System.Threading.Tasks;

namespace CarRentalSystem.Gateway.Services.CarAds
{
    public interface ICarAdService
    {
        [Get("/CarAds/Mine")]
        Task<MineCarAdsOutputModel> Mine();
    }
}
