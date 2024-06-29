using Microsoft.AspNetCore.Mvc;

namespace MovieWizardAPI.Controllers
{
    public class MovieRevenueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
