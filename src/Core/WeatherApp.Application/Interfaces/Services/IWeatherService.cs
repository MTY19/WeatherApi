using System;
using WeatherApi.Domain.Entities;

namespace WeatherApp.Application.Interfaces.Services
{
	public interface IWeatherService
    {
        Task<Root> GetWeatherByCoordinate(double lat, double lon);
    }
}

