using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WeatherApi.Domain.Entities;
using WeatherApp.Application.Exception;
using WeatherApp.Application.Interfaces.Services;

namespace WeatherApi.Infrastructure.Services.Weather
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;

        public WeatherService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
        }

        public async Task<Root> GetWeatherByCoordinate(double lat,double lon)
        {
            var httpClient = httpClientFactory.CreateClient("openweathermap");
            Root? locations = null;

            var httpResponseMessage = await httpClient.GetAsync(
            $"/data/3.0/onecall/timemachine?lat={lat}&lon={lon}&units=metric&dt={(long)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds}&appid={configuration["ApiKey"]}");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var contentStream =
                   await httpResponseMessage.Content.ReadAsStringAsync();

                var myDeserializedClass = JsonConvert.DeserializeObject<Root>(contentStream);
                //locations = await response.Content.ReadAsAsync<IEnumerable<LocationDTO>>();
                return myDeserializedClass;
            }

            throw new ServiceNotResponseException();

        }
    }
}

