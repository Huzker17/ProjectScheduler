using DAL;
using DAL.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BL.Projects.Commands.AddHeadWorker;
public class AddWorkerCommandHandler : IRequestHandler<AddWorkerCommand, Project>
{
	private readonly ApplicationDbContext _db;

	public AddWorkerCommandHandler(ApplicationDbContext db)
	{
		_db = db;
	}

	public async Task<Project> Handle(AddWorkerCommand request, CancellationToken cancellationToken)
	{
		if (request == null)
			throw new ArgumentNullException(nameof(request));

		var project = await _db.Projects.FirstOrDefaultAsync(x => x.Id == request.Dto.ProjectId,cancellationToken)
			?? throw new NullReferenceException("There isn't any project");

		project.HeadWorker = request.Dto.User;
		_db.Update(project);
		await _db.SaveChangesAsync(cancellationToken);
		throw new NotImplementedException();
	}
}
