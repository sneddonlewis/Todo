namespace Todo.Application.Features.TodoItems
{
    public class TodoItemDetailVm
    {
        public Guid TodoItemId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
