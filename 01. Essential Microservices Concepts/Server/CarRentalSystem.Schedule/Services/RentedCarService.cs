using CarRentalSystem.Common.Services;
using CarRentalSystem.Schedule.Data;
using CarRentalSystem.Schedule.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalSystem.Schedule.Services
{
    public class RentedCarService : DataService<RentedCar>, IRentedCarService
    {
        public RentedCarService(ScheduleDbContext db) : base(db)
        {
        }
        public async Task UpdateInformation(int carAddId, string manufacturer, string model)
        {
            var rentedCars = await this.All()
                .Where(rc => rc.CarAdId == carAddId)
                .ToListAsync();

            foreach (var rentedCar in rentedCars)
            {
                rentedCar.DisplayInfo = $"{manufacturer} {model}";
            }

            await this.Data.SaveChangesAsync();
        }
    }
}
