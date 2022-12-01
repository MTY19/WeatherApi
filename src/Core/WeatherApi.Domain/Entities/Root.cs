using System;
using WeatherApi.Domain.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherApi.Domain.Entities
{
    public class Root
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public string timezone { get; set; }
        public int timezone_offset { get; set; }
        public List<Datum> data { get; set; }
    }

}

