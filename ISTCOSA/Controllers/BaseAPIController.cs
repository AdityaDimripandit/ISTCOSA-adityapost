using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ISTCOSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {
        private ISender? _mediatR;
        protected ISender Mediator => _mediatR ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
