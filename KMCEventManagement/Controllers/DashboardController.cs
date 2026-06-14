using Microsoft.AspNetCore.Mvc;
using KMCEventManagement.Data;

namespace KMCEventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDashboardData()
        {
            return Ok(new
            {
                TotalEvents = _context.Events.Count(),
                TotalUsers = _context.Users.Count(),
                TotalRegistrations = _context.Registrations.Count(),
                UpcomingEvents = _context.Events.Count()
            });
        }
    }
}