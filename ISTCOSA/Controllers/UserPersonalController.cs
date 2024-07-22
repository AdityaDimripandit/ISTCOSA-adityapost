using ISTCOSA.Application.CommandAndQuries.UserPersonal.Commands;
using ISTCOSA.Application.CommandAndQuries.UserPersonal.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class UserPersonalController : BaseAPIController
    {
        private readonly ILogger<UserRegisterController> _logger;
        public UserPersonalController(ILogger<UserRegisterController> logger)
        {
            _logger = logger;
        }
        

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserPersonal(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid UserPersonal ID.");
            }
            var Personaldetail = await Mediator.Send(new UserPersonalByIdQuery { Id = id });
            if (Personaldetail == null)
            {
                return NotFound("Personal detail not found.");
            }
            return Ok(Personaldetail);
        }

        [HttpPost("CreateUserPersonal")]
        public async Task<IActionResult> CreateUserPersonal(CreateUserPersonalCommand createUserPersonalCommand)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    var errors = ModelState.Values.SelectMany(v => v.Errors)
                //                                  .Select(e => e.ErrorMessage)
                //                                  .ToList();
                //    return BadRequest(errors);
                //}

                {
                    if (createUserPersonalCommand == null)
                    {
                        return NotFound();
                    }
                    var UserPersonal = await Mediator.Send(createUserPersonalCommand);
                    return Ok(UserPersonal);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving user personal information: {ex.Message}");
            }
            
        }




    }
}
