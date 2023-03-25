using Todo.Domain.Common;

namespace Todo.Domain.Entities
{
    public class TodoItem : AuditableEntity
    {
        public Guid TodoItemId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
