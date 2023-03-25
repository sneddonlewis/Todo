namespace Todo.Application.Features.TodoItems.Queries.GetTodoItemsList
{
    public class TodoItemListVm
    {
        public Guid TodoItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
