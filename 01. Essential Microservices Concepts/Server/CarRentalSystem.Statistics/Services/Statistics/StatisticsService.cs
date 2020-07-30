namespace CarRentalSystem.Statistics.Services.Statistics
{
    using AutoMapper;
    using CarRentalSystem.Common.Services;
    using CarRentalSystem.Statistics.Models;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class StatisticsService : DataService<Statistics>, IStatisticsService
    {
        private readonly IMapper mapper;

        public StatisticsService(StatisticsDbContext db, IMapper mapper)
            : base(db)
        {
            this.mapper = mapper;
        }

        public async Task AddCarAd()
        {
            var statistics = await this.All().SingleOrDefaultAsync();

            statistics.TotalCarAds++;

            await this.Data.SaveChangesAsync();
        }

        public async Task<StatisticsOutputModel> Full()
            => await this.mapper
                .ProjectTo<StatisticsOutputModel>(this.All())
                .SingleOrDefaultAsync();
    }
}
