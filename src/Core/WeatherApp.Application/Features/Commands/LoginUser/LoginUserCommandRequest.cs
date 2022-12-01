using System;
using MediatR;

namespace WeatherApp.Application.Features.Commands.LoginUser
{
	public class LoginUserCommandRequest:IRequest<LoginUserCommandResponse>
	{
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

