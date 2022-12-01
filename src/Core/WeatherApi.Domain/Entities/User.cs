using System;
using WeatherApi.Domain.Common;

namespace WeatherApi.Domain.Entities
{
	public class User: BaseEntity
	{
		public string Username { get; set; }
        public string Password { get; set; }
    }
}

