using MediatR;

namespace BL.Projects.Commands.Delete;
public class DeleteProjectCommand : IRequest<Unit>
{
	public int Id { get; set; }
	public DeleteProjectCommand(int id)
	{
		Id = id;
	}
}
