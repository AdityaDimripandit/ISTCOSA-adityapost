using ISTCOSA.Application.Common.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.RollNumbers.Commands.UpdateRollNumber
{
    public class UpdateRollNumberCommand : IRequest<RollNumberDTO>
    {
        public int RollNumberId { get; set; }
        public int BatchId { get; set; }
        public int RollNumbers { get; set; }

    }
}
