using AutoMapper;
using MediatR;
using Todo.Application.Contracts.Persistence;
using Todo.Domain.Entities;

namespace Todo.Application.Features.TodoItems.Commands.UpdateTodoItem;

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
{
    private readonly ITodoItemRepository _todoRepository;
    private readonly IMapper _mapper;

    public UpdateTodoItemCommandHandler(ITodoItemRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var todoToUpdate = await _todoRepository.GetByIdAsync(request.TodoItemId);
        _mapper.Map(request, todoToUpdate, typeof(UpdateTodoItemCommand), typeof(TodoItem));
        await _todoRepository.UpdateAsync(todoToUpdate);
    }
}