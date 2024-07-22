using ISTCOSA.Application.CommandAndQuries.RollNumbers.Commands.CreateRollNumber;
using ISTCOSA.Application.CommandAndQuries.RollNumbers.Commands.DeleteRollNumber;
using ISTCOSA.Application.CommandAndQuries.RollNumbers.Commands.UpdateRollNumber;
using ISTCOSA.Application.CommandAndQuries.RollNumbers.Queries.GetRollNumberById;
using ISTCOSA.Application.CommandAndQuries.RollNumbers.Queries.GetRollNumbers;
using ISTCOSA.Application.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class RollNumbersController : BaseAPIController
    {
        [HttpGet("GetAllRollNumbers")]
        [ProducesResponseType(typeof(List<RollNumberDTO>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllRollNumbers()
        {
            var rollNumberList = await Mediator.Send(new GetAllRollNumbersQuery());
            if (rollNumberList == null || !rollNumberList.Any())
            {
                return NotFound("No roll numbers found.");
            }
            return Ok(rollNumberList);
        }

        [HttpGet("GetRollNumberByBatchId{id:int}")]
        public async Task<IActionResult> GetRollNumberByBatchId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid roll number ID.");
            }

            var rollNumber = await Mediator.Send(new GetRollNumberById { BatchId = id });
            if (rollNumber == null)
            {
                return NotFound("Roll number not found.");
            }

            return Ok(rollNumber);
        }


        [HttpPost("CreateRollNumber")]
        public async Task<IActionResult> CreateRollNumber([FromBody] CreateRollNumberCommand createRollNumberCommand)
        {
            if (createRollNumberCommand == null)
            {
                return BadRequest("Roll number data is null.");
            }

            var createdRollNumber = await Mediator.Send(createRollNumberCommand);
            if (createdRollNumber == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating roll number.");
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRollNumber(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid roll number ID.");
            }

            var result = await Mediator.Send(new DeleteRollNumberCommand { RollNumberId = id });
            if (result == null)
            {
                return NotFound("Roll number not found.");
            }

            return Ok("Roll number deleted successfully.");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRollNumber(int id, [FromBody] UpdateRollNumberCommand updateRollNumberCommand)
        {
            if (id <= 0 || updateRollNumberCommand == null)
            {
                return BadRequest("Invalid roll number ID or data.");
            }

            if (updateRollNumberCommand.RollNumberId != id)
            {
                return BadRequest("Roll number ID mismatch.");
            }

            var updatedRollNumber = await Mediator.Send(updateRollNumberCommand);
            if (updatedRollNumber == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating roll number.");
            }

            return Ok(updatedRollNumber);
        }
    }
}
