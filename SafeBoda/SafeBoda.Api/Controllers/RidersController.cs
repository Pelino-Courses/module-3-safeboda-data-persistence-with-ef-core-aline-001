using Microsoft.AspNetCore.Mvc;
using SafeBoda.Infrastructure;
using SafeBoda.Core;

namespace SafeBoda.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RidersController : ControllerBase
    {
        private readonly SafeBodaDbContext _context;
        public RidersController(SafeBodaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Riders.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var rider = _context.Riders.Find(id);
            if (rider == null) return NotFound();
            return Ok(rider);
        }

        [HttpPost]
        public IActionResult Create(Rider rider)
        {
            _context.Riders.Add(rider);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = rider.Id }, rider);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Rider updated)
        {
            var rider = _context.Riders.Find(id);
            if (rider == null) return NotFound();

            rider.Name = updated.Name;
            rider.PhoneNumber = updated.PhoneNumber;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rider = _context.Riders.Find(id);
            if (rider == null) return NotFound();

            _context.Riders.Remove(rider);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
