using AutoMapper;
using ISTCOSA.Application.Common.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.UserEmployment.Queries
{
    public class GetAllPostEmploymentQuery : IRequest<List<PostEmploymentDTO>>
    {
    }
}
