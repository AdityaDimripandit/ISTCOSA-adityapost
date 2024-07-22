using ISTCOSA.Application.CommandAndQuries.State.Queries;
using ISTCOSA.Application.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StateController : BaseAPIController
    {
        [ProducesResponseType(typeof(List<StateDTO>), 200)]
        [ProducesResponseType(404)]
        [HttpGet("{countryId:int}")]
        public async Task<IActionResult> GetStateByCountryId(int countryId)
        {
            if (countryId <= 0)
            {
                return BadRequest("Invalid country ID.");
            }

            var states = await Mediator.Send(new GetStateByCountryIdQueries { Id = countryId });
            if (states == null || !states.Any())
            {
                return NotFound("No states found for the specified country ID.");
            }
            return Ok(states);
        }
    }
}
