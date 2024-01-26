using BL.DTOs.Projects;
using DAL.Models;
using MediatR;


namespace BL.Projects.Queries.GetAll;
public class GetAllProjectsQuery : IRequest<IEnumerable<Project>>
{
	public Filters Filters { get; set; }
	public bool? IsAsc { get; set; }
	public GetAllProjectsQuery(Filters filters, bool? isAsc)
	{
		Filters = filters;
		IsAsc = isAsc;
	}
}
