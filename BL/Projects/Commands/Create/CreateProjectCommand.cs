using BL.DTOs.Projects;
using DAL.Models;
using MediatR;

namespace BL.Projects.Commands.Create;
public class CreateProjectCommand : IRequest<Project>
{
	public CreateProjectDto Dto { get; set; }
	public CreateProjectCommand(CreateProjectDto dto)
	{
		Dto = dto;
	}
}
