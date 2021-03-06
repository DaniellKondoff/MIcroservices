﻿using CarRentalSystem.Identity.Data;
using CarRentalSystem.Identity.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalSystem.Identity.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentitySettings(this IServiceCollection services)
        {
            services
               .AddIdentity<User, IdentityRole>(options =>
               {
                   options.Password.RequiredLength = 6;
                   options.Password.RequireDigit = false;
                   options.Password.RequireLowercase = false;
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequireUppercase = false;
               })
               .AddEntityFrameworkStores<IdentityDbContext>();

            return services;
        }
    }
}
