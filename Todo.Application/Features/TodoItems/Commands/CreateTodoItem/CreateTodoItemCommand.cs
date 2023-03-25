using MediatR;

namespace Todo.Application.Features.TodoItems.Commands.CreateTodoItem
{
    public class CreateTodoItemCommand : IRequest<Guid>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
