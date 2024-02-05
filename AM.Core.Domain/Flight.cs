namespace AM.Core.Domain;
public class Flight
{
    public string Destination { get; set; }

    public string Departure { get; set; }

    public DateTime FlightDate { get; set; }

    public int FlightId { get; set; }

    public DateTime EffectiveArrival { get; set; }

    public DateTime EstimatedDuration { get; set; }

    public Plane MyPlane { get; set; }

    public IList<Passenger> Passengers { get; set; }

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

