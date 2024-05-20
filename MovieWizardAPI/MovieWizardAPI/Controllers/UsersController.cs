using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWizardAPI.Data;
using MovieWizardAPI.Models;

namespace MovieWizardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersDbContext _usersDbContext;
        public UsersController(UsersDbContext usersDbContext)
        {
            _usersDbContext = usersDbContext;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
        {
            var users = await _usersDbContext.Users.ToListAsync();
            return Ok(users);
        }
        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser(Users user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            
            _usersDbContext.Users.Add(user);
            await _usersDbContext.SaveChangesAsync();//asynchronously saves changes to the database. It returns the number of state entries written to the database
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, new { message = "User created successfully", userId = user.UserId });
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<ActionResult<Users>> GetUserById(int id)
        {
            var user = await _usersDbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}
