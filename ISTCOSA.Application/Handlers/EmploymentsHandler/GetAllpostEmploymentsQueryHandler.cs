using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.UserEmployment.Queries;

using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.UserEmploymentHandler
{
    public class GetAllUserProfessionalQueryHandler : IRequestHandler<GetAllPostEmploymentQuery, List<PostEmploymentDTO>>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public GetAllUserProfessionalQueryHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<PostEmploymentDTO>> Handle(GetAllPostEmploymentQuery request, CancellationToken cancellationToken)
        {
            {
                if (_context == null)
                {
                    throw new InvalidOperationException("Database context is not initialized.");
                }

                try
                {
                    var employmentList = await _context.postEmployments
                        .Include(x => x.EmploymentType)
                        .Include(x => x.Industry)
                        .Include(x => x.Company)
                        .Where(x => x.IsActive)
                        .ToListAsync(cancellationToken);

                    if (employmentList == null || !employmentList.Any())
                    {
                        throw new Exception("No active employment records found.");
                    }

                    var mappingData = _mapper.Map<List<PostEmploymentDTO>>(employmentList);

                    if (mappingData == null || !mappingData.Any())
                    {
                        throw new Exception("Error occurred during mapping of employment list.");
                    }

                    return mappingData;
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while retrieving user employment data.", ex);
                }
            }
        }
    }
}
