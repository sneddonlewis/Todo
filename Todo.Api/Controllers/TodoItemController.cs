using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Features.TodoItems.Commands.CreateTodoItem;
using Todo.Application.Features.TodoItems.Commands.DeleteTodoItem;
using Todo.Application.Features.TodoItems.Commands.UpdateTodoItem;
using Todo.Application.Features.TodoItems.Queries.GetTodoItemsList;

namespace Todo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodoItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all", Name = "GetAllTodos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<TodoItemListVm>>> GetAllTodos()
    {
        var dtoList = await _mediator.Send(new GetTodoItemsListQuery());
        return Ok(dtoList);
    }

    [HttpPost(Name = "AddTodo")]
    public async Task<ActionResult<Guid>> Create(
        [FromBody] CreateTodoItemCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    
    [HttpPut(Name = "UpdateTodo")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update([FromBody] UpdateTodoItemCommand request)
    {
        await _mediator.Send(request);
        return NoContent();
    }
    
    [HttpDelete("{id}", Name = "DeleteTodo")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        var deleteCommand = new DeleteTodoItemCommand { TodoItemId = id };
        await _mediator.Send(deleteCommand);
        return NoContent();
    }
}