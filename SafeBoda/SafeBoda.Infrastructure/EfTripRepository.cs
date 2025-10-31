using SafeBoda.Application;
using SafeBoda.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace SafeBoda.Infrastructure
{
    public class EfTripRepository : ITripRepository
    {
        private readonly SafeBodaDbContext _db;

        public EfTripRepository(SafeBodaDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Trip> GetActiveTrips()
        {
            return _db.Trips
                .Include(t => t.Rider)
                .Include(t => t.Driver)
                .ToList();
        }

        public Trip CreateTrip(Trip trip)
        {
            trip.RequestTime = DateTime.UtcNow;
            _db.Trips.Add(trip);
            _db.SaveChanges();
            return trip;
        }

        public bool DeleteTrip(int tripId)
        {
            var trip = _db.Trips.Find(tripId);
            if (trip == null) return false;

            _db.Trips.Remove(trip);
            _db.SaveChanges();
            return true;
        }
    }
}
