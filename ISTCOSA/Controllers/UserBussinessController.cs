using ISTCOSA.Application.CommandAndQueries.UserBusiness.Commands;
using ISTCOSA.Application.CommandAndQueries.UserBusiness.Queries;
using ISTCOSA.Application.CommandAndQueries.UserProfile.Commands;
using ISTCOSA.Application.CommandAndQuries.RollNumbers.Queries.GetRollNumbers;
using ISTCOSA.Application.CommandAndQuries.UserEmployment.Commands;
using ISTCOSA.Application.Common.Behaviours.DTOs;
using ISTCOSA.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBussinessController : BaseAPIController
    {
        [HttpPost("CreateUserBusiness")]
        public async Task<IActionResult> CreateUserBusiness([FromBody] CreateBussinessCommand createbusiness)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();
                return BadRequest(errors);
            }

            if (createbusiness == null)
            {
                return BadRequest("Data is null.");
            }

            var business = await Mediator.Send(createbusiness);
            if (business == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating business.");
            }

            return Ok(business);
        }
    
        [HttpGet("GetAllUserBusiness")]
        public async Task<IActionResult> GetAllUserBusiness()
        {

            var businessList = await Mediator.Send(new GetAllBusinessQuery());
          
            if (businessList == null || !businessList.Any())
            {
                return NotFound("No roll numbers found.");
            }
            return Ok(businessList);
        }
        [HttpPut("UpdateUserBussiness{id}")]
        public async Task<IActionResult> UpdateUserBussiness(int id, UpdateBussinessCommand updateUserBussiness)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();
                return BadRequest(errors);
            }
            if (id <= 0 || updateUserBussiness == null)
            {
                return BadRequest("Invalid UserEmployment ID or data.");
            }

            if (updateUserBussiness.Id != id)
            {
                return BadRequest("UserEmployment ID mismatch.");
            }

            var updatedUserEmployment = await Mediator.Send(updateUserBussiness);
            if (updatedUserEmployment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating User Employment.");
            }

            return Ok(updatedUserEmployment);


        }
        [HttpDelete("DeleteBussiness/{id}")]
        public async Task<IActionResult> DeleteBussiness(int id)
        {
            if (id == 0)
            {
                return NotFound("Invalid User");
            }


            var deleteResult = await Mediator.Send(new DeleteBussinessCommand { Id = id });

            if (deleteResult != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete Bussiness");
            }

            return Ok("Bussiness Deleted successfully");
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var businessDto = await Mediator.Send(new GetBusinessByIdQuery { Id = id });

                if (businessDto == null)
                {
                    return NotFound($"Business with ID {id} not found.");
                }

                return Ok(businessDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
