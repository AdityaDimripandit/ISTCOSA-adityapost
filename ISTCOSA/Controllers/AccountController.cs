using ISTCOSA.Application.CommandAndQuries.Account.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseAPIController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(CreateLoginCommand createLogin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var login = await Mediator.Send(createLogin);
                    return Ok(login);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("GenerateResetPasswordToken")]
        public async Task<IActionResult> GenerateResetPasswordToken([FromBody] CreateResetPasswordTokenGenerateCommand command)
        {
            if (ModelState.IsValid)
            {

                var token = await Mediator.Send(command);
                return Ok(new { Message = "Reset password token sent to your email." });
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPost("ResetPassword")]
        public  async Task<IActionResult>ResetPassword(CreateResetPasswordCommand createResetPasswordCommand)
        {
            if(ModelState.IsValid)
            {
                var ResetPassword = await Mediator.Send(createResetPasswordCommand);
                return Ok(ResetPassword);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }



    }
}
