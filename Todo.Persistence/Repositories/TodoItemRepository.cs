using Todo.Application.Contracts.Persistence;
using Todo.Domain.Entities;

namespace Todo.Persistence.Repositories
{
    public class TodoItemRepository : BaseRepository<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(TodoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
