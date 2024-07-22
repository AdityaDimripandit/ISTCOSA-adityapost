using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.RollNumbers.Queries.GetRollNumbers;

using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.RollNumberHandler
{
    public class GetRollNumbersQueryHandlers : IRequestHandler<GetAllRollNumbersQuery,List<RollNumberDTO>>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public GetRollNumbersQueryHandlers(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<RollNumberDTO>> Handle(GetAllRollNumbersQuery request, CancellationToken cancellationToken)
        {
            var RollNumbers = await _context.rollNumbers.Where(x => x.IsActive).ToListAsync();
            var Mappingdata = _mapper.Map<List<RollNumberDTO>>(RollNumbers);
            return Mappingdata;
        }
    }
}
