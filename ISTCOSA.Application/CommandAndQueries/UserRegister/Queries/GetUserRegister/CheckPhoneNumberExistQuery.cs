using ISTCOSA.Application.Common.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.UserRegister.Queries.GetUserRegister
{
    public class CheckPhoneNumberExistQuery : IRequest<UserRegisterDTOs>
    {
        public string PhoneNumber { get; set; }
    }
}
