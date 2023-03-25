using MediatR;

namespace Todo.Application.Features.TodoItems.Commands.UpdateTodoItem;

public class UpdateTodoItemCommand : IRequest
{
        public Guid TodoItemId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
}