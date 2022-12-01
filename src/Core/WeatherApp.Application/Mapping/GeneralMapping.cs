using System;
using AutoMapper;
using WeatherApi.Domain.Entities;
using WeatherApp.Application.Dto;
using WeatherApp.Application.Features.Commands;
using WeatherApp.Application.Features.Commands.LoginUser;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherApp.Application.Mapping
{
	public class GeneralMapping:Profile
	{
		public GeneralMapping()
		{
			CreateMap<User, UserViewDto>().ReverseMap();
            CreateMap<User, UserLoginCommand>().ReverseMap();
            CreateMap<User, LoginUserCommandRequest>().ReverseMap();
        }
    }
}

