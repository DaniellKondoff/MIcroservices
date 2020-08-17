using CarRentalSystem.Common.Services.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using System.Text;
using AutoMapper;
using CarRentalSystem.Common.Models;
using MassTransit;
using System.Threading.Tasks;

namespace CarRentalSystem.Common.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebService<TDbContext>(this IServiceCollection services, IConfiguration configuration)
            where TDbContext : DbContext
        {
            services
                .AddDatabase<TDbContext>(configuration)
                .AddApplicationSettings(configuration)
                .AddTokenAuthentication(configuration)
                .AddAutoMapperProfile(Assembly.GetCallingAssembly())
                .AddControllers();

            return services;
        }
        public static IServiceCollection AddDatabase<TDbContext>(this IServiceCollection services, IConfiguration configuration)
            where TDbContext : DbContext
        {
            services
               .AddScoped<DbContext, TDbContext>()
               .AddDbContext<TDbContext>(options => options
                   .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection AddApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                 .Configure<ApplicationSettings>(configuration
                     .GetSection(nameof(ApplicationSettings)));
        }

        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration configuration, JwtBearerEvents events = null)
        {
            var secret = configuration
                .GetSection(nameof(ApplicationSettings))
                .GetValue<string>(nameof(ApplicationSettings.Secret));

            var key = Encoding.ASCII.GetBytes(secret);

            services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                    if(events != null)
                    {
                        bearer.Events = events;
                    }

                    bearer.Events = new JwtBearerEvents
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
                });

            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }

        public static IServiceCollection AddAutoMapperProfile(
            this IServiceCollection services,
            Assembly assembly)
            => services
                .AddAutoMapper(
                    (_, config) => config
                        .AddProfile(new MappingProfile(assembly)),
                    Array.Empty<Assembly>());

        public static IServiceCollection AddMessaging(this IServiceCollection services, params Type[] consumers)
        {
            services.AddMassTransit(mt =>
            {
                consumers.ForEach(consumer => mt.AddConsumer(consumer));

                mt.AddBus(bus => Bus.Factory.CreateUsingRabbitMq(rmq =>
                {
                    rmq.Host("rabbitmq", host =>
                    {
                        host.Username("rabbitmq");
                        host.Password("rabbitmq");
                    });

                    consumers.ForEach(consumer => rmq.ReceiveEndpoint(consumer.FullName, endpoint =>
                    {
                        endpoint.ConfigureConsumer(bus, consumer);
                    }));

                }));
            })
            .AddMassTransitHostedService();

            return services;
        }
    }
}
