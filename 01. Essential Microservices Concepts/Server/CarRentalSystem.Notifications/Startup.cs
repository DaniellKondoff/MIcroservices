using CarRentalSystem.Common.Infrastructure;
using CarRentalSystem.Notifications.Hub;
using CarRentalSystem.Notifications.Infrastructure;
using CarRentalSystem.Notifications.Messages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarRentalSystem.Notifications
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTokenAuthentication(this.Configuration,JwtBearerEventsConfiguration.GetBearerEvents());
            services.AddMessaging(typeof(CarAddCreatedConsumer));
            services.AddSignalR();
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseRouting()
                .UseCors(options => options
                .WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapHub<NotificationsHub>("/notifications");
                });
        }
    }
}
