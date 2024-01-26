using DAL.Models;
using MediatR;

namespace BL.Users.Queries.GetById;
public class GetUserByIdQuery : IRequest<User>
{
	public int Id { get; set; }

	public GetUserByIdQuery(int id)
	{
		Id = id;
	}
}
