using ISTCOSA.Application.Common.Behaviours.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQueries.UserBusiness.Queries
{
    public class GetBusinessByIdQuery: IRequest<BussinessDTO>
    {
        public int Id { get; set; }
    }
}
