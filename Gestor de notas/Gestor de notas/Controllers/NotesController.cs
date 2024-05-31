using Microsoft.AspNetCore.Mvc;
using NotesApp.Models;
using NotesApp.Services;

namespace NotesApp.Controllers
{
    public class NotesController : Controller
    {
        private readonly NotesService _notesService;

        public NotesController()
        {
            _notesService = new NotesService();
        }

        public IActionResult Index()
        {
            var notes = _notesService.GetAllNotes();
            return View(notes);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _notesService.GetAllCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                _notesService.AddNote(note);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _notesService.GetAllCategories();
            return View(note);
        }

        public IActionResult Edit(int id)
        {
            var note = _notesService.GetNoteById(id);
            if (note == null)
            {
                return NotFound();
            }
            ViewBag.Categories = _notesService.GetAllCategories();
            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note note)
        {
            if (ModelState.IsValid)
            {
                _notesService.UpdateNote(note);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _notesService.GetAllCategories();
            return View(note);
        }

        public IActionResult Delete(int id)
        {
            var note = _notesService.GetNoteById(id);
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _notesService.DeleteNoteById(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var note = _notesService.GetNoteById(id);
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }
    }
}
