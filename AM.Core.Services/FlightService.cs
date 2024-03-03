using AM.Core.Domain;

namespace AM.Core.Services;

public class FlightService : IFlightService
{
    public IList<Flight> flights { get; set; }

    public double GetDurationAverage(string destination)
    {
        return (from f in flights
            where f.Destination == destination
            select f.EstimatedDuration).Average();
    }

    public IList<DateTime> GetFlightDates(string destination)
    {
        //    IList<DateTime> flightDates = new List<DateTime>();

        //    foreach (var flight in flights)
        //    {
        //        if (flight.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
        //        {
        //            flightDates.Add(flight.FlightDate);
        //        }
        //    }

        //    return flightDates;
        // methode 2 linq intgre 
        //return (from flight in flights
        //       where flight.Destination == destination
        //       select flight.FlightDate).ToList();
        //
        //methode 3
        return flights.Where(f => f.Destination == destination)
            .Select(f => f.FlightDate)
            .ToList();
    }

    public IList<Flight> GetFlights(string filterType, string filterValue)
    {
        if (string.IsNullOrEmpty(filterType) || string.IsNullOrEmpty(filterValue))
            return new List<Flight>();

        var filteredFlights = flights.Where(flight => FilterFlightByProperty(flight, filterType, filterValue)).ToList();
        return filteredFlights;
    }

    public IList<Passenger> GetThreeOlderTravellers(Flight flight)
    {
        return flight.Passengers.OrderByDescending(p => p.Age)
            .TakeLast(3)
            .ToList();
    }


    public int GetWeeklyFlightNumber(DateTime date)
    {
        return flights
            .Where(f => f.FlightDate > date && f.FlightDate == date.AddDays(7))
            .Count();
    }

    public void ShowFlightDetails(Plane plane)
    {
        var result = flights.Where(f => f.MyPlane.PlaneId == plane.PlaneId)
            .Select(f => new { f.FlightDate, f.Destination });
        foreach (var item in result)
        {
            Console.WriteLine("Flights:");
            Console.WriteLine("Destination : " + item.Destination + "Flight Date : " + item.FlightDate);
        }
    }

    public void ShowGroupedFlights()
    {
        foreach (Flight item in flights.GroupBy(f => f.Destination).ToList()) Console.WriteLine(item);
    }

    public IList<Flight> SortFlights()
    {
        return (from f in flights
            orderby f.EstimatedDuration descending
            select f).ToList();
    }

    private bool FilterFlightByProperty(Flight flight, string filterType, string filterValue)
    {
        var property = flight.GetType().GetProperty(filterType);
        if (property == null)
            return false;

        var propertyValue = property.GetValue(flight)?.ToString();
        return !string.IsNullOrEmpty(propertyValue) &&
               propertyValue.Equals(filterValue, StringComparison.OrdinalIgnoreCase);
    }
}