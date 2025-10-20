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
                new Trip(
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    new Location(-1.9501, 30.0589),
                    new Location(-1.9441, 30.0619),
                    1000m,
                    DateTime.Now
                )
            };
        }
    }
}