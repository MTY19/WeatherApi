using System;
namespace WeatherApp.Application.Wrappers
{
	public class BaseResponse
	{
		public Guid Id { get; set; }
		public Boolean Success { get; set; }
		public string Message { get; set; }
	}
}

