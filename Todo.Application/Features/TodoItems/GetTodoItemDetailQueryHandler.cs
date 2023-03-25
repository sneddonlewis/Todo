using AutoMapper;
using MediatR;
using Todo.Application.Contracts.Persistence;

namespace Todo.Application.Features.TodoItems
{
    public class GetTodoItemDetailQueryHandler :
        IRequestHandler<GetTodoItemDetailQuery, TodoItemDetailVm>
    {
        private readonly ITodoItemRepository _todoRepository;
        private readonly IMapper _mapper;

        public GetTodoItemDetailQueryHandler(ITodoItemRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }


        public async Task<TodoItemDetailVm> Handle(GetTodoItemDetailQuery request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.GetByIdAsync(request.Id);
            return _mapper.Map<TodoItemDetailVm>(todo);
        }
    }
}
