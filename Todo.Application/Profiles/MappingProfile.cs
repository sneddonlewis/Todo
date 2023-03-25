using AutoMapper;
using Todo.Application.Features.TodoItems.Queries;
using Todo.Application.Features.TodoItems.Queries.GetTodoItemDetail;
using Todo.Domain.Entities;

namespace Todo.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoItem, TodoItemListVm>().ReverseMap();
            CreateMap<TodoItem, TodoItemDetailVm>().ReverseMap();
        }
    }
}
