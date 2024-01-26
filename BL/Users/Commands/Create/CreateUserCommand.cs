using BL.DTOs.Users;
using DAL.Models;
using MediatR;

namespace BL.Users.Commands.Create;
public class CreateUserCommand : IRequest<User>
{
	public CreateUserDto UserDto { get; set; }

	public CreateUserCommand(CreateUserDto userDto)
	{
		UserDto = userDto;
	}
}
