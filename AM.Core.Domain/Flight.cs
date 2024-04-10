using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.Core.Domain;

public class Flight
{
    
    public string Destination { get; set; }
     
    public string Departure { get; set; }

    public DateTime FlightDate { get; set; }

    public int FlightId { get; set; }

    public DateTime EffectiveArrival { get; set; }

    public int EstimatedDuration { get; set; }

    public int? PlaneFK { get; set; }

    [ForeignKey("PlaneFK")]
    public Plane MyPlane { get; set; }

    //public IList<Passenger> Passengers { get; set; }
    public IList<Reservation> Reservations { get; set; }
    public override string ToString()
    {
        return "EffectiveArrival:" + EffectiveArrival
                                   + "EstimatedDuration:" + EstimatedDuration
                                   + "FlightDate:" + FlightDate
                                   + "Destination:" + Destination
                                   + "Departure:" + Departure
                                   + "FlightId:" + FlightId;
    }
}