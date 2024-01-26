using DAL.Models;
using MediatR;

namespace BL.Projects.Queries.GetById;
public class GetProjectQuery : IRequest<Project>
{
	public int Id { get; set; }

	public GetProjectQuery(int id)
	{
		Id = id;
	}
}
