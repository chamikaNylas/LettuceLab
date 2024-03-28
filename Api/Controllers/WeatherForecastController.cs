using Application;
using Application.Queries;
using Application.Queries.GreenHouseQuery;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public GetRepo _getRepo { get; set; }
        private readonly IMediator _mediator;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController( ILogger<WeatherForecastController> logger,IMediator mediator)
        {
            _logger = logger;
        
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult> Get([FromQuery] YourComplexType model)
        {
            //  var greenhouses=await _mediator.Send(new GetGreenHousesQuery());
            //  return Ok(greenhouses);
            return Ok(model);
        }

        //[HttpGet(Name = "GetComplexTypes")]
        //public IActionResult YourAction([FromQuery] YourComplexType model)
        //{
        //    // Your logic using the bound complex type
        //    return Ok(model);
        //}

        [HttpGet("{authids}")]
        public IActionResult GetAuthorsCollection([FromRoute] AuthorsRequestDto requestDto)
        {
            // Access the AuthorIds property here
            foreach (var authorId in requestDto.AuthorIds)
            {
                // Do something with each GUID
            }

            // Your logic here
            return Ok("");
        }
    }


    public class AuthorsRequestDto
    {
        [FromRoute]
        public IEnumerable<Guid> AuthorIds { get; set; }
    }

    public class YourComplexType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

}