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

        // GET 
        [HttpGet]
        public IActionResult GetAllTrips()
        {
            var trips = _tripRepository.GetActiveTrips();
            return Ok(trips);
        }

        // POST 
        [HttpPost("request")]
        public IActionResult RequestTrip([FromBody] TripRequest request)
        {
            var newTrip = new Trip(
                Guid.NewGuid(),
                request.RiderId,
                Guid.NewGuid(), 
                request.Start,
                request.End,
                1000m,
                DateTime.Now
            );
            return Ok(newTrip);
        }
    }

    public record TripRequest(Guid RiderId, Location Start, Location End);
}