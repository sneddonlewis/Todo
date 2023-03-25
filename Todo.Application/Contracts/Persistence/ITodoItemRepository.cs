using Todo.Domain.Entities;

namespace Todo.Application.Contracts.Persistence
{
    public interface ITodoItemRepository : IAsyncRepository<TodoItem>
    {
    }
}
