using Microsoft.AspNetCore.Mvc;
using KMCEventManagement.Data;
using KMCEventManagement.Models;

namespace KMCEventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public IActionResult CreateEvent(Event ev)
        {
            _context.Events.Add(ev);
            _context.SaveChanges();

            return Ok(new
            {
                message = "Event Created Successfully"
            });
        }

        [HttpGet("all")]
        public IActionResult GetAllEvents()
        {
            return Ok(_context.Events.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            var ev = _context.Events.FirstOrDefault(e => e.EventId == id);

            if (ev == null)
            {
                return NotFound();
            }

            return Ok(ev);
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateEvent(int id, Event updatedEvent)
        {
            var ev = _context.Events.FirstOrDefault(e => e.EventId == id);

            if (ev == null)
            {
                return NotFound(new
                {
                    message = "Event Not Found"
                });
            }

            ev.Title = updatedEvent.Title;
            ev.Description = updatedEvent.Description;
            ev.Category = updatedEvent.Category;
            ev.Location = updatedEvent.Location;
            ev.EventDate = updatedEvent.EventDate;

            _context.SaveChanges();

            return Ok(new
            {
                message = "Event Updated Successfully"
            });
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var ev = _context.Events.FirstOrDefault(e => e.EventId == id);

            if (ev == null)
            {
                return NotFound(new
                {
                    message = "Event Not Found"
                });
            }

            _context.Events.Remove(ev);
            _context.SaveChanges();

            return Ok(new
            {
                message = "Event Deleted Successfully"
            });
        }
        [HttpGet("search")]
        public IActionResult SearchEvent(string category)
        {
            var events = _context.Events
                .Where(e => e.Category == category)
                .ToList();

            return Ok(events);
        }
    }
}