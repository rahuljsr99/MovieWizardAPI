using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWizardAPI.Data;
using MovieWizardAPI.Models;

namespace MovieWizardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly MovieDbContext _movieDbContext;
        
        public MoviesController(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        [HttpGet("GetAllMovies")]
        public async Task<ActionResult<IEnumerable<MovieModel>>> GetMovies()
        {
            try
            {
                var movies = await _movieDbContext.Movies
                    .Include(m => m.Director)
                    .Include(m => m.MovieBudget)
                    .Include(m => m.MoviePrice)
                    .Include(m => m.MovieRevenue)
                    .Include(m => m.Actors)
                    .ToListAsync();

                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetMovieById")]
        public async Task<ActionResult<MovieModel>> GetMovieById(int id)
        {
            try
            {
                var movie = await _movieDbContext.Movies
                    .Include(m => m.Director)
                    .Include(m => m.MovieBudget)
                    .Include(m => m.MoviePrice)
                    .Include(m => m.MovieRevenue)
                    .Include(m => m.Actors)
                    .FirstOrDefaultAsync(m => m.MovieId == id);

                if (movie == null)
                {
                    return NotFound();
                }

                return Ok(movie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost("AddMovie")]
        public async Task<ActionResult<MovieModel>> AddMovie([FromBody] MovieModel movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _movieDbContext.Movies.Add(movie);
                await _movieDbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetMovieById), new { id = movie.MovieId }, movie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("UpdateMovie")]
        public async Task<IActionResult> UpdateMovie([FromBody] MovieModel movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _movieDbContext.Entry(movie).State = EntityState.Modified;
                await _movieDbContext.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(movie.MovieId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        private bool MovieExists(int id)
        {
            return _movieDbContext.Movies.Any(m => m.MovieId == id);
        }
    }
}
