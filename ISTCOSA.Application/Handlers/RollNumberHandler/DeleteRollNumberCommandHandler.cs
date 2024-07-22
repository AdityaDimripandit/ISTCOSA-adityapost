using AutoMapper;

using ISTCOSA.Application.CommandAndQuries.RollNumbers.Commands.DeleteRollNumber;




namespace ISTCOSA.Infrastructure.Handlers.RollNumberHandler
{
    public class DeleteRollNumberCommandHandler : IRequestHandler<DeleteRollNumberCommand, RollNumberDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public DeleteRollNumberCommandHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RollNumberDTO> Handle(DeleteRollNumberCommand request, CancellationToken cancellationToken)
        {
            var existingRollNumber = await _context.rollNumbers.FindAsync(request.RollNumberId);
            if (existingRollNumber != null)
            {
                existingRollNumber.IsActive = false;
                existingRollNumber.DeletedDate = DateTime.Now;
            }
            var mappeddata = _mapper.Map<RollNumberDTO>(existingRollNumber);
            await _context.SaveChangesAsync();
            return mappeddata;
        }
    }
}
