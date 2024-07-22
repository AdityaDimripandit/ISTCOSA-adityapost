using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Domain.Entities
{
    public class PostEmployment
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string RolesAndResponsibilty { get; set; }
        public string Experience  { get; set; }
        public string Location { get; set; }
        public string Qualification { get; set; }
        public decimal Salary { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public string Description { get; set; }
        public int EmploymentTypeId { get; set; }
       
        public Profession? EmploymentType { get; set; }
        public int IndustryId { get; set; }
        public Industry? Industry { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; }

        


    }
}
