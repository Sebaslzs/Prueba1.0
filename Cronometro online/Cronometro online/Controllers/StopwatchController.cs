using Microsoft.AspNetCore.Mvc;
using StopwatchApp.Models;

namespace StopwatchApp.Controllers
{
    public class StopwatchController : Controller
    {
        private static StopwatchModel _stopwatch = new StopwatchModel();

        public IActionResult Index()
        {
            return View(_stopwatch);
        }

        [HttpPost]
        public IActionResult Start()
        {
            _stopwatch.Start();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Pause()
        {
            _stopwatch.Pause();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Reset()
        {
            _stopwatch.Reset();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Lap()
        {
            _stopwatch.Lap();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult UpdateElapsedTime()
        {
            _stopwatch.UpdateElapsedTime();
            return Ok(new { elapsedTime = _stopwatch.ElapsedTime.ToString(@"hh\:mm\:ss") });
        }
    }
}
