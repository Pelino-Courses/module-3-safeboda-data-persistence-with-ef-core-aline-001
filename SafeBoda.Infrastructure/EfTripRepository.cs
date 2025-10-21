using SafeBoda.Application;
using SafeBoda.Core;
using System.Collections;

namespace SafeBoda.Infrastructure
{
    public class EfTripRepository : ITripRepository
    {
        private readonly SafeBodaDbContext _db;

        public EfTripRepository(SafeBodaDbContext db)
        {
            _db = db;
        }

        public IEnumerable GetActiveTrips()
        {
            return _db.Trips.ToList();
        }

        public Trip CreateTrip(Trip trip)
        {
            if (trip.Id == Guid.Empty) trip.Id = Guid.NewGuid();
            trip.RequestTime = DateTime.UtcNow;
            _db.Trips.Add(trip);
            _db.SaveChanges();
            return trip;
        }
    }
}