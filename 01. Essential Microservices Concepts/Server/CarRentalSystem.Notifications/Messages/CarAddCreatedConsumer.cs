using CarRentalSystem.Common.Messages.Dealers;
using CarRentalSystem.Notifications.Hub;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CarRentalSystem.Notifications.Messages
{
    public class CarAddCreatedConsumer : IConsumer<CarAddCreatedMessage>
    {
        private readonly IHubContext<NotificationsHub> hub;

        public CarAddCreatedConsumer(IHubContext<NotificationsHub> hub)
        {
            this.hub = hub;
        }

        public async Task Consume(ConsumeContext<CarAddCreatedMessage> context)
        {
            await this.hub
                .Clients
                .Groups(Constants.AuthenticatedUsersGroup)
                .SendAsync(Constants.ReceiveNotificationEndpoint, context.Message);
        }
    }
}
