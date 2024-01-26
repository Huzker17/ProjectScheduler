using BL.DTOs.Users;
using BL.Users.Commands.Create;
using BL.Users.Commands.Delete;
using BL.Users.Commands.Update;
using BL.Users.Queries.GetAll;
using BL.Users.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProjectScheduler.Controllers;
[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
	private readonly IMediator _mediator;
	public UserController(IMediator mediator) =>
		_mediator = mediator;

	[HttpPost("create")]
	public async Task<IActionResult> Create([FromForm] CreateUserDto dto)
	{
		return Ok(await _mediator.Send(new CreateUserCommand(dto)));
	}
	[HttpDelete("delete")]
	public async Task<IActionResult> Delete([FromRoute] int id)
	{
		return Ok(await _mediator.Send(new DeleteUserCommand(id)));
	}
	[HttpPut("update")]
	public async Task<IActionResult> Update([FromRoute] int id, [FromForm] UpdateUserDto dto)
	{
		return Ok(await _mediator.Send(new UpdateUserCommand(id, dto)));
	}
	[HttpGet("getbyid")]
	public async Task<IActionResult> GetOne([FromRoute] int id)
	{
		return Ok(await _mediator.Send(new GetUserByIdQuery(id)));
	}
	[HttpGet]
	public async Task<IActionResult> Get([FromQuery] bool? isAsc)
	{
		return Ok(await _mediator.Send(new GetAllUserQuery(isAsc)));
	}
}
