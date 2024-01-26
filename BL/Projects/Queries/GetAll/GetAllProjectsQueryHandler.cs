using BL.Utils;
using DAL;
using DAL.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BL.Projects.Queries.GetAll;
public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<Project>>
{
	private readonly ApplicationDbContext _db;

	public GetAllProjectsQueryHandler(ApplicationDbContext db)
	{
		_db = db;
	}

	public async Task<IEnumerable<Project>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
	{
		if(request == null) 
			throw new ArgumentNullException(nameof(request));

		///Здесь по идее можно по-любому полю делать, но я выбрал название.
		var projects = await _db.Projects.SortRows(x => x.Name,request.IsAsc).ApplyFilter(request.Filters).ToListAsync(cancellationToken)
				?? throw new NullReferenceException("There isn't any projects");

		return projects;
	}
}
