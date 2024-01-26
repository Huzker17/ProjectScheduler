using DAL;
using DAL.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BL.Projects.Queries.GetById;
public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, Project>
{
	private readonly ApplicationDbContext _db;

	public GetProjectQueryHandler(ApplicationDbContext db)
	{
		_db = db;
	}

	public async Task<Project> Handle(GetProjectQuery request, CancellationToken cancellationToken)
	{
		if (request == null)
			throw new ArgumentNullException(nameof(request));

		var project = await _db.Projects.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
								?? throw new NullReferenceException("There isn't any project with this id");

		return project;
	}
}
