using Microsoft.AspNetCore.Mvc;
using SafeBoda.Application;
using SafeBoda.Core;

namespace SafeBoda.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly ITripRepository _tripRepository;

        public TripsController(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        [HttpGet]
        public IActionResult GetAllTrips()
        {
            var trips = _tripRepository.GetActiveTrips();
            return Ok(trips);
        }

        [HttpPost("request")]
        public IActionResult RequestTrip([FromBody] TripRequest request)
        {
            var newTrip = new Trip
            {
                Id = 0, // repository will assign the ID
                RiderId = request.RiderId,
                DriverId = request.DriverId,
                StartLatitude = request.Start.Latitude,
                StartLongitude = request.Start.Longitude,
                EndLatitude = request.End.Latitude,
                EndLongitude = request.End.Longitude,
                Fare = 1000m,
                RequestTime = DateTime.Now
            };

            var createdTrip = _tripRepository.CreateTrip(newTrip);

            return CreatedAtAction(nameof(GetAllTrips), new { id = createdTrip.Id }, createdTrip);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTrip(int id, [FromBody] Trip updatedTrip)
        {
            var existingTrip = _tripRepository.GetTripById(id);
            if (existingTrip == null)
                return NotFound();

            existingTrip.RiderId = updatedTrip.RiderId;
            existingTrip.DriverId = updatedTrip.DriverId;
            existingTrip.StartLatitude = updatedTrip.StartLatitude;
            existingTrip.StartLongitude = updatedTrip.StartLongitude;
            existingTrip.EndLatitude = updatedTrip.EndLatitude;
            existingTrip.EndLongitude = updatedTrip.EndLongitude;
            existingTrip.Fare = updatedTrip.Fare;

            _tripRepository.UpdateTrip(existingTrip);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTrip(int id)
        {
            var success = _tripRepository.DeleteTrip(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }

    public record TripRequest(int RiderId, int DriverId, Location Start, Location End);
}
