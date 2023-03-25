
using FluentValidation.Results;

namespace Todo.Application.Exceptions;

public class ValidationException : Exception
{
    public List<string> ValidationErrors { get; }
    public ValidationException(ValidationResult validationResult)
    {
        ValidationErrors = validationResult.Errors
            .Select(e => e.ErrorMessage)
            .ToList();
    }
}