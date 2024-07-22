using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.RollNumbers.Queries.GetRollNumberById;

using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.RollNumberHandler
{
    public class GetRollNumberByIdQueryHandler :IRequestHandler<GetRollNumberById,List<RollNumberDTO>>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public GetRollNumberByIdQueryHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RollNumberDTO>> Handle(GetRollNumberById request, CancellationToken cancellationToken)
        {
            var ExistingRollNumber = await _context.rollNumbers.Include(x => x.Batch).Where(x => x.BatchId == request.BatchId).ToListAsync();
            if (ExistingRollNumber == null)
            {
                throw new Exception("RollNumber not Found in this Batch");
            }
            var MappedRollNumber = _mapper.Map<List<RollNumberDTO>>(ExistingRollNumber);
            return MappedRollNumber;
        }
    }
}
