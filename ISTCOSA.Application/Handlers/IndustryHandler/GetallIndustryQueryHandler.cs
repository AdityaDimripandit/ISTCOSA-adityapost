using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.Industry.Queries;

using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.IndustryHandler
{
    public class GetallIndustryQueryHandler : IRequestHandler<GetAllIndustriesQuery, List<IndustryDTO>>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public GetallIndustryQueryHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<IndustryDTO>> Handle(GetAllIndustriesQuery request, CancellationToken cancellationToken)
        {
            var industries = await _context.industries.Where(x => x.IsActive).ToListAsync();
            if (industries == null) throw new Exception("industries not found");
            var Mappingindustries = _mapper.Map<List<IndustryDTO>>(industries);
            if (Mappingindustries == null) throw new Exception("Error in Mapping of industries");
            return Mappingindustries;
        }
    }
}
