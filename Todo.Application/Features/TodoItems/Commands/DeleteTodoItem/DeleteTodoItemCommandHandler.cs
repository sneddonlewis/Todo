using AutoMapper;
using MediatR;
using Todo.Application.Contracts.Persistence;

namespace Todo.Application.Features.TodoItems.Commands.DeleteTodoItem;

public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
{
    private readonly ITodoItemRepository _todoItemRepository;
    private readonly IMapper _mapper;

    public DeleteTodoItemCommandHandler(ITodoItemRepository todoItemRepository, IMapper mapper)
    {
        _todoItemRepository = todoItemRepository;
        _mapper = mapper;
    }

    public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var todoToDelete = await _todoItemRepository.GetByIdAsync(request.TodoItemId);
        await _todoItemRepository.DeleteAsync(todoToDelete);
    }
}