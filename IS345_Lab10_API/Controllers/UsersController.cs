using Microsoft.AspNetCore.Mvc;
using IS345_Lab10_API.Models;

namespace IS345_Lab10_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // POST api/Users/login
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(u =>
                u.Username == request.Username && u.Userpass == request.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Wrong username or password" });
            }

            return Ok(new { message = "Login successful", username = user.Username });
        }
    }
}
