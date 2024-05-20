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
        [HttpGet("GetUserById")]
        public async Task<ActionResult<Users>> GetUserById(int id)
        {
            var user = await _usersDbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
        [HttpDelete("HardDeleteUser/{id}")]
        public async Task<ActionResult> HardDeleteUser(int id)
        {
            var user = await _usersDbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var deletedUser = new
            {
                UserName = user.UserName,
                UserId = user.UserId,
                Email = user.Email
            };

            _usersDbContext.Users.Remove(user);
            await _usersDbContext.SaveChangesAsync();

            return Ok(new { message = "User deleted successfully", deletedUser });
        }
        [HttpPost("ModifyPermissions")]//to be analyzed and completed (scope: change permissions)
        public async Task<ActionResult> ModifyPermissions([FromBody]Users user)
        {
            var userRecord = await _usersDbContext.Users.FindAsync(user.UserId);

            if (userRecord == null)
            {
                return NotFound();
            }
            else if(!userRecord.IsActive)
            {
                return Ok(new { message = "User is already inactive", userId = userRecord.UserId });

            }
            userRecord.IsActive = false; // Deactivated by setting IsActive to false
            await _usersDbContext.SaveChangesAsync();

            return Ok(new { message = "User deactivated successfully", userId = userRecord.UserId });
        }
    }
}
