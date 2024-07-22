using ISTCOSA.Application.CommandAndQuries.Company.Queries;
using ISTCOSA.Application.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController :BaseAPIController
    {
        [HttpGet("GetAllCompanies")]
        [ProducesResponseType(typeof(List<CompanyDTO>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllCompanies()
        {
            var CompanyList = await Mediator.Send(new GetAllCompaniesQuery());
            if (CompanyList == null || !CompanyList.Any())
            {
                return NotFound("No CompanyList found.");
            }
            return Ok(CompanyList);
        }

    }
}
