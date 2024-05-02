using AM.Core.Domain;
using AM.Core.Interfaces;

namespace AM.Core.Services;

public class PlaneService : Service<Plane> , IPlaneService
{
    public PlaneService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public IList<Passenger> GetPassengers(Plane plane)
    {
        return GetById(plane.PlaneId).Flights.SelectMany(f=>f.Reservations.Select(t=>t.MyPassenger)).ToList();
    }

    public IList<IGrouping<int, Flight>> GetFlights(int n)
    {
        return GetAll().OrderByDescending(p=>p.PlaneId).Take(n).SelectMany(p=>p.Flights).GroupBy(f=>f.MyPlane.PlaneId).ToList();
    }

    public bool IsAvailable(Flight flight, int n)
    {
        return flight.MyPlane.Capacity > flight.Reservations.Count() + n;
        
    }

    public void DeletePlanes()
    {
        foreach (var plane in GetAll().Where(p => (DateTime.Now - p.ManufactureDate).TotalDays > 365 * 10).ToList())
        {
            Delete(plane);
            Commit();
        }
    }

}