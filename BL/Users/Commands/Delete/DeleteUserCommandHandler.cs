using DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace BL.Users.Commands.Delete;
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
	private readonly ApplicationDbContext _db;

	public DeleteUserCommandHandler(ApplicationDbContext db)
	{
		_db = db;
	}

	public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
	{
		if (request == null) 
			throw new ArgumentNullException(nameof(request));

		var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken) 
													?? throw new NullReferenceException("Couldn't find user");
		_db.Users.Remove(user);
		await _db.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}
