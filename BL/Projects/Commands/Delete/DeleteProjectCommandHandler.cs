using DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BL.Projects.Commands.Delete;
public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
{
	private readonly ApplicationDbContext _db;

	public DeleteProjectCommandHandler(ApplicationDbContext db)
	{
		_db = db;
	}

	public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
	{
		if (request == null)
			throw new NullReferenceException(nameof(request));

		var project = await _db.Projects.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) 
			?? throw new NullReferenceException("There isn't project with this Id");

		_db.Remove(project);
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
