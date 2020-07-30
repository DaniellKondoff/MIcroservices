using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;

namespace CarRentalSystem.Notifications.Infrastructure
{
    public class JwtBearerEventsConfiguration
    {
        public static JwtBearerEvents GetBearerEvents()
        {
            return new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var accessToken = context.Request.Query["acess_token"];

                    var path = context.HttpContext.Request.Path;
                    if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/notifications"))
                    {
                        context.Token = accessToken;
                    }
                    return Task.CompletedTask;
                }
            };
        }
    }
}
