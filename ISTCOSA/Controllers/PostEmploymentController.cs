using ISTCOSA.Application.CommandAndQuries.UserEmployment.Commands;
using ISTCOSA.Application.CommandAndQuries.UserEmployment.Queries;
using ISTCOSA.Application.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostEmploymentController : BaseAPIController
    {
        [HttpPost("CreateUserProfessional")]
        public async Task<IActionResult> CreateUserProfessional([FromBody] CreatePostEmploymentlCommand createEmployment)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if (createEmployment == null)
            {
                return BadRequest("Employment data is null.");
            }
            var employment = await Mediator.Send(createEmployment);
            if (employment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating batch.");
            }
            return Ok(employment);


        }

        [HttpGet("GetAllEmployment")]
        [ProducesResponseType(typeof(List<PostEmploymentDTO>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllEmployment()
        {
            if (!ModelState.IsValid) return BadRequest();
            var EmploymentList = await Mediator.Send(new GetAllPostEmploymentQuery());
            if(EmploymentList == null) return NotFound();
            return Ok(EmploymentList);
        }

        [HttpPut("UpdateUserEmployment{id}")]
        public async Task<IActionResult> UpdateUserEmployment(int id ,UpdatePostEmploymentlCommand updateUserEmployment)
        {
            if (id <= 0 || updateUserEmployment == null)
            {
                return BadRequest("Invalid UserEmployment ID or data.");
            }

            if (updateUserEmployment.Id != id)
            {
                return BadRequest("UserEmployment ID mismatch.");
            }

            var updatedUserEmployment = await Mediator.Send(updateUserEmployment);
            if (updatedUserEmployment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating User Employment.");
            }

            return Ok(updatedUserEmployment);

        }

        [HttpDelete("DeleteUserEmployment{id}")]
        public async Task<IActionResult> DeleteUserEmployment(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid UserEmployment ID.");
            }
            var result = await Mediator.Send(new DeletePostEmploymentCommand { Id = id });
            if (result == null)
            {
                return NotFound("UserEmployment not found.");
            }
            return Ok("UserEmployment deleted successfully.");
        }


    }
}
