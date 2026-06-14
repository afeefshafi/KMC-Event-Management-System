using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using KMCEventManagement.Data;
using KMCEventManagement.Models;


namespace KMCEventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new
            {
                message = "User Registered Successfully"
            });
        }
        [HttpPost("login")]
        public IActionResult Login(LoginModel login)
        {
            var user = _context.Users.FirstOrDefault(u =>
                u.Email == login.Email &&
                u.Password == login.Password);

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid Email or Password"
                });
            }

            return Ok(new
            {
                message = "Login Successful",
                user.UserId,
                user.FullName,
                user.Email,
                user.Role
            });
        }
    }
}
