using System;
using System.Collections.Generic;
using System.Linq;
using SafeBoda.Core;

namespace SafeBoda.Application
{
    public class InMemoryTripRepository : ITripRepository
    {
        private readonly List<Trip> _trips = new List<Trip>();

        public IEnumerable<Trip> GetActiveTrips()
        {
            return new List<Trip>
            {
                new Trip
                {
                    Id = 1,
                    RiderId = 1,
                    DriverId = 1,
                    StartLatitude = -1.9501,
                    StartLongitude = 30.0589,
                    EndLatitude = -1.9441,
                    EndLongitude = 30.0619,
                    Fare = 1000m,
                    RequestTime = DateTime.Now
                }
            };
        }

        public Trip CreateTrip(Trip trip)
        {
            if (trip.Id == 0)
                trip.Id = _trips.Count + 1;

            trip.RequestTime = DateTime.Now;
            _trips.Add(trip);
            return trip;
        }

        public bool DeleteTrip(int tripId)
        {
            var trip = _trips.FirstOrDefault(t => t.Id == tripId);
            if (trip == null) return false;

            _trips.Remove(trip);
            return true;
        }
    }
}
