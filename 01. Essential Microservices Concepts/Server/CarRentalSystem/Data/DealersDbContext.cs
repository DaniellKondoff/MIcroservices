﻿namespace CarRentalSystem.Dealers.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Reflection;

    public class DealersDbContext : DbContext
    {
        public DealersDbContext(DbContextOptions<DealersDbContext> options)
            : base(options)
        {
        }

        public DbSet<CarAd> CarAds { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Dealer> Dealers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}