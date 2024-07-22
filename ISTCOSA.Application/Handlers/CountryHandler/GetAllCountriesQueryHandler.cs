using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.Country.Queries;


using Microsoft.EntityFrameworkCore;


namespace ISTCOSA.Infrastructure.Handlers.CountryHandler
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQueries,List<CountryDTO>>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public GetAllCountriesQueryHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CountryDTO>> Handle(GetAllCountriesQueries request, CancellationToken cancellationToken)
        {
            var Countries = await _context.countries.ToListAsync();
            if (request == null) throw new Exception("Countries not found");
            var mappedcountries = _mapper.Map<List<CountryDTO>>(Countries);
            if (mappedcountries == null) throw new Exception("Error in mapping");
            return mappedcountries;
        }
    }
}
