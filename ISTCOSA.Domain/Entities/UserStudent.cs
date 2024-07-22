using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Domain.Entities
{
    public class UserStudent
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserRegister? User { get; set; }

        public string CollegeName { get; set; }
        public string Degree { get; set; }
        public string Skills { get; set; }
        public DateTime? JoiningYear { get; set; }
        public DateTime? ExpectedComplitionYear { get; set;}
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
