using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.UserRegister.Queries.GetUserRegister;

using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.UserRegisterHandler
{
    public class CheckPhoneExistQueryHandler : IRequestHandler<CheckPhoneNumberExistQuery, UserRegisterDTOs>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public CheckPhoneExistQueryHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserRegisterDTOs> Handle(CheckPhoneNumberExistQuery request, CancellationToken cancellationToken)
        {
            var phoneExist = await _context.userRegisters.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber);
            if (phoneExist != null)
            {
                var mappeddata = _mapper.Map<UserRegisterDTOs>(phoneExist);
                return mappeddata;
            }
            else
            {
                return null;
            }
        }
    }
}
