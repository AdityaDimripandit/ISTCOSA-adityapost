using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.UserEmployment.Commands;
using ISTCOSA.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.UserEmploymentHandler
{
    public class UpdateUserProfessionalCommandHandler : IRequestHandler<UpdatePostEmploymentlCommand, PostEmploymentDTO>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        public UpdateUserProfessionalCommandHandler(IApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper= mapper;
        }
        public async Task<PostEmploymentDTO> Handle(UpdatePostEmploymentlCommand request, CancellationToken cancellationToken)
        {
            var userEmployment = await _context.postEmployments.FindAsync(request.Id);

            if (userEmployment == null)
            {
                throw new Exception("UserEmployment not found");
            }

            Company company = null;
            if (request.CompanyId > 0)
            {
                company = await _context.companies.FindAsync(request.CompanyId.Value);
            }
            else if (!string.IsNullOrEmpty(request.CompanyName))
            {
                company = await _context.companies.FirstOrDefaultAsync(c => c.Name == request.CompanyName, cancellationToken);
                if (company == null)
                {
                    company = new Company
                    {
                        Name = request.CompanyName,
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
            if (request.IndustryId > 0)
            {
                industry = await _context.industries.FindAsync(request.IndustryId.Value);
            }
            else if (!string.IsNullOrEmpty(request.IndustryName))
            {
                industry = await _context.industries.FirstOrDefaultAsync(i => i.Name == request.IndustryName, cancellationToken);
                if (industry == null)
                {
                    industry = new Industry
                    {
                        Name = request.IndustryName,
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                    };
                    _context.industries.Add(industry);
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }

            Profession employmentType = null;
            if (request.EmploymentTypeId > 0)
            {
                employmentType = await _context.professions.FindAsync(request.EmploymentTypeId.Value);
            }
            else if (!string.IsNullOrEmpty(request.EmploymentTypeName))
            {
                employmentType = await _context.professions.FirstOrDefaultAsync(et => et.Name == request.EmploymentTypeName, cancellationToken);
                if (employmentType == null)
                {
                    employmentType = new Profession
                    {
                        Name = request.EmploymentTypeName,
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                    };
                    _context.professions.Add(employmentType);
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }

            var existingPhone = await _context.postEmployments.FirstOrDefaultAsync(x => x.ContactNumber == request.ContactNumber && x.Id != request.Id);
            if (existingPhone != null) throw new Exception("Phone Number has already been used by someone else");

            var existingEmail = await _context.postEmployments.FirstOrDefaultAsync(x => x.ContactEmail == request.ContactEmail && x.Id != request.Id);
            if (existingEmail != null) throw new Exception("Email has already been used by someone else");

            userEmployment.JobTitle = request.JobTitle;
            userEmployment.RolesAndResponsibilty = request.RolesAndResponsibilty;
            userEmployment.Experience = request.Experience;
            userEmployment.Location = request.Location;
            userEmployment.Qualification = request.Qualification;
            userEmployment.Salary = request.Salary;
            userEmployment.ContactName = request.ContactName;
            userEmployment.ContactEmail = request.ContactEmail;
            userEmployment.ContactNumber = request.ContactNumber;
            userEmployment.Description = request.Description;
            userEmployment.CompanyId = company.Id;
            userEmployment.IndustryId = industry.Id;
            userEmployment.EmploymentTypeId = employmentType.Id;
            userEmployment.IsActive = true; 
            userEmployment.UpdatedDate= DateTime.Now;
            _context.postEmployments.Update(userEmployment);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<PostEmploymentDTO>(userEmployment);
        }
    }
}
