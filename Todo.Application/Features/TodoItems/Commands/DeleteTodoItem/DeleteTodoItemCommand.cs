using MediatR;

namespace Todo.Application.Features.TodoItems.Commands.DeleteTodoItem;

public class DeleteTodoItemCommand : IRequest
{
    public Guid TodoItemId { get; set; }
}