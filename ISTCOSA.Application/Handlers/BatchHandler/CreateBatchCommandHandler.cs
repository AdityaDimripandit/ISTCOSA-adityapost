using AutoMapper;
 
using ISTCOSA.Domain.Entities;
 

using Microsoft.EntityFrameworkCore;
 
namespace ISTCOSA.Infrastructure.Handlers.BatchHandler
{
    public class CreateBatchCommandHandler : IRequestHandler<CreateBatchCommand, BatchDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public CreateBatchCommandHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BatchDTO> Handle(CreateBatchCommand request, CancellationToken cancellationToken)
        {
            var existingBatch = await _context.batches.FirstOrDefaultAsync(x => x.BatchNumber == request.BatchNumber);
            if (existingBatch != null) throw new Exception("Batch Number is Already Saved");
            var batchList = new Batch()
            {
                BatchNumber = request.BatchNumber,
                CreatedDate = DateTime.Now,
                IsActive = true,
            };

            await _context.AddAsync(batchList);
            var result = _mapper.Map<BatchDTO>(batchList);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
