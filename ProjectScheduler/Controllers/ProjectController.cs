using Microsoft.AspNetCore.Mvc;
using BL.DTOs.Projects;
using MediatR;
using BL.Projects.Commands.Delete;
using BL.Projects.Commands.Create;
using BL.Projects.Commands.Update;
using BL.Projects.Queries.GetById;
using BL.Projects.Queries.GetAll;
using BL.Projects.Commands.AddHeadWorker;
using BL.Projects.Commands.AddWorkers;

namespace ProjectScheduler.Controllers;
[ApiController]
[Route("api/projects")]
public class ProjectController : ControllerBase
{
	private readonly IMediator _mediator;

	public ProjectController(IMediator mediator) =>
		_mediator = mediator;

	[HttpPost("create")]
	public async Task<IActionResult> Create([FromForm] CreateProjectDto dto)
	{
		return Ok(await _mediator.Send(new CreateProjectCommand(dto)));
	}
	[HttpDelete("delete")]
	public async Task<IActionResult> Delete([FromRoute] int id)
	{
		return Ok(await _mediator.Send(new DeleteProjectCommand(id)));
	}
	[HttpPut("update")]
	public async Task<IActionResult> Update([FromRoute]int id, [FromForm] UpdateProjectDto dto)
	{
		return Ok(await _mediator.Send(new UpdateProjectCommand(id, dto)));
	}
	[HttpGet("getbyid")]
	public async Task<IActionResult> GetOne([FromRoute]int id)
	{
		return Ok(await _mediator.Send(new GetProjectQuery(id)));
	}
	[HttpGet]
	public async Task<IActionResult> Get([FromQuery] Filters filters, bool? isAsc)
	{
		return Ok(await _mediator.Send(new GetAllProjectsQuery(filters, isAsc)));
	}

	[HttpPost("add-headworker")]
	public async Task<IActionResult> AddWorker([FromBody] AddHeadWorkerDto dto)
	{
		return Ok(await _mediator.Send(new AddWorkerCommand(dto)));
	}
	[HttpPost("add-workers")]
	public async Task<IActionResult> AddWorkers([FromBody] AddWorkersDto dto)
	{
		return Ok(await _mediator.Send(new AddWorkersCommand(dto)));
	}
}
