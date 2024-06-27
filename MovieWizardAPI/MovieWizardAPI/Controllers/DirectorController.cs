using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWizardAPI.Data;
using MovieWizardAPI.Models;
using MovieWizardAPI.RequestModels;
using System.Linq.Expressions;

namespace MovieWizardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DirectorController : Controller
    {
        private readonly DirectorDbContext _dbContext;
        public DirectorController(DirectorDbContext directorDbContext) {
        
            _dbContext = directorDbContext;
        }
        [HttpGet("GetAllDirectors")]
        public async Task<ActionResult<IEnumerable<Director>>> GetAllDirectors()
        {
            try
            {
                var directors = await _dbContext.Directors.ToListAsync();
                return Ok(directors);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("GetDirectorById")]
        public async Task<ActionResult<Director>> GetDirectorById(int id)
        {
            try
            {
                var director = await _dbContext.Directors.FindAsync(id);

                if (director == null)
                {
                    return NotFound();
                }

                return Ok(director);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("AddDirector")]
        public async Task<ActionResult<Director>> AddDirector(Director director)
        {
            try
            {
                _dbContext.Directors.Add(director);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetDirectorById), new { id = director.DirectorId }, director);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
