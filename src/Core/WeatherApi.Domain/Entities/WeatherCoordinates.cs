using System;
using WeatherApi.Domain.Common;

namespace WeatherApi.Domain.Entities
{
    public class WeatherCoordinates 
    {
        public string name { get; set; }
        public LocalNames local_names { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string country { get; set; }
    }
}

