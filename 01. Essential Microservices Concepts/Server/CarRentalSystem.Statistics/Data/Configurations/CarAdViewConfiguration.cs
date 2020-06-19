using CarRentalSystem.Statistics.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSystem.Statistics.Data.Configurations
{
    public class CarAdViewConfiguration : IEntityTypeConfiguration<CarAddView>
    {
        public void Configure(EntityTypeBuilder<CarAddView> builder)
        {
            builder
                .HasKey(v => v.Id);

            builder
                .HasIndex(v => v.CarAdId);

            builder
                .Property(v => v.UserId)
                .IsRequired();
        }
    }
}
