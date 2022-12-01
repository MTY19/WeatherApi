using System;
namespace WeatherApi.Domain.Common
{
	public class BaseEntity
	{
		public Guid Id { get; set; }
		public DateTime CreaateDate { get; set; }
	}
}
