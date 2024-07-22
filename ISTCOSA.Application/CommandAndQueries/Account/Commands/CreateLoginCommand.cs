

namespace ISTCOSA.Application.CommandAndQuries.Account.Commands
{
    public class CreateLoginCommand : IRequest<LoginDTO>
    {
        
        public string RollNumber { get; set; }
        public string Password { get; set; }
    }
}
