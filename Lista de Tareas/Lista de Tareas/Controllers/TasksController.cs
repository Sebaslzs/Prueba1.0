using Microsoft.AspNetCore.Mvc;
using MyTodoApp.Models;
using MyTodoApp.Services;

namespace MyTodoApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: Tasks
        public IActionResult Index()
        {
            return View(_taskService.GetAll());
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Description,IsCompleted")] TodoTask todoTask)
        {
            if (ModelState.IsValid)
            {
                _taskService.Add(todoTask);
                return RedirectToAction(nameof(Index));
            }
            return View(todoTask);
        }

        // GET: Tasks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _taskService.Get(id.Value);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Description,IsCompleted")] TodoTask todoTask)
        {
            if (id != todoTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _taskService.Update(todoTask);
                return RedirectToAction(nameof(Index));
            }
            return View(todoTask);
        }

        // GET: Tasks/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _taskService.Get(id.Value);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _taskService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
