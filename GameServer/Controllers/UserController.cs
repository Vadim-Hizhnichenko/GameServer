using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly List<User> _users = new List<User>();

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (_users.Any(u => u.Username == user.Username))
            {
                return BadRequest("Username already exists");
            }

            user.Id = Guid.NewGuid().ToString();
            _users.Add(user);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (existingUser == null)
            {
                return BadRequest("Invalid username or password");
            }

            var player = new Player { UserId = existingUser.Id };
           
            return Ok();
        }
    }
}
