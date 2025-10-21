using System.Collections;
using SafeBoda.Core;
namespace SafeBoda.Application
{
    public class InMemoryTripRepository : ITripRepository
    {
        public IEnumerable GetActiveTrips()
        {
            return new ArrayList
            {
                new Trip
                {
                    Id = Guid.NewGuid(),
                    RiderId = Guid.NewGuid(),
                    DriverId = Guid.NewGuid(),
                    StartLatitude = -1.9501,
                    StartLongitude = 30.0589,
                    EndLatitude = -1.9441,
                    EndLongitude = 30.0619,
                    Fare = 1000m,
                    RequestTime = DateTime.Now
                }
            };
        }
    }
}