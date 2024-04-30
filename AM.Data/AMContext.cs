using AM.Core.Domain;
using AM.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Data;

public class AMContext : DbContext
{
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Plane> Planes { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Traveller> Travellers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=database.sqlite");
        optionsBuilder.UseLazyLoadingProxies(true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PlaneConfig());
        modelBuilder.ApplyConfiguration(new FlightConfig());
        modelBuilder.ApplyConfiguration(new PassengerConfig());
        modelBuilder.ApplyConfiguration(new ReservationConfig());
        
        //tp4 qst 9 methode 3 sans utiliteser les conventions 
        // foreach (var entity in modelBuilder.Model.GetEntityTypes())
        // {
        //     foreach (var prop in entity.GetProperties())
        //     {
        //         if (prop.GetType() == typeof(DateTime))
        //         {
        //             prop.SetColumnType("date");
        //         }
        //     }
        // }
        
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        //configurationBuilder.Properties<String>().HaveMaxLength(30);
        configurationBuilder.Properties<DateTime>().HaveColumnType("date");
    }
}