using BL.DTOs.Projects;
using DAL.Models;

namespace BL.Utils;
internal static class Map
{
	internal static Project ProjectFromDto(this UpdateProjectDto dto, Project project)
	{
		project.Priority = dto.Priority;
		project.Name = dto.Name;
		project.HeadWorker	= dto.HeadWorker;
		project.Workers = dto.Workers;
		project.Customer = dto.Customer;
		project.Executor = dto.Executor;
		project.EndDate = dto.EndDate;
		return project;
	}
}
