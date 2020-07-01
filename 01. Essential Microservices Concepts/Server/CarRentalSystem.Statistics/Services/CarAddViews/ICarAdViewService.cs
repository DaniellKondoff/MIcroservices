using CarRentalSystem.Statistics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalSystem.Statistics.Services.CarAddViews
{
    public interface ICarAdViewService
    {
        Task<int> GetTotalViews(int carAdId);

        Task<IEnumerable<CarAdViewOutputModel>> GetTotalViews(IEnumerable<int> ids);
    }
}
