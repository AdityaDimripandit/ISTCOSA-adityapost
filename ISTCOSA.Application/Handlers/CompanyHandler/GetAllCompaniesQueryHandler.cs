using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.Company.Queries;


using Microsoft.EntityFrameworkCore;


namespace ISTCOSA.Infrastructure.Handlers.CompanyHandler
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, List<CompanyDTO>>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public GetAllCompaniesQueryHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CompanyDTO>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _context.companies.Where(x => x.IsActive).ToListAsync();
            if (companies == null) throw new Exception("companies not found");
            var Mappingcompanies = _mapper.Map<List<CompanyDTO>>(companies);
            if (Mappingcompanies == null) throw new Exception("Error in Mapping of Companies");
            return Mappingcompanies;
        }
    }
}
