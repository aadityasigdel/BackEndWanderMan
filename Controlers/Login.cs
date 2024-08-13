using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewProject.Data;
using NewProject.DTO.LoginDTO;
using NewProject.Models;
using BCrypt.Net;
using System.Linq;
using System.Threading.Tasks;

namespace NewProject.Controllers
{
    [Route("NewProject/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: NewProject/Login (For Login)
        [HttpPost("Login")]
        

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateLogin createLoginDto)
        {
            if (await _context.Users.AnyAsync(u => u.UserName == createLoginDto.UserName))
            {
                return BadRequest("Username already exists.");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(createLoginDto.Password);

            var newUser = new LoginC
            {
                UserName = createLoginDto.UserName,
                Email = createLoginDto.Email,
                Password = hashedPassword
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateLogin updateLoginDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            user.UserName = updateLoginDto.UserName ?? user.UserName;
            user.Email = updateLoginDto.Email ?? user.Email;

            if (!string.IsNullOrEmpty(updateLoginDto.Password))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(updateLoginDto.Password);
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok("User updated successfully.");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: NewProject/Login/{id} (For Retrieving a User by ID)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }
    }
}
