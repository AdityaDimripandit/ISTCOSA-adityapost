
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.UserRegister.Queries.GetUserRegister
{
    public class CheckRollNumberExistQuery:IRequest<UserRegisterDTOs>
    {
        public int RollNumberId { get; set; }
    }
}
