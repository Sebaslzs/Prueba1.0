using MyTodoApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyTodoApp.Services
{
    public class TaskService
    {
        private readonly List<TodoTask> _tasks = new List<TodoTask>();
        private int _nextId = 1;

        public List<TodoTask> GetAll() => _tasks;

        public TodoTask Get(int id) => _tasks.FirstOrDefault(t => t.Id == id);

        public void Add(TodoTask task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
        }

        public void Update(TodoTask task)
        {
            var existingTask = Get(task.Id);
            if (existingTask != null)
            {
                existingTask.Description = task.Description;
                existingTask.IsCompleted = task.IsCompleted;
            }
        }

        public void Delete(int id)
        {
            var task = Get(id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }
    }
}
