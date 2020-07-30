namespace CarRentalSystem.Notifications.Hub
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;
    public class NotificationsHub : Hub
    {
        public async override Task OnConnectedAsync()
        {
            if (this.Context.User.Identity.IsAuthenticated)
            {
               await this.Groups.AddToGroupAsync(this.Context.ConnectionId, Constants.AuthenticatedUsersGroup);
            }
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            if (this.Context.User.Identity.IsAuthenticated)
            {
                await this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, Constants.AuthenticatedUsersGroup);
            }
        }
    }
}
