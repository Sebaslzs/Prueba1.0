// Models/TodoTask.cs
using System.ComponentModel.DataAnnotations;

namespace MyTodoApp.Models
{
    public class TodoTask
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
