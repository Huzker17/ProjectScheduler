using DAL;
using DAL.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BL.Users.Commands.Update;
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
{
	private readonly ApplicationDbContext _db;

	public UpdateUserCommandHandler(ApplicationDbContext db)
	{
		_db = db;
	}

	public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
	{
		if(request == null) 
			throw new ArgumentNullException(nameof(request));

		var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) ??
							throw new ArgumentException("Couldn't find user");

		_db.Users.Update(user);
		await _db.SaveChangesAsync(cancellationToken);
		return user;
	}
}

