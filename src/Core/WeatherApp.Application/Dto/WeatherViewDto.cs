using System;
namespace WeatherApp.Application.Dto
{
	public class WeatherViewDto
	{
        public double lat { get; set; }
        public double lon { get; set; }
        public string timezone { get; set; }
        public int timezone_offset { get; set; }
        public double temp { get; set; }
        public double feels_like { get; set; }
        public string main { get; set; }
        public string description { get; set; }

    }
}

