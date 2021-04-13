using Microsoft.AspNetCore.Mvc;
using ORRA.Application.WeatherForecasts.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ORRA.WebUI.Controllers
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
