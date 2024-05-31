using Gestor_de_notas.Models;
using System;
using System.Collections.Generic;

namespace NotesApp.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

