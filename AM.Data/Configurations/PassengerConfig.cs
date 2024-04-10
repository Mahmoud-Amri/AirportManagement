using AM.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Data.Configurations;

public class PassengerConfig:IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        builder.OwnsOne(p => p.MyFullName,
            fn =>
            {
                fn.Property(f => f.FirstName).HasMaxLength(30).HasColumnName("Name");
                fn.Property(f => f.LastName).IsRequired();
                    
            }
        );
    }
}