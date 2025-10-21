using System.Collections;
using SafeBoda.Core;
namespace SafeBoda.Application
{
    public interface ITripRepository
    {
        public IEnumerable GetActiveTrips();
        Trip CreateTrip(Trip trip);
    }
}