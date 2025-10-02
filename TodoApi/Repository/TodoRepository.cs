using TodoApi.Model;

namespace TodoApi.Repository
{
    public class TodoRepository
    {
        private readonly List<TodoItem> _items = new()
            {
        new TodoItem { Id = 1, Title = "Buy groceries" },
        new TodoItem { Id = 2, Title = "Walk the dog" },
        new TodoItem { Id = 3, Title = "Read a book" }
    };
        private int _nextId = 1;

        public IEnumerable<TodoItem> GetAll() => _items;
        public TodoItem Add(string title)
        {
            var item = new TodoItem { Id = _nextId++, Title = title };
            _items.Add(item);
            return item;
        }
        public bool Delete(int id)
        {
            var item = _items.FirstOrDefault(t => t.Id == id);
            if (item == null) return false;
            _items.Remove(item);
            return true;
        }
    }
}
