using BL.DTOs.Projects;
using DAL.Models;
using MediatR;

namespace BL.Projects.Commands.AddWorkers;
public class AddWorkersCommand : IRequest<Project>
{
	public AddWorkersDto Dto { get; set; }

	public AddWorkersCommand(AddWorkersDto dto)
	{
		Dto = dto;
	}
}
