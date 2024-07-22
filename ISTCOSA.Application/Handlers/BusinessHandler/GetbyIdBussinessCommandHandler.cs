using AutoMapper;
using ISTCOSA.Application.CommandAndQueries.UserBusiness.Queries;
using ISTCOSA.Application.Common.Behaviours.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.Handlers.BusinessHandler
{
    public class GetbyIdBussinessCommandHandler : IRequestHandler<GetBusinessByIdQuery, BussinessDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;

        public GetbyIdBussinessCommandHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BussinessDTO> Handle(GetBusinessByIdQuery request, CancellationToken cancellationToken)
        {
            var business = await _context.postBusinesss
            .Include(b => b.industry)
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (business == null)
            {
                return null;
            }

            var businessDto = _mapper.Map<BussinessDTO>(business);
            return businessDto;
        }
    }
}
