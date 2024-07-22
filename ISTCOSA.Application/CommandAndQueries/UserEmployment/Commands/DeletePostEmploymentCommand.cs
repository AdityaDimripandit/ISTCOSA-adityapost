using ISTCOSA.Application.Common.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.UserEmployment.Commands
{
    public class DeletePostEmploymentCommand : IRequest<PostEmploymentDTO>
    {
        public int Id { get; set; }
    }
}
