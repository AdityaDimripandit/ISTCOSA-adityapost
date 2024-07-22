using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.UserSearch;
using ISTCOSA.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.UserSearchHandler
{
    public class UserSearchCommandHandler : IRequestHandler<UserSearchCommand, PaginatedResponseDTO<UserRegisterDTOs>>
    {
        private readonly IApplicationDBContext _Context;
        private readonly IMapper _mapper;
        public UserSearchCommandHandler(IApplicationDBContext Context, IMapper mapper)
        {
            _Context = Context;
            _mapper = mapper;
        }

        public async Task<PaginatedResponseDTO<UserRegisterDTOs>> Handle(UserSearchCommand request, CancellationToken cancellationToken)
        {
            IQueryable<UserRegister> query = _Context.userRegisters.Include(x => x.RollNumber.Batch)
                .Include(x => x.city).ThenInclude(c => c.State).ThenInclude(s => s.Country);

            if (!string.IsNullOrEmpty(request.FullName))
            {
                query = query.Where(x => x.FullName.Contains(request.FullName));
            }
            if (!string.IsNullOrEmpty(request.PinCode))
            {
                query = query.Where(x => x.PinCode == request.PinCode);
            }
            if (!string.IsNullOrEmpty(request.Email))
            {
                query = query.Where(x => x.Email == request.Email);
            }
            if (!string.IsNullOrEmpty(request.PhoneNumber))
            {
                query = query.Where(x => x.PhoneNumber == request.PhoneNumber);
            }
            if (request.BatchNumber != null && request.BatchNumber > 0)
            {
                query = query.Where(x => x.RollNumber.Batch.BatchNumber == request.BatchNumber);
            }
            if (request.RollNumbers != null && request.RollNumbers > 0)
            {
                query = query.Where(x => x.RollNumber.RollNumbers == request.RollNumbers);
            }
            if (request.CountryId != null && request.CountryId > 0)
            {
                query = query.Where(x => x.city.State.CountryId == request.CountryId);
            }
            if (request.DateOfBirth != null && request.DateOfBirth > DateTime.MinValue)
            {
                query = query.Where(x => x.DateOfBirth == request.DateOfBirth);
            }
            int totalRecords = await query.CountAsync(cancellationToken);
            query = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);

            var studentList = await query.ToListAsync(cancellationToken);
            var mappedData = _mapper.Map<List<UserRegisterDTOs>>(studentList);

            var totalPages = (int)Math.Ceiling(totalRecords / (double)request.PageSize);

            return new PaginatedResponseDTO<UserRegisterDTOs>
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalPages = totalPages,
                TotalRecords = totalRecords,
                Data = mappedData
            };
        }
    }
}
