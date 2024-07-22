using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.Common.DTOs
{
    public class UserWorkDTO:IMapping<UserWork>
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public string ContactNumber { get; set; }
        public string EmailID { get; set; }
        public string WorkProfile { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public int ProfessionId { get; set; }
        public Profession? Profession { get; set; }
    }
}
