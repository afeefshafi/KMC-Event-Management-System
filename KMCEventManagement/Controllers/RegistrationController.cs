using Microsoft.AspNetCore.Mvc;
using KMCEventManagement.Data;
using KMCEventManagement.Models;

namespace KMCEventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegistrationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult RegisterEvent(Registration registration)
        {
            registration.RegistrationDate = DateTime.Now;

            _context.Registrations.Add(registration);
            _context.SaveChanges();

            return Ok(new
            {
                message = "Event Registration Successful"
            });
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUserRegistrations(int userId)
        {
            var registrations = _context.Registrations
                .Where(r => r.UserId == userId)
                .ToList();

            return Ok(registrations);
        }
    }
}