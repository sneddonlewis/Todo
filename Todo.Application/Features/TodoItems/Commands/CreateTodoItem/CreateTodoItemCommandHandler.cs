using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Todo.Application.Contracts.Persistence;
using Todo.Application.Exceptions;
using Todo.Domain.Entities;

namespace Todo.Application.Features.TodoItems.Commands.CreateTodoItem;

public class CreateTodoItemCommandHandler:
    IRequestHandler<CreateTodoItemCommand, Guid>
{
    private readonly ITodoItemRepository _todoItemRepository;
    private readonly IMapper _mapper;

    public CreateTodoItemCommandHandler(ITodoItemRepository todoItemRepository, IMapper mapper)
    {
        _todoItemRepository = todoItemRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateTodoItemCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }
        
        var todo = _mapper.Map<TodoItem>(request);
        todo = await _todoItemRepository.AddAsync(todo);
        return todo.TodoItemId;
    }
}