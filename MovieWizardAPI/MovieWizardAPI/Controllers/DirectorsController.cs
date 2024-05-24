using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieWizardAPI.Data;

using MovieWizardAPI.ServiceImpl;
using System.Security.Cryptography.X509Certificates;

namespace MovieWizardAPI.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {

        public DirectorsDbContext DContext;
        public DirectorsController(DirectorsDbContext DContext)
        {
            this.DContext = DContext;
        }

        [HttpGet]
        [Route("GetDirector")]

        public List<Directors> GetDirector()
        {
            IDirectors Directors = new GetImplementation();

            return Directors.getDirector(DContext);
        }
    }
}

