using ISTCOSA.Domain.Entities;

namespace ISTCOSA.Application.Common.DTOs
{
    public class PostEmploymentDTO:IMapping<PostEmployment>
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
        public int? IndustryId { get; set; }
        public string IndustryName { get; set; }
        public int? EmploymentTypeId { get; set; }
        public string EmploymentTypeName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
