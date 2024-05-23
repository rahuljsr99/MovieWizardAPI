using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieWizardAPI.Data;
using MovieWizardAPI.Entities;
using MovieWizardAPI.ServiceImpl;
using System.Security.Cryptography.X509Certificates;

namespace MovieWizardAPI.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        public MovieContext movieContext;
        public MoviesController(MovieContext movieContext)
        {
            this.movieContext = movieContext;
        }

         [HttpGet]
        //[Route("GetMovie")]
      
            public List<Movies> GetMovie()
            {
            Imovies movies = new GetImplementation();
            
            return movies.getMovies(movieContext); 
            } 
    }
}

