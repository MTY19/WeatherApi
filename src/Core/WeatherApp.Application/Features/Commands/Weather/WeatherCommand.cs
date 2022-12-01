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
	public class WeatherCoordinatesCommand : IRequest<ServiceResponse<IEnumerable<WeatherCoordinates>>>
	{
		public string Name { get; set; }

        public class WeatherCoordinatesCommandHandler : IRequestHandler<WeatherCoordinatesCommand, ServiceResponse<IEnumerable<WeatherCoordinates>>>
        {
            private readonly IWeatherCoordinateService weatherCoordinateService;
            private readonly IMapper mapper;

            public WeatherCoordinatesCommandHandler(IWeatherCoordinateService weatherCoordinateService, IMapper mapper)
            {
                this.weatherCoordinateService = weatherCoordinateService;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<IEnumerable<WeatherCoordinates>>> Handle(WeatherCoordinatesCommand request, CancellationToken cancellationToken)
            {
                var result = await weatherCoordinateService.GetCoordinatesFromCityName(request.Name);

                return new ServiceResponse<IEnumerable<WeatherCoordinates>>(result);
            }
        }
    }
}

