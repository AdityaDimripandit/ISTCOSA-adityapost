using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.UserRegister.Queries.GetUserRegister;

using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.UserProfileHandler
{

    public class GetUserRegisterQueryHandler : IRequestHandler<GetAllUserRegister, List<UserRegisterDTOs>>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;

        public GetUserRegisterQueryHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserRegisterDTOs>> Handle(GetAllUserRegister request, CancellationToken cancellationToken)
        {
            var userProfiles = await _context.userRegisters
            .Include(u => u.RollNumber)
            .ThenInclude(r => r.Batch)
            .Include(u => u.city)
            .ThenInclude(c => c.State)
            .ThenInclude(s => s.Country)
            .Include(u => u.PersonalInformation) 
            .ToListAsync(cancellationToken);

            if (userProfiles == null || !userProfiles.Any())
            {
                throw new Exception("No user profiles found.");
            }
            foreach (var user in userProfiles)
            {
                Console.WriteLine($"User: {user.FullName}, Address: {user.PersonalInformation?.Address}, Comments: {user.PersonalInformation?.Comments}, AboutYourself: {user.PersonalInformation?.AboutYourself}" );
            }

            var MappedUserProfiles = _mapper.Map<List<UserRegisterDTOs>>(userProfiles);

            if (MappedUserProfiles == null || !MappedUserProfiles.Any())
            {
                throw new Exception("Mapping to DTOs failed.");
            }

            return MappedUserProfiles;
        }

    }
    }


