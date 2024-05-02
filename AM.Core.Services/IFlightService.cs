using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public interface IFlightService :  IService<Flight>
    {
        List<DateTime> GetFlightDates(String destination);
        void GetFlights(string filterType, string filterValue);
        void ShowFlightDetails(Plane plane);
        int GetWeeklyFlightNumber(DateTime startDate);
        double GetDurationAverage(string destination);
        IEnumerable<Flight> SortFlights();
        IEnumerable<String> GetThreeOlderTravellers(Flight flight);
        IEnumerable<IGrouping<string, Flight>> ShowGroupedFlights();
        /* void Add(Flight flight);
         void Delete(Flight flight);

         IList<Flight> GetAll();*/



    }
}