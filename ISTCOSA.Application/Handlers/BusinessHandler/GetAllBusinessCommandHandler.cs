using AutoMapper;
using ISTCOSA.Application.CommandAndQueries.UserBusiness.Commands;
using ISTCOSA.Application.CommandAndQueries.UserBusiness.Queries;
using ISTCOSA.Application.CommandAndQuries.Batches.Queries.GetBatches;
using ISTCOSA.Application.CommandAndQuries.RollNumbers.Queries.GetRollNumbers;
using ISTCOSA.Application.Common.Behaviours.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ISTCOSA.Application.Handlers.BusinessHandler
{
    public class GetAllBusinessCommandHandler : IRequestHandler<GetAllBusinessQuery, List<BussinessDTO>>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GetAllBusinessCommandHandler(IApplicationDBContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<List<BussinessDTO>> Handle(GetAllBusinessQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var businesses = await _context.postBusinesss
                    .Include(b =>b.industry)
                    .ToListAsync(cancellationToken);


                var Dtos = _mapper.Map<List<BussinessDTO>>(businesses);
                               
                return Dtos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving businesses: {ex.Message}");
                throw;
            }

        }
    }
}
