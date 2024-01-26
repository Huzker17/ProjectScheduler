using DAL;
using DAL.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BL.Users.Queries.GetById;
public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
	private readonly ApplicationDbContext _db;

	public GetUserByIdQueryHandler(ApplicationDbContext db)
	{
		_db = db;
	}

	public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
	{
		if (request == null) 
			throw new ArgumentNullException(nameof(request));

		var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == request.Id)
						?? throw new NullReferenceException("There isn't user with this id");
		return user;
	}
}
