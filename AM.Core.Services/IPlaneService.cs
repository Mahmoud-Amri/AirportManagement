using AM.Core.Domain;

namespace AM.Core.Services;

public interface IPlaneService : IService<Plane>
{
    IList<Passenger> GetPassengers(Plane plane);
    IList<IGrouping<int, Flight>> GetFlights(int n);
    bool IsAvailable(Flight flight, int n);
    void DeletePlanes();


}