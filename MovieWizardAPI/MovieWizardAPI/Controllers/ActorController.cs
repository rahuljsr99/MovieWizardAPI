using Microsoft.AspNetCore.Mvc;

namespace MovieWizardAPI.Controllers
{
    public class ActorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
