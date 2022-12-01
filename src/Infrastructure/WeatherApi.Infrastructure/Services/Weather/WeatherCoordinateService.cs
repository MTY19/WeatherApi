using System;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WeatherApi.Domain.Entities;
using WeatherApp.Application.Exception;
using WeatherApp.Application.Interfaces.Services;

namespace WeatherApi.Infrastructure.Services.Weather
{
	public class WeatherCoordinateService: IWeatherCoordinateService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;

        public WeatherCoordinateService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
		{
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<WeatherCoordinates>> GetCoordinatesFromCityName(string name)
        {
            var httpClient = httpClientFactory.CreateClient("openweathermap");
            IEnumerable<WeatherCoordinates>? locations = null;

            var httpResponseMessage = await httpClient.GetAsync(
            $"/geo/1.0/direct?q={name}&limit=1&appid={configuration["ApiKey"]}");


            if (httpResponseMessage.IsSuccessStatusCode)
            {
                 var contentStream =
                    await httpResponseMessage.Content.ReadAsStringAsync();

                var myDeserializedClass = JsonConvert.DeserializeObject<IEnumerable<WeatherCoordinates>>(contentStream);
                //locations = await response.Content.ReadAsAsync<IEnumerable<LocationDTO>>();
                return myDeserializedClass;
            }

            throw new ServiceNotResponseException();

        }
    }
}

