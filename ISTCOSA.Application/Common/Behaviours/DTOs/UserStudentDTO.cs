using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.Common.DTOs
{
    public class UserStudentDTO
    {
        public int Id { get; set; }
        public string CollegeName { get; set; }
        public string Degree { get; set; }
        public string Skills { get; set; }
        public DateTime? JoiningYear { get; set; }
        public DateTime? ExpectedComplitionYear { get; set; }
    }
}
