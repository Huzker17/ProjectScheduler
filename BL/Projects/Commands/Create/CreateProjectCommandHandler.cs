using DAL;
using DAL.Models;
using MediatR;

namespace BL.Projects.Commands.Create;
public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Project>
{
	private readonly ApplicationDbContext _db;

	public CreateProjectCommandHandler(ApplicationDbContext db)
	{
		_db = db;
	}

	public async Task<Project> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
	{
		if (request == null)
			throw new NullReferenceException(nameof(request));

		var project = new Project(request.Dto.Name, request.Dto.Customer, request.Dto.Executor, request.Dto.EndDate, request.Dto.Priority);
		
		await _db.AddAsync(project,cancellationToken);
		await _db.SaveChangesAsync(cancellationToken);
		return project;	
	}
}
