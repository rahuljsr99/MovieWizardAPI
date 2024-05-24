using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWizardAPI.Data;
using MovieWizardAPI.Models;
using MovieWizardAPI.RequestModels;
using System.Linq.Expressions;
using System.Reflection.Metadata;

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
        [HttpPost("Authenticate")]
        public  async Task<ActionResult> Authenticate(LoginRequestModel login)
        {
            
            var users =  GetUser(login);

            if (users != null)
            {
                // If user is found and credentials match, return success response
                return new JsonResult(new { success = true, message = "Login successful" });
            }
            else
            {
                // If no matching user is found, return failure response
                return BadRequest("Invalid credentials");
            }
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
        public async Task<ActionResult> ModifyPermissions([FromBody]ModifyPermissionsRequestModel request)
        {
            if(request == null)
            {
                return BadRequest("Request is null");
            }
            var currentUser = await _usersDbContext.Users.FindAsync(request.currentUserId);
            var userRecord = await _usersDbContext.Users.FindAsync(request.changeRequestUserId);

            //CurrentUser checks
            if(currentUser == null)
            {
                return BadRequest("Current User is null");
            }
            if (currentUser != null)
            {
                if (!currentUser.IsActive)
                {
                    return BadRequest("User Inactive");
                }
                else
                {
                    if(!currentUser.IsAdmin)
                    {
                        return BadRequest("You don't have Admin privileges");
                    }
                }
            }


            //UserRecord checks

            if (userRecord == null)
            {
                return BadRequest($"Record doesn't exists!");
                
            }
            else
            {
                //Administrator section
                if (request.permissionChangeRequestType.Equals("Admin"))
                {
                    if (request.permissionChangeRequestValue)
                    {
                        if (userRecord.IsAdmin)
                        {
                            return BadRequest($"{userRecord.UserName}. is already an Administrator.");
                        }
                        else
                        {
                            userRecord.IsAdmin = true;
                            await _usersDbContext.SaveChangesAsync();
                            return Ok(new { message = $"{userRecord.UserName} has been granted Administrator priviledges." });
                        }
                    }
                    else
                    {
                        if (!userRecord.IsAdmin)
                        {
                            return BadRequest($"{userRecord.UserName} isn't an Administrator already.");
                        }
                        else
                        {
                            userRecord.IsAdmin = false;
                            await _usersDbContext.SaveChangesAsync();
                            return Ok(new { message = $"{userRecord.UserName}'s Adminsitrator priviledges revoked." });
                        }
                    }

                }
                //Activate/Deactivate
                else if (request.permissionChangeRequestType.Equals("Activate"))
                {
                    if (!request.permissionChangeRequestValue)
                    {
                        if (!userRecord.IsActive)
                        {
                            return BadRequest($"{userRecord.UserName} is already inactive");
                        }
                        else
                        {
                            userRecord.IsActive = false;
                            await _usersDbContext.SaveChangesAsync();
                            return Ok(new { message = $"{userRecord.UserName} is now Deactivated." });
                        }
                    }
                    else
                    {
                        if (userRecord.IsActive)
                        {
                            return BadRequest($"{userRecord.UserName} is already Active.");
                        }
                        else
                        {
                            userRecord.IsActive = true;
                            await _usersDbContext.SaveChangesAsync();
                            return Ok(new { message = $"{userRecord.UserName} is Activated" });
                        }
                    }
                }
            }
                    return Ok(new { message = "Operation Complete for UserId ", userId = userRecord.UserId });
        }
        public Users GetUser (LoginRequestModel user)
        {
            String userName=user.userName;
            String password=user.password;
            return _usersDbContext.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password && u.IsActive);
        }
        public Users GetUser (LoginRequestModel user)
        {
            String userName=user.userName;
            String password=user.password;
            return _usersDbContext.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password && u.IsActive);
        }
    }
}
