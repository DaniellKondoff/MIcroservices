using CarRentalSystem.Common.Infrastructure;
using CarRentalSystem.Common.Services;
using CarRentalSystem.Statistics.Data;
using CarRentalSystem.Statistics.Messages;
using CarRentalSystem.Statistics.Services.CarAddViews;
using CarRentalSystem.Statistics.Services.Statistics;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalSystem.Statistics
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
                .AddWebService<StatisticsDbContext>(this.Configuration)
                .AddTransient<IDataSeeder, StatisticsDataSeeder>()
                .AddTransient<IStatisticsService, StatisticsService>()
                .AddTransient<ICarAdViewService, CarAdViewService>()
                .AddMessaging(typeof(CarAddCreatedConsumer));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .UseWebService(env)
                .Initialize<StatisticsDbContext>();
        }
    }
}
