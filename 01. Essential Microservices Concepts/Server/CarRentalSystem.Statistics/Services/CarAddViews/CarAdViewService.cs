using CarRentalSystem.Common.Services;
using CarRentalSystem.Statistics.Data;
using CarRentalSystem.Statistics.Data.Models;
using CarRentalSystem.Statistics.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<CarAdViewOutputModel>> GetTotalViews(
            IEnumerable<int> ids)
            => await this
                .All()
                .Where(v => ids.Contains(v.CarAdId))
                .GroupBy(v => v.CarAdId)
                .Select(gr => new CarAdViewOutputModel
                {
                    CarAdId = gr.Key,
                    TotalViews = gr.Count()
                })
                .ToListAsync();
    }
}
