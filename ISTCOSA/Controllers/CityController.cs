using ISTCOSA.Application.CommandAndQuries.City.Queries;
using ISTCOSA.Application.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CityController : BaseAPIController
    {
        [HttpGet("{stateId:int}")]
        [ProducesResponseType(typeof(List<CityDTO>), 200)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> GetCityByStateId(int stateId)
        {
            if (stateId <= 0)
            {
                return BadRequest("Invalid state ID.");
            }
            var cities = await Mediator.Send(new GetCityByStateIdQueries { Id = stateId });
            if (cities == null || !cities.Any())
            {
                return NotFound("No cities found for the specified state ID.");
            }
            return Ok(cities);
        }
    }
}
