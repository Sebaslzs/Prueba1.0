using System.Collections.Generic;
using System.Linq;
using NotesApp.Models;

namespace NotesApp.Services
{
    public class NotesService
    {
        private readonly List<Note> _notes;
        private readonly List<Category> _categories;

        public NotesService()
        {
            _categories = new List<Category>
            {
                new Category { Id = 1, Name = "Personal" },
                new Category { Id = 2, Name = "Work" },
                new Category { Id = 3, Name = "Others" }
            };

            _notes = new List<Note>();
        }

        public List<Note> GetAllNotes() => _notes;

        public Note GetNoteById(int id) => _notes.FirstOrDefault(n => n.Id == id);

        public void AddNote(Note note)
        {
            note.Id = _notes.Count + 1;
            _notes.Add(note);
        }

        public void UpdateNote(Note note)
        {
            var existingNote = GetNoteById(note.Id);
            if (existingNote != null)
            {
                existingNote.Title = note.Title;
                existingNote.Content = note.Content;
                existingNote.CategoryId = note.CategoryId;
            }
        }

        public void DeleteNoteById(int id)
        {
            var note = GetNoteById(id);
            if (note != null)
            {
                _notes.Remove(note);
            }
        }

        public List<Category> GetAllCategories() => _categories;
    }
}
