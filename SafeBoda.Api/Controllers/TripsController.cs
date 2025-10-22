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
                Id = Guid.NewGuid(),
                RiderId = request.RiderId,
                DriverId = Guid.NewGuid(),
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
        [HttpDelete("{id}")]
        public IActionResult DeleteTrip(Guid id)
        {
            var success = _tripRepository.DeleteTrip(id);
            if (!success)
                return NotFound();

            return NoContent();
        }

    }
    
    public record TripRequest(Guid RiderId, Location Start, Location End);
}