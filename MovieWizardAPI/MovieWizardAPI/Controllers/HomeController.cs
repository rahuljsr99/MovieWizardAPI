using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieWizardAPI.Models;
using System.Diagnostics;

namespace MovieWizardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        [HttpGet]
        //[Authorize]
        public IActionResult HelloWorld() { 
            return Content("Hello, World!"); 
        }
    }
}