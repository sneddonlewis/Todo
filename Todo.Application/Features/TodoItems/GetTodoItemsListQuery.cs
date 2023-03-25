using MediatR;

namespace Todo.Application.Features.TodoItems
{
    public class GetTodoItemsListQuery : IRequest<List<TodoItemListVm>>
    {
    }
}
