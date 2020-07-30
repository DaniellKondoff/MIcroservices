using CarRentalSystem.Common.Messages.Dealers;
using CarRentalSystem.Schedule.Services;
using MassTransit;
using System.Threading.Tasks;

namespace CarRentalSystem.Schedule.Messages
{
    public class CarAddUpdatedConsumer : IConsumer<CarAddUpdatedMesage>
    {
        private readonly IRentedCarService rentedCarService;

        public CarAddUpdatedConsumer(IRentedCarService rentedCarService)
        {
            this.rentedCarService = rentedCarService;
        }

        public async Task Consume(ConsumeContext<CarAddUpdatedMesage> context)
        {
            var message = context.Message;

            await this.rentedCarService.UpdateInformation(message.CarAddId, message.Manufacturer, message.Model);
        }
    }
}
