using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.Batches.Commands.UpdateBatch;




namespace ISTCOSA.Infrastructure.Handlers.BatchHandler
{
    public class UpdateBatchCommandHandler : IRequestHandler<UpdateBatchCommand, BatchDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public UpdateBatchCommandHandler(IApplicationDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BatchDTO> Handle(UpdateBatchCommand request, CancellationToken cancellationToken)
        {

            var existingBatch = await _context.batches.FindAsync(request.BatchId);
            if (existingBatch == null) throw new Exception("Batch Not Found");

            existingBatch.BatchNumber = request.BatchNumber;
            existingBatch.UpdatedDate = DateTime.Now;

            _context.Update(existingBatch);
            await _context.SaveChangesAsync();
            var mappedBatchforUpdate = _mapper.Map<BatchDTO>(existingBatch);
            return mappedBatchforUpdate;
        }
    }
}
