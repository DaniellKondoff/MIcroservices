using CarRentalSystem.Common.Messages.Dealers;
using CarRentalSystem.Statistics.Services.Statistics;
using MassTransit;
using System.Threading.Tasks;

namespace CarRentalSystem.Statistics.Messages
{
    public class CarAddCreatedConsumer : IConsumer<CarAddCreatedMessage>
    {
        private readonly IStatisticsService statisticsService;

        public CarAddCreatedConsumer(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        public async Task Consume(ConsumeContext<CarAddCreatedMessage> context)
        {
            var message = context.Message;

            await this.statisticsService.AddCarAd();
        }
    }
}
