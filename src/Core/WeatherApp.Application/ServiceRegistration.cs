using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WeatherApp.Application.Interfaces.Token;

namespace WeatherApp.Application
{
	public static class ServiceRegistration
	{
		public static void AddApplicationRegistraion(this IServiceCollection services)
		{
			var assem = Assembly.GetExecutingAssembly();

			services.AddAutoMapper(assem);
            services.AddMediatR(assem);
        }
	}
}

