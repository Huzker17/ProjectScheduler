using BL.Utils;
using DAL;
using DAL.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BL.Users.Queries.GetAll;
public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<User>>
{
	private readonly ApplicationDbContext _db;

	public GetAllUserQueryHandler(ApplicationDbContext db)
	{
		_db = db;
	}

	public async Task<IEnumerable<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
	{
		if (request == null)
			throw new NullReferenceException(nameof(request));

		var users = await _db.Users.SortRows(x => x.Name, request.IsAsc).ToListAsync(cancellationToken)
									?? throw new NullReferenceException("There isn't users");
		return users;
	}
}
