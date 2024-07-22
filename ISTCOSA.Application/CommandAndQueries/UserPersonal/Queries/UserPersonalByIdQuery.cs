using ISTCOSA.Application.Common.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.UserPersonal.Queries
{
    public class UserPersonalByIdQuery : IRequest<UserPersonalDTO>
    {
        public int Id { get; set; }
        public int UserCityId { get; set; }
        public string Email { get; set; }   
    }
}
