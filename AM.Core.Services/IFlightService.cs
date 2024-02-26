using System;
using System.Collections.Generic;
using AM.Core.Domain;

namespace AM.Core.Services
{
    public interface IFlightService
    {
        IList<DateTime> GetFlightDates(string destination);
        IList<Flight> GetFlights(string filterType, string filterValue);
        void ShowFlightDetails(Plane plane);
        int GetWeeklyFlightNumber(DateTime dateTime);
        double GetDurationAverage(string destination);
        IList<Flight> SortFlights();
        IList<Passenger> GetThreeOlderTravellers(Flight flight);
        void ShowGroupedFlights();
    }
}
