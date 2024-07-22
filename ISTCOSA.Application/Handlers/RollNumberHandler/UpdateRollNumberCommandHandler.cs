using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.RollNumbers.Commands.UpdateRollNumber;


namespace ISTCOSA.Infrastructure.Handlers.RollNumberHandler
{
    public class UpdateRollNumberCommandHandler : IRequestHandler<UpdateRollNumberCommand, RollNumberDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public UpdateRollNumberCommandHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RollNumberDTO> Handle(UpdateRollNumberCommand request, CancellationToken cancellationToken)
        {
            var existingBatch = await _context.rollNumbers.FindAsync(request.RollNumberId);
            if (existingBatch == null) throw new Exception("RollNumber Not Found");
            existingBatch.RollNumbers = request.RollNumbers;
            existingBatch.BatchId = request.BatchId;
            existingBatch.UpdatedDate = DateTime.Now;
            _context.Update(existingBatch);
            await _context.SaveChangesAsync();
            var mappedBatchforUpdate = _mapper.Map<RollNumberDTO>(existingBatch);
            return mappedBatchforUpdate;
        }
    }
}
