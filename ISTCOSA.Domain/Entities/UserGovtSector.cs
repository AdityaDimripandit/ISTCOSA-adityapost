using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Domain.Entities
{
    public class UserGovtSector
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public string DepartMent { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate {  get; set; }
        public DateTime? UpdatedDate { get;set; }
        public bool IsActive { get;set; }
    }
}
