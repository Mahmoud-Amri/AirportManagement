﻿
using AM.Core.Domain;
using AM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Core.Services;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IFlightService
    {
        
        public List<Flight> Flights => GetAll().ToList();  
        //Delegates
        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;
        
        public ServiceFlight(IUnitOfWork unitOfWork):base(unitOfWork)
        {

            // DurationAverageDel = DurationAverage;
            DurationAverageDel = dest =>
            {
                return (from f in Flights
                        where f.Destination.Equals(dest)
                        select f.EstimatedDuration).Average();
            };
            // FlightDetailsDel = ShowFlightDetails;
            FlightDetailsDel = p =>
           {
               var req = from f in Flights
                         where f.MyPlane == p
                         select new { f.FlightDate, f.Destination };
               foreach (var v in req)
                   Console.WriteLine("Flight Date; " + v.FlightDate + " Flight destination: " + v.Destination);
           };
        }
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> ls = new List<DateTime>();
            //With for structure
            //for (int j = 0; j < Flights.Count; j++)
            //    if (Flights[j].Destination.Equals(destination))
            //        ls.Add(Flights[j].FlightDate);

            //With foreach structure
            //foreach(Flight f in Flights)
            //    if (f.Destination.Equals(destination))
            //        ls.Add(f.FlightDate);
            //return ls;

            //with LINQ language
            IEnumerable<DateTime> req = from f in Flights
                                        where f.Destination.Equals(destination)
                                        select f.FlightDate;
            //with Lambda expressions
            // IEnumerable<DateTime> reqLambda = Flights.Where(f => f.Destination.Equals(destination)).Select(f => f.FlightDate);

            return req.ToList();
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination.Equals(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse(filterValue))

                            Console.WriteLine(f);

                    }
                    break;
                case "EffectiveArrival":
                    foreach (Flight f in Flights)
                    {
                        if (f.EffectiveArrival == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
            }
        }

        public void ShowFlightDetails(Plane plane)
        {
            var req = from f in Flights
                      where f.MyPlane == plane
                      select new { f.FlightDate, f.Destination };

            //  var reqLambda = Flights.Where(f => f.Plane == plane).Select(p => new { f.FlightDate, f.Destination });
            foreach (var v in req)
                Console.WriteLine("Flight Date; " + v.FlightDate + " Flight destination: " + v.Destination);
        }

        public int GetWeeklyFlightNumber(DateTime startDate)
        {
            var req = from f in Flights
                      where DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays < 7
                      select f;
            // var reqLambda = Flights.Where(f => DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays < 7);
            return req.Count();

        }

        public double GetDurationAverage(string destination)
        {
            return (from f in Flights
                    where f.Destination.Equals(destination)
                    select f.EstimatedDuration).Average();
           // return Flights.Where(f=>f.Destination.Equals(destination)).Select(f=> f.EstimatedDuration).Average();
        }

        public IEnumerable<Flight> SortFlights()
        {
            var req = from f in Flights
                      orderby f.EstimatedDuration descending
                      select f;
            // var reqLambda = Flights.OrderByDescending(f => f.EstimatedDuration);
            return req;
        }

        public IEnumerable<String> GetThreeOlderTravellers(Flight f)
        {

            var oldTravellers = from p in f.Reservations.Select(t => t.MyPassenger).OfType<Traveller>()
                                orderby p.BirthDate
                                select p.Nationality;

            // var reqLambda = f.Passengers.OfType<Traveller>().OrderBy(p => p.BirthDate).Take(3);


            return oldTravellers.Take(3);
            //if we want to skip 3
            //return oldTravellers.Skip(3);

        }

        public IEnumerable<IGrouping<string, Flight>> ShowGroupedFlights()
        {
            var req = from f in Flights
                group f by f.Destination;

            //  var reqLambda = Flights.GroupBy(f => f.Destination);

            foreach (var g in req)
            { Console.WriteLine("Destination: " + g.Key);
                foreach (var f in g)
                    Console.WriteLine("Décollage: " +f.FlightDate);
            }
            return req;
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;

          //  var reqLambda = Flights.GroupBy(f => f.Destination);

            foreach (var g in req)
            { Console.WriteLine("Destination: " + g.Key);
                foreach (var f in g)
                Console.WriteLine("Décollage: " +f.FlightDate);
            }
            return req;
        }

        public List<Flight> GetFlightByDate(DateTime DateDepart)
        {
            List<Flight> listflight = new List<Flight>();
            foreach(var flight in this.GetAll())
            {

                if (flight.FlightDate.ToShortDateString()== DateDepart.ToShortDateString() )
                {
                    listflight.Add(flight);
                }
            }
            return listflight;
            //return GetMany(f => f.FlightDate.Date.Equals(DateDepart)).ToList();
        }
    }
}
