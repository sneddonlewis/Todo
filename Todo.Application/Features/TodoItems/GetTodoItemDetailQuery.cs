using MediatR;

namespace Todo.Application.Features.TodoItems
{
    public class GetTodoItemDetailQuery : IRequest<TodoItemDetailVm>
    {
        public Guid Id { get; set; }
    }
}
