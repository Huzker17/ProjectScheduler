using BL.DTOs.Projects;
using DAL.Models;
using MediatR;

namespace BL.Projects.Commands.Update;
public class UpdateProjectCommand : IRequest<Project>
{
	public int Id { get; set; }	
	public UpdateProjectDto Dto { get; set; }
	public UpdateProjectCommand(int id, UpdateProjectDto dto)
	{
		Id = id;
		Dto = dto;
	}
}
