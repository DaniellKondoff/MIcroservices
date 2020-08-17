namespace CarRentalSystem.Statistics.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    public class StatisticsDbContext : DbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarAddView> CarAdViews { get; set; }

        public virtual DbSet<Statistics> Statistics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
