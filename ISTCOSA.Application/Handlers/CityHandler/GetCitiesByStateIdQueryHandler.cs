using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.City.Queries;


using Microsoft.EntityFrameworkCore;


namespace ISTCOSA.Infrastructure.Handlers.CityHandler
{
    public class GetCitiesByStateIdQueryHandler : IRequestHandler<GetCityByStateIdQueries, List<CityDTO>>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public GetCitiesByStateIdQueryHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CityDTO>> Handle(GetCityByStateIdQueries request, CancellationToken cancellationToken)
        {
            var Cities = await _context.cities.Where(x => x.StateId == request.Id).ToListAsync(cancellationToken);
            if (Cities == null || Cities.Count == 0)
            {
                throw new Exception("States not found under this country");
            }

            var MappedData = _mapper.Map<List<CityDTO>>(Cities);
            if (MappedData == null || MappedData.Count == 0)
            {
                throw new Exception("Mapped data is not found");
            }
            return MappedData;
        }
    }
}
