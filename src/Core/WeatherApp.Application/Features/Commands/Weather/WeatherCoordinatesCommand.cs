using System;
using System.Collections.Generic;
using AutoMapper;
using MediatR;
using WeatherApi.Domain.Entities;
using WeatherApp.Application.Dto;
using WeatherApp.Application.Exception;
using WeatherApp.Application.Interfaces.Repository;
using WeatherApp.Application.Interfaces.Services;
using WeatherApp.Application.Wrappers;

namespace WeatherApp.Application.Features.Commands.Weather
{
	public class WeatherCommand : IRequest<ServiceResponse<Root>>
	{
		public double lat { get; set; }
        public double lon { get; set; }

        public class WeatherCommandHandler : IRequestHandler<WeatherCommand, ServiceResponse<Root>>
        {
            private readonly IWeatherService weatherService;
            private readonly IMapper mapper;

            public WeatherCommandHandler(IWeatherService weatherService, IMapper mapper)
            {
                this.weatherService = weatherService;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<Root>> Handle(WeatherCommand request, CancellationToken cancellationToken)
            {
                var result = await weatherService.GetWeatherByCoordinate(request.lat, request.lon);

                return new ServiceResponse<Root>(result);
            }
        }
    }
}

