using System.Collections.Generic;
using SafeBoda.Core;

namespace SafeBoda.Application
{
    public interface ITripRepository
    {
        IEnumerable<Trip> GetActiveTrips();
        Trip CreateTrip(Trip trip);
        bool DeleteTrip(int tripId);
    }
}
