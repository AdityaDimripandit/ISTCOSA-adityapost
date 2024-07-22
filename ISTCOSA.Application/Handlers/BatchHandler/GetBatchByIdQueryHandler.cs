using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.Batches.Queries.GetBatchById;





namespace ISTCOSA.Infrastructure.Handlers.BatchHandler
{
    public class GetBatchByIdQueryHandler : IRequestHandler<GetBatchByIdQuery, BatchDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public GetBatchByIdQueryHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BatchDTO> Handle(GetBatchByIdQuery request, CancellationToken cancellationToken)
        {
            var ExistingBatch = await _context.batches.FindAsync(request.BatchId);
            if (ExistingBatch == null)
            {
                throw new Exception("Batch not Found");
            }
            var Mappedbatch = _mapper.Map<BatchDTO>(ExistingBatch);
            return Mappedbatch;
        }
    }
}
