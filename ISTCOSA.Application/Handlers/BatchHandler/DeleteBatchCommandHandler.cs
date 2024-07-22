using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.Batches.Commands.DeleteBatch;


namespace ISTCOSA.Infrastructure.Handlers.BatchHandler
{
    public class DeleteBatchCommandHandler : IRequestHandler<DeleteCommand, BatchDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public DeleteBatchCommandHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BatchDTO> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var existingBatch = await _context.batches.FindAsync(request.BatchId);
            if (existingBatch != null)
            {
                existingBatch.IsActive = false;
                existingBatch.DeletedDate = DateTime.Now;
            }
            var mappeddata = _mapper.Map<BatchDTO>(existingBatch);
            await _context.SaveChangesAsync();
            return mappeddata;
        }
    }
}
