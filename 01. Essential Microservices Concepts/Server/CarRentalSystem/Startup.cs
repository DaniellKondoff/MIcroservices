namespace CarRentalSystem.Dealers
{
    using AutoMapper;
    using CarRentalSystem.Common.Infrastructure;
    using Data;
    using Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Services.CarAds;
    using Services.Categories;
    using Services.Dealers;
    using Services.Manufacturers;
    using System.Reflection;

    public class Startup
    {
        public Startup(IConfiguration configuration) 
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddWebService<DealersDbContext>(this.Configuration)
                .AddTransient<IDealerService, DealerService>()
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<ICarAdService, CarAdService>()
                .AddTransient<IManufacturerService, ManufacturerService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
             .UseWebService(env)
             .Initialize<DealersDbContext>()
             .SeedData();
        }
    }
}
