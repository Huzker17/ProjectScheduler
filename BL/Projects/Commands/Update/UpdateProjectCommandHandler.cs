using BL.Utils;
using DAL;
using DAL.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BL.Projects.Commands.Update;
public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Project>
{
	private readonly ApplicationDbContext _db;

	public UpdateProjectCommandHandler(ApplicationDbContext db)
	{
		_db = db;
	}

	public async Task<Project> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
	{
		if(request == null) 
			throw new ArgumentNullException(nameof(request));

		var project = await _db.Projects.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken)
			                 ?? throw new NullReferenceException("There isn't project with this Id");

		var updatedProject = request.Dto.ProjectFromDto(project);
		_db.Projects.Update(updatedProject);
		await _db.SaveChangesAsync(cancellationToken);
		return updatedProject;
	}
}
