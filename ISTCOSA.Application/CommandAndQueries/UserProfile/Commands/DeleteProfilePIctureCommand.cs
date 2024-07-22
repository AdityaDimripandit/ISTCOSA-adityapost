using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQueries.UserProfile.Commands
{
    public class DeleteProfilePIctureCommand:  IRequest<UserRegisterDTOs>
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Images { get; set; }
        public string ImagePath { get; set; }
    }
}
