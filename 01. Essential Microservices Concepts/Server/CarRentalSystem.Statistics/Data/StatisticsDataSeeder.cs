
namespace CarRentalSystem.Statistics.Data
{
    using CarRentalSystem.Common.Services;
    using Models;
    using System.Linq;
    public class StatisticsDataSeeder : IDataSeeder
    {
        private readonly StatisticsDbContext db;

        public StatisticsDataSeeder(StatisticsDbContext db) => this.db = db;

        public void SeedData()
        {
            if (this.db.Statistics.Any())
            {
                return;
            }

            this.db.Statistics.Add(new Statistics
            {
                TotalCarAds = 0,
                TotalRentedCars = 0
            });

            this.db.SaveChanges();
        }
    }
}
