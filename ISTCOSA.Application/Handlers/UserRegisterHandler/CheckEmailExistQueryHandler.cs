using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.UserRegister.Queries.GetUserRegister;

using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.UserRegisterHandler
{
    public class CheckEmailExistQueryHandler : IRequestHandler<CheckEmailExistQuery, UserRegisterDTOs>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public CheckEmailExistQueryHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }
        public async Task<UserRegisterDTOs> Handle(CheckEmailExistQuery request, CancellationToken cancellationToken)
        {
            var EmailExist = await _context.userRegisters.FirstOrDefaultAsync(x=>x.Email==request.Email);
            if (EmailExist != null)
            {
                var mappeddata = _mapper.Map<UserRegisterDTOs>(EmailExist);
                return mappeddata;
            }
            else
            {
                return null;
            }
        }
    }
}
