using System;
using WeatherApi.Domain.Entities;

namespace WeatherApp.Application.Interfaces.Repository
{
	public interface IUserRepository: IGenericRepositoryAsync<User>
    {
        //Task<User> Login(string username, string passowrd);
    }
}

