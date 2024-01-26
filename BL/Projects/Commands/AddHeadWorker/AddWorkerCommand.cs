using BL.DTOs.Projects;
using DAL.Models;
using MediatR;

namespace BL.Projects.Commands.AddHeadWorker;
public class AddWorkerCommand : IRequest<Project>
{
	public AddHeadWorkerDto Dto { get; set; }

	public AddWorkerCommand(AddHeadWorkerDto dto)
	{
		Dto = dto;
	}
}
