using Microsoft.AspNetCore.Mvc;

namespace StopwatchApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
