﻿using System;
using MediatR;
using WeatherApp.Application.Dto;

namespace WeatherApp.Application.Features.Commands.LoginUser
{
	public class LoginUserCommandResponse
	{
    }

    public class LoginUserSuccessCommandResponse: LoginUserCommandResponse
    {
        public Token Token { get; set; }
    }

    public class LoginUserErrorCommandResponse: LoginUserCommandResponse
    {
        public string Message { get; set; }
    }
}


