using Microsoft.AspNetCore.Mvc;

namespace MovieWizardAPI.Controllers
{
    public class MovieBudgetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
