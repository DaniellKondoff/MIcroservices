using System.Threading.Tasks;

namespace CarRentalSystem.Statistics.Services.CarAddViews
{
    public interface ICarAdViewService
    {
        Task<int> GetTotalViews(int carAdId);
    }
}
