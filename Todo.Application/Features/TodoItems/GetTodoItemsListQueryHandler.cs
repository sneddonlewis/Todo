using AutoMapper;
using MediatR;
using Todo.Application.Contracts.Persistence;

namespace Todo.Application.Features.TodoItems
{
    public class GetTodoItemsListQueryHandler :
        IRequestHandler<GetTodoItemsListQuery, List<TodoItemListVm>>
    {
        private readonly ITodoItemRepository _todoRepository;
        private readonly IMapper _mapper;

        public GetTodoItemsListQueryHandler(ITodoItemRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }


        public async Task<List<TodoItemListVm>> Handle(GetTodoItemsListQuery request, CancellationToken cancellationToken)
        {
            var allTodos = (await _todoRepository.ListAllAsync())
                .OrderBy(todo => todo.CreatedOn);
            return _mapper.Map<List<TodoItemListVm>>(allTodos);
        }
    }
}
