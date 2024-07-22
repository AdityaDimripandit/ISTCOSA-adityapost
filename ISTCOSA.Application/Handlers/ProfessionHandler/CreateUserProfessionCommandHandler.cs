using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.Profession.Commands;
using ISTCOSA.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.ProfessionHandler
{
    public class CreateUserProfessionCommandHandler:IRequestHandler<CreateUserProfessionCommand,ProfessionDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public CreateUserProfessionCommandHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProfessionDTO> Handle(CreateUserProfessionCommand request, CancellationToken cancellationToken)
        {
            var existingProfession = await _context.professions.FirstOrDefaultAsync(x => x.Name == request.Name);
            if (existingProfession != null) throw new Exception("Profession is Already Saved");
            var ProfessionDTOList = new Profession()
            {
                Name = request.Name,
                CreatedDate = DateTime.Now,
                IsActive = true,
            };

            await _context.AddAsync(ProfessionDTOList);
            var result = _mapper.Map<ProfessionDTO>(ProfessionDTOList);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
