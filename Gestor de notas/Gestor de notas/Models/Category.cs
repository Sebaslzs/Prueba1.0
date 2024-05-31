using System.Collections.Generic;

namespace NotesApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
