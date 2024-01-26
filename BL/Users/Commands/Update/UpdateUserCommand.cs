using BL.DTOs.Users;
using DAL.Models;
using MediatR;

namespace BL.Users.Commands.Update;
public class UpdateUserCommand : IRequest<User>
{
	public int Id { get; set; }
	public UpdateUserDto Dto { get; set; }

	public UpdateUserCommand(int id, UpdateUserDto dto)
	{
		Id = id;
		Dto = dto;
	}
}
