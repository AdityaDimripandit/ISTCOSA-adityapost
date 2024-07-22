using ISTCOSA.Application.CommandAndQueries.UserProfile.Commands;
using ISTCOSA.Application.CommandAndQuries.UserProfile.Commands;
using ISTCOSA.Application.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : BaseAPIController
    {
        
        [HttpPut("Update{id}")]
        public async Task<IActionResult> UpdateUserProfile(string id, [FromBody] UpdateUserProfileCommand updateUserProfileCommand )
        {
            if (id == null || updateUserProfileCommand == null)
            {
                return BadRequest("Invalid User");
            }
            var updatedUserprofile = await Mediator.Send(updateUserProfileCommand);
            if (updatedUserprofile == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating batch.");
            }
            return Ok(updatedUserprofile);
        }

        [HttpPut("UpdatePicture{id}")]

        public async Task<IActionResult>UpdateProfilePicture(string id, [FromBody] UpdateProfilePictureCommand updateProfilePictureCommand)
        {
            if(id == null || updateProfilePictureCommand == null)
            {
                return NotFound("Invalid User");
            }
            var updatepicture = await Mediator.Send(updateProfilePictureCommand);
            if (updatepicture == null) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error update Image");

            }
            return Ok(updatepicture);
        }

        [HttpDelete("DeletePicture/{id}")]
        public async Task<IActionResult> DeleteProfilePicture(int id)
        {
            if (id == 0)
            {
                return NotFound("Invalid User");
            }

            
            var deleteResult = await Mediator.Send(new DeleteProfilePIctureCommand { Id = id });

            if (deleteResult != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete profile picture");
            }

            return Ok("Profile picture deleted successfully");
        }
    }
}
