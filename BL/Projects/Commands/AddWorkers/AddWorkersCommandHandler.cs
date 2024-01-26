using DAL;
using DAL.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BL.Projects.Commands.AddWorkers;
public class AddWorkersCommandHandler : IRequestHandler<AddWorkersCommand, Project>
{
	private readonly ApplicationDbContext _db;

	public AddWorkersCommandHandler(ApplicationDbContext db)
	{
		_db = db;
	}

	public async Task<Project> Handle(AddWorkersCommand request, CancellationToken cancellationToken)
	{
		if(request == null) 
			throw new ArgumentNullException(nameof(request));
		var project = await _db.Projects.FirstOrDefaultAsync(x => x.Id == request.Dto.ProjectId, cancellationToken)
			?? throw new NullReferenceException("There isn't any project");

		foreach (var worker in request.Dto.Workers)
		{
			project.Workers.Append(worker);
		}

		_db.Update(project);
		await _db.SaveChangesAsync(cancellationToken);
		return project;
	}
}
