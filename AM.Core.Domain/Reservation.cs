namespace AM.Core.Domain;

public class Reservation
{
    //public int Id { get; set; }
    public float Price { get; set; }
    public string Seat { get; set; }
    public bool VIP { get; set; }
    public Passenger MyPassenger { get; set; }
    public Flight MyFlight { get; set; }

    //[ForeignKey("MyPassenger")]
    public string PassengerId { get; set; }

    //[ForeignKey("MyFlight")]
    public int FlightId { get; set;}
}  