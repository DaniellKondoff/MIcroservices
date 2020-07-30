using CarRentalSystem.Schedule.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CarRentalSystem.Schedule.Data
{
    public class ScheduleDbContext : DbContext
    {
        public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options)
            : base(options)
        {
        }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Feedback> Feedback { get; set; }

        public DbSet<RentedCar> RentedCars { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
