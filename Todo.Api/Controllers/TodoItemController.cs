using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        var dtos = await _mediator.Send(new GetTodoItemsListQuery());
        return Ok(dtos);
    }
}