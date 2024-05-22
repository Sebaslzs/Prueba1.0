using Microsoft.AspNetCore.Mvc;
using TipCalculator.Models;

namespace TipCalculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new TipCalculatorModel());
        }

        [HttpPost]
        public IActionResult CalculateTip(TipCalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                return View("Result", model);
            }
            return View("Index", model);
        }
    }
}
