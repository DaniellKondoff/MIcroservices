using CarRentalSystem.Common.Infrastructure;
using CarRentalSystem.Schedule.Data;
using CarRentalSystem.Schedule.Messages;
using CarRentalSystem.Schedule.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalSystem.Schedule
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
            services
                .AddWebService<ScheduleDbContext>(Configuration)
                .AddTransient<IRentedCarService, RentedCarService>()
                .AddMessaging(typeof(CarAddUpdatedConsumer));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
               .UseWebService(env)
               .Initialize<ScheduleDbContext>();
        }
    }
}
