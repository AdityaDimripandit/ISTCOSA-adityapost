using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.Profession.Queries;

using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.EmploymentTypeHandler
{
    public class GetAllProfessionQueryHandler : IRequestHandler<GetAllProfessionListQuery, List<ProfessionDTO>>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public GetAllProfessionQueryHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProfessionDTO>> Handle(GetAllProfessionListQuery request, CancellationToken cancellationToken)
        {
            var EmploymentType = await _context.professions.Where(x => x.IsActive).ToListAsync();
            if (EmploymentType == null) throw new Exception("EmploymentType not found");
            var MappingEmploymentType = _mapper.Map<List<ProfessionDTO>>(EmploymentType);
            if (MappingEmploymentType == null) throw new Exception("Error in Mapping of EmploymentType");
            return MappingEmploymentType;
        }
    }
}
