using ISTCOSA.Application.Common.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.UserEmployment.Commands
{
    public class UpdatePostEmploymentlCommand : IRequest<PostEmploymentDTO>
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string RolesAndResponsibilty { get; set; }
        public string Experience { get; set; }
        public string Location { get; set; }
        public string Qualification { get; set; }
        public decimal Salary { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string CompanyEmailAddress { get; set; }
        public DateTime CompanyCreatedDate { get; set; }
        public int? IndustryId { get; set; }
        public string IndustryName { get; set; }
        public int? EmploymentTypeId { get; set; }
        public string EmploymentTypeName { get; set; }
    }
}
