using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.State.Queries;

using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.StateHandler
{
    public class GetStateByCountryIdQueryHandler : IRequestHandler<GetStateByCountryIdQueries, List<StateDTO>>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public GetStateByCountryIdQueryHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<StateDTO>> Handle(GetStateByCountryIdQueries request, CancellationToken cancellationToken)
        {
            var states = await _context.states.Include(x=>x.Country).Where(x => x.CountryId == request.Id).ToListAsync(cancellationToken);
            if (states == null || states.Count == 0)
            {
                throw new Exception("States not found under this country");
            }

            var MappedData = _mapper.Map<List<StateDTO>>(states);
            if (MappedData == null || MappedData.Count == 0)
            {
                throw new Exception("Mapped data is not found");
            }
            return MappedData;
        }

    }
}
