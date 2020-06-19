using CarRentalSystem.Common.Services;
using CarRentalSystem.Statistics.Data;
using CarRentalSystem.Statistics.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarRentalSystem.Statistics.Services.CarAddViews
{
    public class CarAdViewService : DataService<CarAddView>, ICarAdViewService
    {
        public CarAdViewService(StatisticsDbContext db)
            : base(db)
        {
        }

        public async Task<int> GetTotalViews(int carAdId)
            => await this
                .All()
                .CountAsync(v => v.CarAdId == carAdId);
    }
}
