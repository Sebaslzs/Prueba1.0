using Microsoft.AspNetCore.Mvc;
using MemoryGame.Models;
using Juego_de_memoria.Models;

namespace MemoryGame.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Play(int level = 1)
        {
            var game = new Game(level);
            return View(game);
        }
    }
}
