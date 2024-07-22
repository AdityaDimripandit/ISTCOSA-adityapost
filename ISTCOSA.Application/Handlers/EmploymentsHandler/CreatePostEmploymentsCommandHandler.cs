using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.UserEmployment.Commands;
using ISTCOSA.Domain.Entities;


using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.UserEmploymentHandler
{
    public class CreateUserProfessionalCommandHandler : IRequestHandler<CreatePostEmploymentlCommand, PostEmploymentDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;

        public CreateUserProfessionalCommandHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PostEmploymentDTO> Handle(CreatePostEmploymentlCommand request, CancellationToken cancellationToken)
        {
            Company company = null;
            if (request.CompanyId>0)
            {
                company = await _context.companies.FindAsync(request.CompanyId.Value);
            }
            else if (!string.IsNullOrEmpty(request.CompanyName))
            {
                company = await _context.companies.FirstOrDefaultAsync(c => c.Name == request.CompanyName, cancellationToken);
                if (company == null)
                {
                    company = new Company
                    { Name = request.CompanyName,
                        Address = request.CompanyAddress,
                        EmailAddress = request.CompanyEmailAddress,
                        PhoneNumber = request.CompanyPhoneNumber,
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                    };

                    _context.companies.Add(company);
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }
            Industry industry = null;
            if (request.IndustryId>0)
            {
                industry = await _context.industries.FindAsync(request.IndustryId.Value);
            }
            else if (!string.IsNullOrEmpty(request.IndustryName))
            {
                industry = await _context.industries.FirstOrDefaultAsync(i => i.Name == request.IndustryName, cancellationToken);
                if (industry == null)
                {
                    industry = new Industry { Name = request.IndustryName,CreatedDate=DateTime.Now, IsActive = true, };
                    _context.industries.Add(industry);
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }
            Profession employmentType = null;
            if (request.EmploymentTypeId > 0 )
            {
                employmentType = await _context.professions.FindAsync(request.EmploymentTypeId.Value);
            }
            else if (!string.IsNullOrEmpty(request.EmploymentTypeName))
            {
                employmentType = await _context.professions.FirstOrDefaultAsync(et => et.Name == request.EmploymentTypeName, cancellationToken);
                if (employmentType == null)
                {
                    employmentType = new Profession { Name = request.EmploymentTypeName,CreatedDate = DateTime.Now, IsActive = true, };
                    _context.professions.Add(employmentType);
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }
            var existingPhone = await _context.postEmployments.FirstOrDefaultAsync(x => x.ContactNumber == request.ContactNumber);
            if (existingPhone != null) throw new Exception("Phone Number has Already used by Someone");
            var existingEmail = await _context.postEmployments.FirstOrDefaultAsync(x => x.ContactEmail == request.ContactEmail);
            if (existingEmail != null) throw new Exception("Email has Already used by Someone");
            var userEmployment = new PostEmployment
            {
                JobTitle = request.JobTitle,
                RolesAndResponsibilty = request.RolesAndResponsibilty,
                Experience = request.Experience,
                Location = request.Location,
                Qualification = request.Qualification,
                Salary = request.Salary,
                ContactName = request.ContactName,
                ContactEmail = request.ContactEmail,
                ContactNumber = request.ContactNumber,
                Description = request.Description,
                CompanyId = company.Id,
                IndustryId = industry.Id,
                EmploymentTypeId = employmentType.Id,
                CreatedDate = DateTime.Now,
                 IsActive = true,
            };

            await _context.postEmployments.AddAsync(userEmployment);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<PostEmploymentDTO>(userEmployment);

        }
    }
}
