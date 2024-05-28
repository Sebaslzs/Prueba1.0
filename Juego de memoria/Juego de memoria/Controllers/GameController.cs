using Microsoft.AspNetCore.Mvc;
using MemoryGameApp.Models;

namespace MemoryGameApp.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Play(int level)
        {
            // Implementar la lógica para jugar el juego
            return View();
        }

        [HttpPost]
        public IActionResult End(Game game)
        {
            // Implementar la lógica para finalizar el juego
            return RedirectToAction("Index", "Home");
        }
    }
}
