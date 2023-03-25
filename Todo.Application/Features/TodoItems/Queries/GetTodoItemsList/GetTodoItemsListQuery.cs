using MediatR;

namespace Todo.Application.Features.TodoItems.Queries.GetTodoItemsList
{
    public class GetTodoItemsListQuery : IRequest<List<TodoItemListVm>>
    {
    }
}
