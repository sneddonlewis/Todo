using FluentValidation;

namespace Todo.Application.Features.TodoItems.Commands.CreateTodoItem;

public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
{
    public CreateTodoItemCommandValidator()
    {
        RuleFor(item => item.Title)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull();
        
        RuleFor(item => item.Description)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull();
    }
}