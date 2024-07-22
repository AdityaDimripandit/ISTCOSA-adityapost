using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.UserRegister.Queries.GetUserRegister;

using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Application.Handlers.UserRegisterHandler
{
    public class CheckRollNumberExistQueryHandler : IRequestHandler<CheckRollNumberExistQuery, UserRegisterDTOs>
    {
        private readonly IApplicationDBContext _Context;
        private readonly IMapper _Mapper;

        public CheckRollNumberExistQueryHandler(IApplicationDBContext Context, IMapper Mapper)
        {
            _Context = Context;
            _Mapper = Mapper;
        }
        public async Task<UserRegisterDTOs> Handle(CheckRollNumberExistQuery request, CancellationToken cancellationToken)
        {
            var ExistRecord = await _Context.userRegisters.FirstOrDefaultAsync(x => x.RollNumberId == request.RollNumberId);
            if (ExistRecord == null) return null;
            
                var mappeddata = _Mapper.Map<UserRegisterDTOs>(ExistRecord);
                return mappeddata;
        }
    }
}
