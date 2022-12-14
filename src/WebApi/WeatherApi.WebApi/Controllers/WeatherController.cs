using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApi.Infrastructure.Services.Weather;
using WeatherApp.Application.Features.Commands;
using WeatherApp.Application.Features.Commands.LoginUser;
using WeatherApp.Application.Features.Commands.Weather;
using WeatherApp.Application.Features.Queries;
using WeatherApp.Application.Wrappers;

namespace WeatherApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private readonly IMediator mediator;

        public WeatherController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize]
        [HttpGet("GetCoordinatesFromCityName")]
        public async Task<IActionResult> GetCoordinatesFromName(WeatherCoordinatesCommand weatherCoordinatesCommand)
        {
            var mediatR = await mediator.Send(weatherCoordinatesCommand);

            return Ok(mediatR);
        }

        [Authorize]
        [HttpGet("GetWeatherFromCoordinates")]
        public async Task<IActionResult> GetWeatherFromCoordinates(WeatherCommand weatherCommand)
        {
            var mediatR = await mediator.Send(weatherCommand);

            return Ok(mediatR);
        }
    }
}

