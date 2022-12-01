using System;
using Microsoft.Extensions.DependencyInjection;
using WeatherApi.Infrastructure.Services.Token;
using WeatherApi.Infrastructure.Services.Weather;
using WeatherApp.Application.Interfaces.Repository;
using WeatherApp.Application.Interfaces.Services;
using WeatherApp.Application.Interfaces.Token;

namespace WeatherApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IWeatherCoordinateService, WeatherCoordinateService>();
            serviceCollection.AddScoped<IWeatherService, WeatherService>();
        }
    }
}

