using System;
using WeatherApi.Domain.Entities;

namespace WeatherApp.Application.Interfaces.Services
{
	public interface IWeatherCoordinateService
    {
        Task<IEnumerable<WeatherCoordinates>> GetCoordinatesFromCityName(string name);
    }
}

