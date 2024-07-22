using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.Batches.Queries.GetBatches;


using Microsoft.EntityFrameworkCore;


namespace ISTCOSA.Infrastructure.Handlers.BatchHandler
{
    public class GetBatchesQueryHandler : IRequestHandler<GetAllBatchQuery, List<BatchDTO>>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public GetBatchesQueryHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BatchDTO>> Handle(GetAllBatchQuery request, CancellationToken cancellationToken)
        {
            var batches = await _context.batches.Where(x => x.IsActive).ToListAsync();
            if (batches == null) throw new Exception("batches not found");
            var MappingBatches = _mapper.Map<List<BatchDTO>>(batches);
            if (MappingBatches == null) throw new Exception("Error in Mapping of Batches");
            return MappingBatches;
        }
    }
}
