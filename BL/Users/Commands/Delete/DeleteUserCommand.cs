using MediatR;

namespace BL.Users.Commands.Delete;
public class DeleteUserCommand : IRequest<Unit>
{
	public int Id { get; set; }
	public DeleteUserCommand(int id)
	{
		Id = id;
	}
}
