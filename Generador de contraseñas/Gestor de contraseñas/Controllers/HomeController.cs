using Microsoft.AspNetCore.Mvc;

namespace PasswordGeneratorMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
