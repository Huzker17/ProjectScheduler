using DAL;
using DAL.Models;
using MediatR;

namespace BL.Users.Commands.Create;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
{
	private readonly ApplicationDbContext _db;
	public CreateUserCommandHandler(ApplicationDbContext db) => _db = db;

	public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		if(request == null)
			throw new ArgumentNullException(nameof(request));

		var user = new User(request.UserDto.Surname, request.UserDto.Name, request.UserDto.Patronymic, request.UserDto.Email);
		await _db.Users.AddAsync(user, cancellationToken);
		await _db.SaveChangesAsync(cancellationToken);
		return user ?? throw new NullReferenceException(nameof(user));
	}
}
