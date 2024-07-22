using ISTCOSA.Application.Common.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.RollNumbers.Commands.DeleteRollNumber
{
    public class DeleteRollNumberCommand : IRequest<RollNumberDTO>
    {
        public int RollNumberId { get; set; }
        public int RollNumbers { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
