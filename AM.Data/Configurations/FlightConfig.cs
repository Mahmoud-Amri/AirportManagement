using AM.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Data.Configurations;

public class FlightConfig : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.HasMany(f => f.Passengers)
            .WithMany(p => p.Flights)
            .UsingEntity(asso => asso.ToTable("Reservation"));
        builder.HasOne(f => f.MyPlane)
            .WithMany(p => p.Flights)
            .HasForeignKey(f => f.PlaneFK)
            .OnDelete(DeleteBehavior.SetNull);
    }
}