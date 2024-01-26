using DAL.Models;
using MediatR;

namespace BL.Users.Queries.GetAll;
public class GetAllUserQuery : IRequest<IEnumerable<User>>
{
	public bool? IsAsc { get; set; }

	public GetAllUserQuery(bool? isAsc)
	{
		IsAsc = isAsc;
	}
}
