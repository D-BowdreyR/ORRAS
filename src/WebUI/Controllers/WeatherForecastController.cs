using Microsoft.AspNetCore.Mvc;
using ORRAS.Application.WeatherForecasts.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ORRAS.WebUI.Controllers
{
    public class WeatherForecastController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }
    }
}
