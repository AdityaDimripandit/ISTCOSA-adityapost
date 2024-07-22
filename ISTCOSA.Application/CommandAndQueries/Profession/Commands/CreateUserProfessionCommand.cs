using ISTCOSA.Application.Common.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.Profession.Commands
{
    public class CreateUserProfessionCommand : IRequest<ProfessionDTO>
    {
        public string Name { get; set; }
    }
}
