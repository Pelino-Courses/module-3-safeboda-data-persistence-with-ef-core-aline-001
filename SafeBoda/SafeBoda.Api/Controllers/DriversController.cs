using Microsoft.AspNetCore.Mvc;
using SafeBoda.Infrastructure;
using SafeBoda.Core;

namespace SafeBoda.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly SafeBodaDbContext _context;
        public DriversController(SafeBodaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Drivers.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var driver = _context.Drivers.Find(id);
            if (driver == null) return NotFound();
            return Ok(driver);
        }

        [HttpPost]
        public IActionResult Create(Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = driver.Id }, driver);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Driver updated)
        {
            var driver = _context.Drivers.Find(id);
            if (driver == null) return NotFound();

            driver.Name = updated.Name;
            driver.PhoneNumber = updated.PhoneNumber;
            driver.MotoPlateNumber = updated.MotoPlateNumber;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var driver = _context.Drivers.Find(id);
            if (driver == null) return NotFound();

            _context.Drivers.Remove(driver);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
