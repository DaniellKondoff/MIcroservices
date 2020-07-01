using CarRentalSystem.Admin.Infrastructure;
using CarRentalSystem.Admin.Services;
using CarRentalSystem.Admin.Services.Identity;
using CarRentalSystem.Admin.Services.Statistics;
using CarRentalSystem.Common.Infrastructure;
using CarRentalSystem.Common.Services.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Refit;
using CarRentalSystem.Admin.Services.Dealers;

namespace CarRentalSystem.Admin
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
            var serviceEndpoints = this.Configuration
                .GetSection(nameof(ServiceEndpoints))
                .Get<ServiceEndpoints>(config => config.BindNonPublicProperties = true);

            services
               .AddAutoMapperProfile(Assembly.GetExecutingAssembly())
               .AddTokenAuthentication(this.Configuration)
               .AddScoped<ICurrentTokenService, CurrentTokenService>()
               .AddTransient<JwtCookieAuthenticationMiddleware>()
               .AddControllersWithViews(options => options
                   .Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            services
                .AddRefitClient<IIdentityService>()
                .WithConfiguration(serviceEndpoints.Identity);

            services
                .AddRefitClient<IStatisticsService>()
                .WithConfiguration(serviceEndpoints.Statistics);

            services
                .AddRefitClient<IDealersService>()
                .WithConfiguration(serviceEndpoints.Dealers);
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage();
            }
            else
            {
                app
                    .UseExceptionHandler("/Home/Error")
                    .UseHsts();
            }

            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseJwtCookieAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints
                    .MapDefaultControllerRoute());
        }
    }
}
