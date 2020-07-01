using CarRentalSystem.Common.Infrastructure;
using CarRentalSystem.Identity.Data;
using CarRentalSystem.Identity.Infrastructure;
using CarRentalSystem.Identity.Services.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalSystem.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddWebService<IdentityDbContext>(this.Configuration)
                .AddIdentitySettings()
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IJwtTokenGeneratorService, JwtTokenGeneratorService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .UseWebService(env)
                .Initialize<IdentityDbContext>();
        }
    }
}
