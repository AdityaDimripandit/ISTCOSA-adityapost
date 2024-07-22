using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Domain.Entities
{
    public class UserPersonalInformation
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public UserRegister? User { get; set; }
        public int? userStudentId { get; set; }
        public UserStudent? UserStudent { get; set; }
        public int? UserWorkId { get; set; }
        public UserWork? UserWork { get; set; }
        public string Address { get; set; }
        public string? MaritalStatus { get; set; }
        public string FatherName { get; set; }
        public string? SpouseName { get; set; }
        public DateTime? AnniversaryDate { get; set; }
        public string? FamilyDetails { get; set; }  
        public string? PreviousDesignation {get; set;}
        public string? PreviousCompanyName { get; set; }    
        public string? PreviousJobDescription { get; set; } 
        public string ISTCNickName { get; set; }
        public string ISTCFriend { get; set; }
        public string ISTCAbout { get; set; }
        public string Comments { get; set; }
        public string AboutYourself { get; set; }  
        public string WhatsappNumber { get; set; }
        public string? MembershipType { get; set; }       
        public DateTime? LastLoginDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        
       
    }
}
