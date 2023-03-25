using AutoMapper;
using Todo.Application.Features.TodoItems.Commands.CreateTodoItem;
using Todo.Application.Features.TodoItems.Commands.DeleteTodoItem;
using Todo.Application.Features.TodoItems.Commands.UpdateTodoItem;
using Todo.Application.Features.TodoItems.Queries.GetTodoItemDetail;
using Todo.Application.Features.TodoItems.Queries.GetTodoItemsList;
using Todo.Domain.Entities;

namespace Todo.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoItem, TodoItemListVm>()
                .ReverseMap();
            CreateMap<TodoItem, TodoItemDetailVm>()
                .ReverseMap();
            CreateMap<TodoItem, CreateTodoItemCommand>()
                .ReverseMap();
            CreateMap<TodoItem, UpdateTodoItemCommand>()
                .ReverseMap();
            CreateMap<TodoItem, DeleteTodoItemCommand>()
                .ReverseMap();
        }
    }
}
