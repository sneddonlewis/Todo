using MediatR;

namespace Todo.Application.Features.TodoItems.Queries.GetTodoItemDetail
{
    public class GetTodoItemDetailQuery : IRequest<TodoItemDetailVm>
    {
        public Guid Id { get; set; }
    }
}
